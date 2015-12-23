using System;
using FormsPlugin.Iconize.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(IconTabbedRenderer))]
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