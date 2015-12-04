using System;
using System.ComponentModel;
using Android.Graphics;
using Android.Runtime;
using MaterialIcons.FormsPlugin.Abstractions;
using MaterialIcons.FormsPlugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ButtonRenderer = Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]
namespace MaterialIcons.FormsPlugin.Droid
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

            Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, "MaterialIcons-Regular.ttf");
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