using System;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(IconNavigationPage), typeof(IconNavigationRenderer))]
namespace FormsPlugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="IconNavigationRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer" />
    public class IconNavigationRenderer : NavigationPageRenderer
    {
        /// <summary>
        /// Disposes the specified disposing.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void Dispose(Boolean disposing)
        {
            if (Element != null)
            {
                Element.Popped -= OnNavigation;
                Element.PoppedToRoot -= OnNavigation;
                Element.Pushed -= OnNavigation;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Called when [attached to window].
        /// </summary>
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            if (Element != null)
            {
                Element.UpdateToolbarItems(Context);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{NavigationPage}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                Element.Popped += OnNavigation;
                Element.PoppedToRoot += OnNavigation;
                Element.Pushed += OnNavigation;
            }
        }

        /// <summary>
        /// Called when [navigation].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs" /> instance containing the event data.</param>
        private void OnNavigation(Object sender, NavigationEventArgs e)
        {
            Element?.UpdateToolbarItems(Context);
        }
    }
}