using System;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(IconTabbedPage), typeof(IconTabbedRenderer))]
namespace FormsPlugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="IconTabbedRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.TabbedPageRenderer" />
    public class IconTabbedRenderer : TabbedPageRenderer
    {
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
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
        /// <param name="e">The <see cref="ElementChangedEventArgs{TabbedPage}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
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