using System;
using CoreGraphics;
using CoreText;
using Foundation;
using UIKit;

namespace Plugin.Iconize.iOS
{
    public static class IconizeExtensions
    {
        public static NSAttributedString Compute(this UIView target, NSAttributedString text, nfloat size)
        {
            return ParsingUtil.Parse(Iconize.Modules, text, size);
        }

        public static NSAttributedString Compute(this UIView target, String text, nfloat size)
        {
            if (String.IsNullOrEmpty(text))
                return new NSAttributedString();

            return Compute(target, new NSAttributedString(text), size);
        }

        public static UIFont ToUIFont(this IIconModule module, nfloat size)
        {
            return UIFont.FromName(module.FontName, size);
        }

        public static UIImage ToUIImage(this IIcon icon, nfloat size)
        {
            var attributedString = new NSAttributedString($"{icon.Character}", new CTStringAttributes
            {
                Font = new CTFont(Iconize.FindModuleOf(icon).FontName, size),
                ForegroundColorFromContext = true
            });

            var boundSize = attributedString.GetBoundingRect(new CGSize(10000, 10000), NSStringDrawingOptions.UsesLineFragmentOrigin, null).Size;

            UIGraphics.BeginImageContextWithOptions(boundSize, false, 0f);
            attributedString.DrawString(new CGRect(0, 0, boundSize.Width, boundSize.Height));
            var image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return image;
        }
    }
}