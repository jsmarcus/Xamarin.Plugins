using System;
using System.ComponentModel;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.Droid;
using Plugin.Iconize.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconLabel), typeof(IconLabelRenderer))]
namespace FormsPlugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="IconLabelRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.LabelRenderer" />
    public class IconLabelRenderer : LabelRenderer
    {
        /// <summary>
        /// Disposes the specified disposing.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void Dispose(Boolean disposing)
        {
            if (Control != null)
            {
                Control.TextChanged -= OnTextChanged;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Label}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            UpdateText();
            Control.TextChanged += OnTextChanged;
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
                case nameof(IconLabel.FontSize):
                case nameof(IconLabel.TextColor):
                    UpdateText();
                    break;
            }
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Android.Text.TextChangedEventArgs"/> instance containing the event data.</param>
        private void OnTextChanged(Object sender, Android.Text.TextChangedEventArgs e)
        {
            UpdateText();
        }

        /// <summary>
        /// Updates the text.
        /// </summary>
        private void UpdateText()
        {
            Control.TextChanged -= OnTextChanged;
            if (String.IsNullOrEmpty(Element.Text) == false)
            {
                Control.TextFormatted = Control.Compute(Context, new Java.Lang.String(Element.Text), (Single)Element.FontSize);
            }
            Control.TextChanged += OnTextChanged;
        }
    }
}