using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using Plugin.Iconize.macOS;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.macOS;

[assembly: ExportRenderer(typeof(IconLabel), typeof(IconLabelRenderer))]
namespace FormsPlugin.Iconize.macOS
{
    public class IconLabelRenderer : LabelRenderer
    {
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
				case nameof(IconLabel.Text):
				case nameof(IconLabel.TextColor):
					UpdateText();
					break;
			}
		}

		/// <summary>
		/// Updates the text.
		/// </summary>
		private void UpdateText()
		{
			var icon = Plugin.Iconize.Iconize.FindIconForKey(Element.Text);
			if (icon != null)
			{
                Control.StringValue = $"{icon.Character}";
                Control.Font = Plugin.Iconize.Iconize.FindModuleOf(icon).ToNSFont((nfloat)Element.FontSize);
			}
		}
    }
}
