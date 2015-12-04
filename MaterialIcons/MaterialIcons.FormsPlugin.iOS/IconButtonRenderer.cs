using System;
using System.ComponentModel;
using Foundation;
using MaterialIcons.FormsPlugin.Abstractions;
using MaterialIcons.FormsPlugin.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]
namespace MaterialIcons.FormsPlugin.iOS
{
    /// <summary>
    /// IconButton Implementation
    /// </summary>
    /// <seealso cref="ButtonRenderer" />
    [Preserve(AllMembers = true)]
    public class IconButtonRenderer : ButtonRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Button}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            Control.Font = Font.OfSize("MaterialIcons-Regular", Element.FontSize).WithAttributes(Element.FontAttributes).ToUIFont();
            Element.Text = ((IconButton)Element).Icon;
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

            if (e.PropertyName == IconButton.IconProperty.PropertyName ||
                e.PropertyName == Button.TextProperty.PropertyName)
            {
                Element.Text = ((IconButton)Element).Icon;
            }
        }
    }
}