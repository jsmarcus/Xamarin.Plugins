using System;
using System.ComponentModel;
using System.Windows.Media;
using MaterialIcons.FormsPlugin.Abstractions;
using MaterialIcons.FormsPlugin.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]
namespace MaterialIcons.FormsPlugin.WinPhone
{
    /// <summary>
    /// IconButton Implementation
    /// </summary>
    /// <seealso cref="ButtonRenderer" />
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

            Control.FontFamily = new FontFamily(@"\Assets\MaterialIcons-Regular.ttf#Material Icons");
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