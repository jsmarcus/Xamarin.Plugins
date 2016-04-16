using System;
using Xamarin.Forms;

namespace FormsPlugin.Iconize
{
	/// <summary>
	/// Defines the <see cref="IconImage" /> control.
	/// </summary>
	/// <seealso cref="Xamarin.Forms.Image" />
	public class IconImage : Image
	{
		#region Static Properties

		/// <summary>
		/// When the property <see cref="IconSize" /> is set to this value, the icon size will match the Image Size.
		/// </summary>
		public static double IconAutoSize { get { return -1.0; } }

		#endregion

		#region Icon Property

		/// <summary>
		/// Property definition for the <see cref="Icon" /> Property
		/// </summary>
		public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(String), typeof(IconImage), String.Empty);

		/// <summary>
		/// Gets or sets the icon.
		/// </summary>
		/// <value>
		/// The icon.
		/// </value>
		public String Icon
		{
			get { return (String)GetValue(IconProperty); }
			set { SetValue(IconProperty, value); }
		}

		#endregion

		#region IconColor Property

		/// <summary>
		/// Property definition for the <see cref="IconColor" /> Property
		/// </summary>
		public static BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(IconImage), Color.Default);

		/// <summary>
		/// Gets or sets the color of the icon.
		/// </summary>
		/// <value>
		/// The color of the icon.
		/// </value>
		public Color IconColor
		{
			get { return (Color)GetValue(IconColorProperty); }
			set { SetValue(IconColorProperty, value); }
		}

		#endregion

		#region IconSize Property

		public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(IconImage), IconImage.IconAutoSize);

		public double IconSize
		{
			get { return (double)GetValue(IconSizeProperty); }
			set { SetValue(IconSizeProperty, value); }
		}

		#endregion
	}
}