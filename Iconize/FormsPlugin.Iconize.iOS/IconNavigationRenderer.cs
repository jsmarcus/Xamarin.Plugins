using System;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconNavigationPage), typeof(IconNavigationRenderer))]
namespace FormsPlugin.Iconize.iOS
{
    /// <summary>
    /// Defines the <see cref="IconNavigationRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.NavigationRenderer" />
    public class IconNavigationRenderer : NavigationRenderer
    {
        /// <summary>
        /// Gets the navigation.
        /// </summary>
        /// <value>
        /// The navigation.
        /// </value>
        protected NavigationPage Navigation => Element as NavigationPage;

        /// <summary>
        /// Disposes the specified disposing.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void Dispose(Boolean disposing)
        {
            if (Navigation != null)
            {
                Navigation.Popped -= OnNavigation;
                Navigation.PoppedToRoot -= OnNavigation;
                Navigation.Pushed -= OnNavigation;
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

            if (Navigation != null)
            {
                Navigation.Popped += OnNavigation;
                Navigation.PoppedToRoot += OnNavigation;
                Navigation.Pushed += OnNavigation;
            }
        }

        public override void ViewDidAppear(Boolean animated)
        {
            base.ViewDidAppear(animated);

            Navigation?.UpdateToolbarItems(this);
        }

        /// <summary>
        /// Called when [navigation].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs" /> instance containing the event data.</param>
        private void OnNavigation(Object sender, NavigationEventArgs e)
        {
            Navigation?.UpdateToolbarItems(this);
        }
    }
}