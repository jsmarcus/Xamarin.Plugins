using System;
using AppKit;
using CoreGraphics;
using CoreText;
using Foundation;
using CoreVideo;
using System.Diagnostics.Contracts;

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
		/// To the NS image.
		/// </summary>
		/// <param name="icon">The icon.</param>
		/// <param name="size">The size.</param>
		/// <returns></returns>
        public static NSImage ToNSImage(this IIcon icon, nfloat size)
		{
            return ToNSImageWithColor(icon, size, NSColor.Black.CGColor);
		}

		public static NSImage ToNSImageWithColor(this IIcon icon, nfloat size, CGColor color)
		{
			var attributedString = new NSAttributedString($"{icon.Character}", new CTStringAttributes
			{
				Font = new CTFont(Iconize.FindModuleOf(icon).FontName, size),
				ForegroundColorFromContext = true
			});

			using (var ctx = new CGBitmapContext(IntPtr.Zero, (nint)size, (nint)size, 8, 4 * (nint)(size), CGColorSpace.CreateDeviceRGB(), CGImageAlphaInfo.PremultipliedFirst))
			{
				ctx.SetFillColor(color);

				using (var textLine = new CTLine(attributedString))
				{
					textLine.Draw(ctx);
				}

				return new NSImage(ctx.ToImage(), new CGSize(size, size));
			}
		}
    }
}
