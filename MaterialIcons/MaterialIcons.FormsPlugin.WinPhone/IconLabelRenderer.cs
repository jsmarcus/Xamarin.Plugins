using System;
using System.ComponentModel;
using System.Windows.Media;
using MaterialIcons.FormsPlugin.Abstractions;
using MaterialIcons.FormsPlugin.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(IconLabel), typeof(IconLabelRenderer))]
namespace MaterialIcons.FormsPlugin.WinPhone
{
    /// <summary>
    /// IconLabel Implementation
    /// </summary>
    /// <seealso cref="LabelRenderer" />
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

            Control.FontFamily = new FontFamily(@"\Assets\MaterialIcons-Regular.ttf#Material Icons");
            Control.Text = ((IconLabel)Element).Icon;
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

            if (e.PropertyName == IconLabel.IconProperty.PropertyName ||
                e.PropertyName == Label.TextProperty.PropertyName)
            {
                Control.Text = ((IconLabel)Element).Icon;
            }
        }
    }
}