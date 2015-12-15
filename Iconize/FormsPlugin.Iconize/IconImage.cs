using System;
using Xamarin.Forms;

namespace FormsPlugin.Iconize
{
    public class IconImage : Image
    {
        /// <summary>
        /// Property definition for the <see cref="Icon"/> Property
        /// </summary>
        public static BindableProperty IconProperty = BindableProperty.Create<IconImage, String>(x => x.Icon, String.Empty);

        /// <summary>
        /// Property definition for the <see cref="IconColor"/> Property
        /// </summary>
        public static BindableProperty IconColorProperty = BindableProperty.Create<IconImage, Color>(x => x.IconColor, Color.Default);

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