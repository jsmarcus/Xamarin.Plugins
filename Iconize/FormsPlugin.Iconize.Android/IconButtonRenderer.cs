using System.ComponentModel;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.Android;
using Java.Lang;
using Plugin.Iconize.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ButtonRenderer = Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer;
using Single = System.Single;
using TextView = Android.Widget.TextView;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]
namespace FormsPlugin.Iconize.Android
{
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

            Control.SetText(Control.Compute(Context, new String(Element.Text), (Single)Element.FontSize), TextView.BufferType.Spannable);
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(System.Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if ((e.PropertyName == nameof(Button.FontSize) ||
                (e.PropertyName == nameof(Button.Text)) ||
                (e.PropertyName == nameof(Button.TextColor))))
            {
                Control.SetText(Control.Compute(Context, new String(Element.Text), (Single)Element.FontSize), TextView.BufferType.Spannable);
            }
        }
    }
}