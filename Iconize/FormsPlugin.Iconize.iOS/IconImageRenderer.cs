using System;
using System.ComponentModel;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.iOS;
using Plugin.Iconize.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]
namespace FormsPlugin.Iconize.iOS
{
    /// <summary>
    /// Defines the <see cref="IconImageRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.ImageRenderer" />
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

            var iconImage = Element as IconImage;
            Control.Image = Plugin.Iconize.Iconize.FindIconForKey(iconImage.Icon).ToUIImage((nfloat)Element.HeightRequest).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            Control.TintColor = iconImage.IconColor.ToUIColor();
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

            var iconImage = Element as IconImage;

            switch (e.PropertyName)
            {
                case nameof(IconImage.Icon):
                    Control.Image = Plugin.Iconize.Iconize.FindIconForKey(iconImage.Icon).ToUIImage((nfloat)Element.HeightRequest).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                    break;

                case nameof(IconImage.IconColor):
                    Control.TintColor = iconImage.IconColor.ToUIColor();
                    break;
            }
        }
    }
}
