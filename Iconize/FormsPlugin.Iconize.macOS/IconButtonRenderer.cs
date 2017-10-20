using System;
using System.ComponentModel;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.macOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using Plugin.Iconize.macOS;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]
namespace FormsPlugin.Iconize.macOS
{
    public class IconButtonRenderer : ButtonRenderer
    {
		/// <summary>
		/// Raises the <see cref="E:ElementChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="ElementChangedEventArgs{Button}" /> instance containing the event data.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
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
				case nameof(IconButton.FontSize):
				case nameof(IconButton.Text):
				case nameof(IconButton.TextColor):
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
				Control.Title = $"{icon.Character}";
                Control.Font = Plugin.Iconize.Iconize.FindModuleOf(icon).ToNSFont((nfloat)Element.FontSize);
			}
		}
    }
}
