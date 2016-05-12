using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Android.Content;
using Android.Graphics;
using Android.Support.V4.View;
using Android.Text;
using Android.Util;
using Android.Views;

namespace Plugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="ParsingUtil" /> type.
    /// </summary>
    public static class ParsingUtil
    {
        public class MyListener : Java.Lang.Object, IOnViewAttachListener, Java.Lang.IRunnable
        {
            private Boolean _isAttached;
            private readonly View _view;

            public MyListener(View view)
            {
                _view = view;
            }

            public void OnAttach()
            {
                _isAttached = true;
                ViewCompat.PostOnAnimation(_view, this);
            }

            public void OnDetach()
            {
                _isAttached = false;
            }

            public void Run()
            {
                if (_isAttached)
                {
                    _view.Invalidate();
                    ViewCompat.PostOnAnimation(_view, this);
                }
            }
        }

        private static readonly String ANDROID_PACKAGE_NAME = "android";

        public static Java.Lang.ICharSequence Parse(Context context, IList<IIconModule> modules, Java.Lang.ICharSequence text, Single size, View target = null)
        {
            context = context.ApplicationContext;

            // Analyse the text and replace {} blocks with the appropriate character
            // Retain all transformations in the accumulator
            var builder = new SpannableStringBuilder(text);
            RecursivePrepareSpannableIndexes(context, text.ToString(), size, builder, modules, 0);
            var isAnimated = HasAnimatedSpans(builder);

            // If animated, periodically invalidate the TextView so that the
            // CustomTypefaceSpan can redraw itself
            if (isAnimated)
            {
                if (target == null)
                    throw new ArgumentException("You can't use \"spin\" without providing the target View.");
                if (!(target is IHasOnViewAttachListener))
                    throw new ArgumentException(target.Class.SimpleName + " does not implement " +
                        "HasOnViewAttachListener. Please use IconTextView, IconButton or IconToggleButton.");

                ((IHasOnViewAttachListener)target).SetOnViewAttachListener(new MyListener(target));
            }
            else if (target is IHasOnViewAttachListener)
            {
                ((IHasOnViewAttachListener)target).SetOnViewAttachListener(null);
            }

            return builder;
        }

        private static Boolean HasAnimatedSpans(SpannableStringBuilder spannableBuilder)
        {
            var spans = spannableBuilder.GetSpans(0, spannableBuilder.Length(), Java.Lang.Class.FromType(typeof(CustomTypefaceSpan)));
            foreach (var span in spans)
            {
                if (span is CustomTypefaceSpan)
                {
                    if (((CustomTypefaceSpan)span).IsAnimated)
                        return true;
                }
            }
            return false;
        }

        private static void RecursivePrepareSpannableIndexes(Context context, String text, Single size, SpannableStringBuilder builder, IList<IIconModule> modules, Int32 start)
        {
            // Try to find a {...} in the string and extract expression from it
            var stringText = builder.ToString();
            var startIndex = stringText.IndexOf("{", start, StringComparison.Ordinal);
            if (startIndex == -1)
                return;
            var endIndex = stringText.IndexOf("}", startIndex, StringComparison.Ordinal) + 1;
            var expression = stringText.Substring(startIndex + 1, endIndex - 2);

            // Split the expression and retrieve the icon key
            var strokes = expression.Split(' ');
            var key = strokes[0];

            // Loop through the descriptors to find a key match
            IIconModule module = null;
            IIcon icon = null;
            for (var i = 0; i < modules.Count; i++)
            {
                module = modules[i];
                icon = module.GetIcon(key);
                if (icon != null)
                    break;
            }

            // If no match, ignore and continue
            if (icon == null)
            {
                RecursivePrepareSpannableIndexes(context, text, size, builder, modules, endIndex);
                return;
            }

            // See if any more stroke within {} should be applied
            var iconSizePx = spToPx(context, size);
            var iconColor = Int32.MaxValue;
            var iconSizeRatio = -1f;
            var spin = false;
            var baselineAligned = false;
            for (var i = 1; i < strokes.Length; i++)
            {
                var stroke = strokes[i];

                // Look for "spin"
                if (stroke.Equals("spin", StringComparison.OrdinalIgnoreCase))
                {
                    spin = true;
                }

                // Look for "baseline"
                else if (stroke.Equals("baseline", StringComparison.OrdinalIgnoreCase))
                {
                    baselineAligned = true;
                }

                // Look for an icon size
                else if (Regex.IsMatch(stroke, "([0-9]*(\\.[0-9]*)?)dp"))
                {
                    iconSizePx = dpToPx(context, Convert.ToSingle(stroke.Substring(0, stroke.Length - 2)));
                }
                else if (Regex.IsMatch(stroke, "([0-9]*(\\.[0-9]*)?)sp"))
                {
                    iconSizePx = spToPx(context, Convert.ToSingle(stroke.Substring(0, stroke.Length - 2)));
                }
                else if (Regex.IsMatch(stroke, "([0-9]*)px"))
                {
                    iconSizePx = Convert.ToInt32(stroke.Substring(0, stroke.Length - 2));
                }
                else if (Regex.IsMatch(stroke, "@dimen/(.*)"))
                {
                    iconSizePx = GetPxFromDimen(context, context.PackageName, stroke.Substring(7));
                    if (iconSizePx < 0)
                        throw new ArgumentException("Unknown resource " + stroke + " in \"" + text + "\"");
                }
                else if (Regex.IsMatch(stroke, "@android:dimen/(.*)"))
                {
                    iconSizePx = GetPxFromDimen(context, ANDROID_PACKAGE_NAME, stroke.Substring(15));
                    if (iconSizePx < 0)
                        throw new ArgumentException("Unknown resource " + stroke + " in \"" + text + "\"");
                }
                else if (Regex.IsMatch(stroke, "([0-9]*(\\.[0-9]*)?)%"))
                {
                    iconSizeRatio = Convert.ToSingle(stroke.Substring(0, stroke.Length - 1)) / 100f;
                } 

                // Look for an icon color
                else if (Regex.IsMatch(stroke, "#([0-9A-Fa-f]{6}|[0-9A-Fa-f]{8})"))
                {
                    iconColor = Color.ParseColor(stroke);
                }
                else if (Regex.IsMatch(stroke, "@color/(.*)"))
                {
                    iconColor = GetColorFromResource(context, context.PackageName, stroke.Substring(7));
                    if (iconColor == Int32.MaxValue)
                        throw new ArgumentException("Unknown resource " + stroke + " in \"" + text + "\"");
                }
                else if (Regex.IsMatch(stroke, "@android:color/(.*)"))
                {
                    iconColor = GetColorFromResource(context, ANDROID_PACKAGE_NAME, stroke.Substring(15));
                    if (iconColor == Int32.MaxValue)
                        throw new ArgumentException("Unknown resource " + stroke + " in \"" + text + "\"");
                }
                else
                {
                    throw new ArgumentException("Unknown expression " + stroke + " in \"" + text + "\"");
                }
            }

            // Replace the character and apply the typeface
            builder = (SpannableStringBuilder)builder.Replace(startIndex, endIndex, "" + icon.Character);
            builder.SetSpan(new CustomTypefaceSpan(icon, module.ToTypeface(context), iconSizePx, iconSizeRatio, iconColor, spin, baselineAligned), startIndex, startIndex + 1, SpanTypes.InclusiveExclusive);
            RecursivePrepareSpannableIndexes(context, text, size, builder, modules, startIndex);
        }

        public static Single GetPxFromDimen(Context context, String packageName, String resName)
        {
            var resources = context.Resources;
            var resId = resources.GetIdentifier(resName, "dimen", packageName);
            if (resId <= 0)
                return -1;
            return resources.GetDimension(resId);
        }

        public static Int32 GetColorFromResource(Context context, String packageName, String resName)
        {
            var resources = context.Resources;
            var resId = resources.GetIdentifier(resName, "color", packageName);
            if (resId <= 0)
                return Int32.MaxValue;
            return resources.GetColor(resId);
        }

        public static Single dpToPx(Context context, Single dp)
        {
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, context.Resources.DisplayMetrics);
        }

        public static Single spToPx(Context context, Single sp)
        {
            return TypedValue.ApplyDimension(ComplexUnitType.Sp, sp, context.Resources.DisplayMetrics);
        }
    }
}