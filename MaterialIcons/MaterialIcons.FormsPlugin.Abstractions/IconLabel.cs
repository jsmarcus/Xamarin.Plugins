using Xamarin.Forms;

namespace MaterialIcons.FormsPlugin.Abstractions
{
    /// <summary>
    /// Class definition for the <see cref="IconLabel"/> Control
    /// </summary>
    /// <seealso cref="Label" />
    public class IconLabel : Label
    {
        /// <summary>
        /// Property definition for the <see cref="Icon"/> Property
        /// </summary>
        public static BindableProperty IconProperty = BindableProperty.Create<IconLabel, MaterialIcons>(x => x.Icon, default(MaterialIcons));

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