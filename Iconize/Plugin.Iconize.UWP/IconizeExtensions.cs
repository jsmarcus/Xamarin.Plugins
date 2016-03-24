using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Plugin.Iconize.UWP
{
    /// <summary>
    /// Defines the <see cref="IconizeExtensions" /> extensions.
    /// </summary>
    public static class IconizeExtensions
    {
        private static readonly Dictionary<Type, FontFamily> _fontCache = new Dictionary<Type, FontFamily>();

        /// <summary>
        /// To the font family.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        public static FontFamily ToFontFamily(this IIconModule module)
        {
            var moduleType = module.GetType();
            if (_fontCache.ContainsKey(moduleType) == false)
            {
                _fontCache.Add(moduleType, new FontFamily($"ms-appx:///{module.GetType().GetTypeInfo().Assembly.GetName().Name}/{module.FontPath}#{module.FontFamily}"));
            }
            return _fontCache[moduleType];
        }

        /// <summary>
        /// To the image source.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <param name="size">The size.</param>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static async Task<ImageSource> ToImageSourceAsync(this IIcon icon, Double size, Color color)
        {
            var grid = new Grid();
            grid.Children.Add(new TextBlock
            {
                FontFamily = Iconize.FindModuleOf(icon).ToFontFamily(),
                FontSize = size,
                Foreground = new SolidColorBrush(color),
                Text = $"{icon.Character}"
            });

            var bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(grid);
            return bitmap;
        }
    }
}
