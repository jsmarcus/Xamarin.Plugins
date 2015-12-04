using System;
using System.ComponentModel;
using Android.Graphics;
using Android.Runtime;
using MaterialIcons.FormsPlugin.Abstractions;
using MaterialIcons.FormsPlugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconLabel), typeof(IconLabelRenderer))]
namespace MaterialIcons.FormsPlugin.Droid
{
    /// <summary>
    /// IconLabel Implementation
    /// </summary>
    /// <seealso cref="LabelRenderer" />
    [Preserve(AllMembers = true)]
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

            Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, "MaterialIcons-Regular.ttf");
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