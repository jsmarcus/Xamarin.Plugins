using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Foundation;
using UIKit;

namespace Plugin.Iconize.iOS
{
    public static class ParsingUtil
    {
        public static NSAttributedString Parse(IList<IIconModule> modules, NSAttributedString text, nfloat size)
        {
            var builder = new NSMutableAttributedString(text);
            RecursivePrepareSpannableIndexes(modules, text.Value, size, builder, 0);
            return (NSAttributedString)builder.Copy();
        }

        private static void RecursivePrepareSpannableIndexes(IList<IIconModule> modules, String text, nfloat size, NSMutableAttributedString builder, Int32 start)
        {
            // Try to find a {...} in the string and extract expression from it
            var startIndex = builder.Value.IndexOf("{", start, StringComparison.Ordinal);
            if (startIndex == -1)
                return;
            var endIndex = builder.Value.IndexOf("}", startIndex, StringComparison.Ordinal);
            var expression = builder.Value.Substring(startIndex + 1, endIndex - startIndex - 1);

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
                RecursivePrepareSpannableIndexes(modules, text, size, builder, endIndex);
                return;
            }

            // See if any more stroke within {} should be applied
            var iconSizePt = nfloat.MinValue;
            var iconColor = UIColor.DarkTextColor;
            var iconSizeRatio = nfloat.MinValue;
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
                else if (Regex.IsMatch(stroke, "([0-9]*)px"))
                {
                    iconSizePt = Convert.ToInt32(stroke.Substring(0, stroke.Length - 2));
                }
                else if (Regex.IsMatch(stroke, "([0-9]*)pt"))
                {
                    iconSizePt = Convert.ToInt32(stroke.Substring(0, stroke.Length - 2));
                }
                else if (Regex.IsMatch(stroke, "([0-9]*(\\.[0-9]*)?)%"))
                {
                    iconSizeRatio = Convert.ToSingle(stroke.Substring(0, stroke.Length - 1)) / 100f;
                }

                // Look for an icon color
                else if (Regex.IsMatch(stroke, "#([0-9A-Fa-f]{6}|[0-9A-Fa-f]{8})"))
                {
                    if (stroke.Length == 7)
                    {
                        var red = Int32.Parse(stroke.Substring(1, 2), NumberStyles.HexNumber);
                        var blue = Int32.Parse(stroke.Substring(3, 2), NumberStyles.HexNumber);
                        var green = Int32.Parse(stroke.Substring(5, 2), NumberStyles.HexNumber);
                        iconColor = new UIColor(red / 255f, blue / 255f, green / 255f, 1f);
                    }
                    else if (stroke.Length == 9)
                    {
                        var alpha = Int32.Parse(stroke.Substring(1, 2), NumberStyles.HexNumber);
                        var red = Int32.Parse(stroke.Substring(3, 2), NumberStyles.HexNumber);
                        var blue = Int32.Parse(stroke.Substring(5, 2), NumberStyles.HexNumber);
                        var green = Int32.Parse(stroke.Substring(7, 2), NumberStyles.HexNumber);
                        iconColor = new UIColor(red / 255f, blue / 255f, green / 255f, alpha / 255f);
                    }
                }
                else
                {
                    throw new ArgumentException("Unknown expression " + stroke + " in \"" + text + "\"");
                }
            }

            if (iconSizePt == nfloat.MinValue)
            {
                iconSizePt = size;
            }

            if (iconSizeRatio != nfloat.MinValue)
            {
                iconSizePt = iconSizePt * iconSizeRatio;
            }

            var attributes = new UIStringAttributes
            {
                Font = module.ToUIFont(iconSizePt)
            };

            if (baselineAligned == true)
            {
                attributes.BaselineOffset = 0f;
            }

            if (iconColor != UIColor.DarkTextColor)
            {
                attributes.ForegroundColor = iconColor;
            }

            var replaceString = new NSAttributedString($"{icon.Character}", attributes);

            // Replace the character and apply the typeface
            builder.Replace(new NSRange(startIndex, endIndex - startIndex + 1), replaceString);

            RecursivePrepareSpannableIndexes(modules, text, size, builder, startIndex);
        }
    }
}
