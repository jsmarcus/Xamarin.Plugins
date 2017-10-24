using System;
using System.ComponentModel;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.macOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using AppKit;
using Plugin.Iconize.macOS;
using CoreAnimation;

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]
namespace FormsPlugin.Iconize.macOS
{
    public class IconImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Image}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            UpdateImage();
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconImage.Icon):
                case nameof(IconImage.IconSize):
                    UpdateImage();
                    break;

                case nameof(IconImage.IconColor):
                    UpdateImage();
                    break;
            }
        }

        /// <summary>
        /// Updates the image.
        /// </summary>
        private void UpdateImage()
        {
            var iconImage = Element as IconImage;

            var icon = Plugin.Iconize.Iconize.FindIconForKey(iconImage.Icon);
            if (icon == null)
            {
                Control.Layer.Contents = null;
                return;
            }

            if (Element.HeightRequest < 0)
                Element.HeightRequest = iconImage.IconSize;

            var iconSize = (iconImage.IconSize > 0 ? (nfloat)iconImage.IconSize : (nfloat)Element.HeightRequest);

            if (iconSize < 0)
                throw new ArgumentException("The icon size is under zero !");

            using (var image = icon.ToNSImageWithColor(iconSize, iconImage.IconColor.ToCGColor()))
            {
                Control.Layer.Contents = image.CGImage;
            }
        }
    }
}
