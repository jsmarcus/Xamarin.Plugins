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
        /// Called when [navigation].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs" /> instance containing the event data.</param>
        private void OnNavigation(Object sender, NavigationEventArgs e)
        {
            Navigation.UpdateToolbarItems();
        }

        /// <summary>
        /// Views the did appear.
        /// </summary>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        public override void ViewDidAppear(Boolean animated)
        {
            base.ViewDidAppear(animated);

            if (Navigation != null)
            {
                Navigation.Popped += OnNavigation;
                Navigation.PoppedToRoot += OnNavigation;
                Navigation.Pushed += OnNavigation;
                Navigation.UpdateToolbarItems();
            }
        }

        /// <summary>
        /// Views the did disappear.
        /// </summary>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        public override void ViewDidDisappear(Boolean animated)
        {
            if (Navigation != null)
            {
                Navigation.Popped -= OnNavigation;
                Navigation.PoppedToRoot -= OnNavigation;
                Navigation.Pushed -= OnNavigation;
            }

            base.ViewDidDisappear(animated);
        }
    }
}