using System;
using AppKit;
using CoreGraphics;
using CoreText;
using Foundation;

namespace Plugin.Iconize.macOS
{
    public static class IconizeExtensions
    {
		/// <summary>
		/// To the NS font.
		/// </summary>
		/// <param name="module">The module.</param>
		/// <param name="size">The size.</param>
		/// <returns></returns>
        public static NSFont ToNSFont(this IIconModule module, nfloat size)
		{
			return NSFont.FromFontName(module.FontName, size);
		}

		/// <summary>
		/// To the UI image.
		/// </summary>
		/// <param name="icon">The icon.</param>
		/// <param name="size">The size.</param>
		/// <returns></returns>
        public static NSImage ToNSImage(this IIcon icon, nfloat size)
		{
            throw new NotImplementedException();
			//var attributedString = new NSAttributedString($"{icon.Character}", new CTStringAttributes
			//{
			//	Font = new CTFont(Iconize.FindModuleOf(icon).FontName, size),
			//	ForegroundColorFromContext = true
			//});

			//var boundSize = attributedString.GetBoundingRect(new CGSize(10000f, 10000f), NSStringDrawingOptions.UsesLineFragmentOrigin, null).Size;

			//UIGraphics.BeginImageContextWithOptions(boundSize, false, 0f);
			//attributedString.DrawString(new CGRect(0f, 0f, boundSize.Width, boundSize.Height));
			//using (var image = UIGraphics.GetImageFromCurrentImageContext())
			//{
			//	UIGraphics.EndImageContext();

			//	return image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
			//}
		}
    }
}
