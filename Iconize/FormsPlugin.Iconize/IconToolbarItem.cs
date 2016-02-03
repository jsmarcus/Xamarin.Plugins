using Xamarin.Forms;

namespace FormsPlugin.Iconize
{
    public class IconToolbarItem : ToolbarItem
    {
        /// <summary>
        /// Property definition for the <see cref="IconColor"/> Property
        /// </summary>
        public static BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(IconToolbarItem), Color.Default);

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