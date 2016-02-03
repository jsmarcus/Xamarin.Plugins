using System;
using Xamarin.Forms;

namespace FormsPlugin.Iconize
{
    public class IconImage : Image
    {
        /// <summary>
        /// Property definition for the <see cref="Icon"/> Property
        /// </summary>
        public static BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(String), typeof(IconImage), String.Empty);

        /// <summary>
        /// Property definition for the <see cref="IconColor"/> Property
        /// </summary>
        public static BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(IconImage), Color.Default);

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
    }
}