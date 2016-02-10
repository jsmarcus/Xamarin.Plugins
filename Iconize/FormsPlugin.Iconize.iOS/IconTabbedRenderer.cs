using System;
using Xamarin.Forms.Platform.iOS;

namespace FormsPlugin.Iconize.iOS
{
    public class IconTabbedRenderer : TabbedRenderer
    {
        private void OnPageChanged(Object sender, EventArgs e)
        {
            Tabbed.UpdateToolbarItems();
        }

        public override void ViewDidAppear(Boolean animated)
        {
            base.ViewDidAppear(animated);

            if (Tabbed != null)
            {
                Tabbed.CurrentPageChanged += OnPageChanged;
                Tabbed.UpdateToolbarItems();
            }
        }

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