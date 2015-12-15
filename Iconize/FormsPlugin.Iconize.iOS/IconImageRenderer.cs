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
    public class IconImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Image}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            var iconImage = Element as IconImage;
            Control.Image = Plugin.Iconize.Iconize.FindIconForKey(iconImage.Icon).ToUIImage((nfloat)Element.Height).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            Control.TintColor = iconImage.IconColor.ToUIColor();
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            var iconImage = Element as IconImage;

            if (e.PropertyName == IconImage.IconProperty.PropertyName)
            {
                Control.Image = Plugin.Iconize.Iconize.FindIconForKey(iconImage.Icon).ToUIImage((nfloat)Element.Height).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            }
            else if (e.PropertyName == IconImage.IconColorProperty.PropertyName)
            {
                Control.TintColor = iconImage.IconColor.ToUIColor();
            }
        }
    }
}
