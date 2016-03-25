using System;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CarouselPageRenderer = Xamarin.Forms.Platform.Android.AppCompat.CarouselPageRenderer;

[assembly: ExportRenderer(typeof(IconCarouselPage), typeof(IconCarouselRenderer))]
namespace FormsPlugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="IconCarouselRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.CarouselPageRenderer" />
    public class IconCarouselRenderer : CarouselPageRenderer
    {
        /// <summary>
        /// Disposes the specified disposing.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void Dispose(Boolean disposing)
        {
            if (Element != null)
            {
                Element.CurrentPageChanged -= OnPageChanged;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{CarouselPage}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<CarouselPage> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                Element.CurrentPageChanged += OnPageChanged;
            }
        }

        /// <summary>
        /// Called when [page changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void OnPageChanged(Object sender, EventArgs e)
        {
            Element?.UpdateToolbarItems(Context);
        }
    }
}