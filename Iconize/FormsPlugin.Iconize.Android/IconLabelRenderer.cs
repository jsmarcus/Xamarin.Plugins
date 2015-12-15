using System.ComponentModel;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.Android;
using Java.Lang;
using Plugin.Iconize.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TextView = Android.Widget.TextView;

[assembly: ExportRenderer(typeof(IconLabel), typeof(IconLabelRenderer))]
namespace FormsPlugin.Iconize.Android
{
    public class IconLabelRenderer : LabelRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Label}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            Control.SetText(Control.Compute(Context, new String(Element.Text)), TextView.BufferType.Spannable);
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(System.Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                Control.SetText(Control.Compute(Context, new String(Element.Text)), TextView.BufferType.Spannable);
            }
        }
    }
}