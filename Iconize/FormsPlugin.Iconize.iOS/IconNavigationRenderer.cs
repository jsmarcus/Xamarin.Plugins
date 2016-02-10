using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace FormsPlugin.Iconize.iOS
{
    public class IconNavigationRenderer : NavigationRenderer
    {
        protected NavigationPage Navigation => Element as NavigationPage;

        private void OnNavigation(Object sender, NavigationEventArgs e)
        {
            Navigation.UpdateToolbarItems();
        }

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