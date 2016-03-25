using System;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconCarouselPage), typeof(IconCarouselRenderer))]
namespace FormsPlugin.Iconize.iOS
{
    /// <summary>
    /// Defines the <see cref="IconCarouselRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.CarouselPageRenderer" />
    public class IconCarouselRenderer : CarouselPageRenderer
    {
        /// <summary>
        /// Disposes the specified disposing.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void Dispose(Boolean disposing)
        {
            if (Carousel != null)
            {
                Carousel.CurrentPageChanged -= OnPageChanged;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="VisualElementChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (Carousel != null)
            {
                Carousel.CurrentPageChanged += OnPageChanged;
            }
        }

        /// <summary>
        /// Called when [page changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OnPageChanged(Object sender, EventArgs e)
        {
            Carousel?.UpdateToolbarItems(NavigationController);
        }
    }
}