using FormsPlugin.Iconize;
using FormsPlugin.Iconize.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(IconCarouselPage), typeof(IconCarouselRenderer))]
namespace FormsPlugin.Iconize.UWP
{
    /// <summary>
    /// Defines the <see cref="IconCarouselRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.UWP.CarouselPageRenderer" />
    public class IconCarouselRenderer : CarouselPageRenderer
    {

    }
}