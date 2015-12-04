using Xamarin.Forms;

namespace MaterialIcons.FormsPlugin.Abstractions
{
    /// <summary>
    /// Class definition for the <see cref="IconButton"/> Control
    /// </summary>
    /// <seealso cref="Button" />
    public class IconButton : Button
    {
        /// <summary>
        /// Property definition for the <see cref="Icon"/> Property
        /// </summary>
        public static BindableProperty IconProperty = BindableProperty.Create<IconButton, MaterialIcons>(x => x.Icon, default(MaterialIcons));

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public MaterialIcons Icon
        {
            get { return (MaterialIcons)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
    }
}