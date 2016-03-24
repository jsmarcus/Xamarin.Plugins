using System;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconTabbedPage), typeof(IconTabbedRenderer))]
namespace FormsPlugin.Iconize.iOS
{
    /// <summary>
    /// Defines the <see cref="IconTabbedRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.TabbedRenderer" />
    public class IconTabbedRenderer : TabbedRenderer
    {
        /// <summary>
        /// Called when [page changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OnPageChanged(Object sender, EventArgs e)
        {
            Tabbed.UpdateToolbarItems();
        }

        /// <summary>
        /// Views the did appear.
        /// </summary>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        public override void ViewDidAppear(Boolean animated)
        {
            base.ViewDidAppear(animated);

            if (Tabbed != null)
            {
                Tabbed.CurrentPageChanged += OnPageChanged;
                Tabbed.UpdateToolbarItems();
            }
        }

        /// <summary>
        /// Views the did disappear.
        /// </summary>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        public override void ViewDidDisappear(Boolean animated)
        {
            if (Tabbed != null)
            {
                Tabbed.CurrentPageChanged -= OnPageChanged;
            }

            base.ViewDidDisappear(animated);
        }
    }
}