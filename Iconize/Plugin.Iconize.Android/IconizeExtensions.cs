using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Plugin.Iconize.Android
{
    public static class IconizeExtensions
    {
        private static Dictionary<Type, Typeface> _typefaceCache = new Dictionary<Type, Typeface>();

        /// <summary>
        /// Replace "{}" tags in the given text views with actual icons, requesting the IconFontDescriptors
        /// one after the others.
        /// <strong>This is a one time call.</strong> If you call <see cref="TextView.SetText(string, TextView.BufferType)"/> after this,
        /// you'll need to call it again.
        /// </summary>
        /// <param name="textViews">The text views.</param>
        public static void AddIcons(params TextView[] textViews)
        {
            foreach (var textView in textViews)
            {
                if (textView != null)
                {
                    textView.SetText(textView.Compute(textView.Context, textView.TextFormatted), TextView.BufferType.Spannable);
                }
            }
        }

        /// <summary>
        /// Computes the specified context.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="context">The context.</param>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static ICharSequence Compute(this View target, Context context, ICharSequence text)
        {
            return ParsingUtil.Parse(context, Iconize.Modules, text, target);
        }

        public static ICharSequence Compute(this ICharSequence text, Context context)
        {
            return ParsingUtil.Parse(context, Iconize.Modules, text, null);
        }

        /// <summary>
        /// Gets the typeface.
        /// </summary>
        /// <param name="module">The icon module.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static Typeface GetTypeface(this IIconModule module, Context context)
        {
            var moduleType = module.GetType();
            if (_typefaceCache.ContainsKey(moduleType) == false)
            {
                _typefaceCache.Add(moduleType, Typeface.CreateFromAsset(context.Assets, module.FontPath));
            }
            return _typefaceCache[moduleType];
        }
    }
}