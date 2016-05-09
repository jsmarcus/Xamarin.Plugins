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
        /// Called when [attached to window].
        /// </summary>
        protected override void OnAttachedToWindow()
        {
            MessagingCenter.Subscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage, OnUpdateToolbarItems);
            (Context as FormsAppCompatActivity).ConfigurationChanged += OnConfigurationChanged;
            OnUpdateToolbarItems(this);

            base.OnAttachedToWindow();
        }

        /// <summary>
        /// Called when [configuration changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnConfigurationChanged(Object sender, EventArgs e)
        {
            OnUpdateToolbarItems(this);
        }

        /// <summary>
        /// Called when [detached from window].
        /// </summary>
        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();

            (Context as FormsAppCompatActivity).ConfigurationChanged -= OnConfigurationChanged;
            MessagingCenter.Unsubscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage);
        }

        /// <summary>
        /// Called when [update toolbar items].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void OnUpdateToolbarItems(Object sender)
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                Element?.UpdateToolbarItems(Context);
                return false;
            });
        }
    }
}