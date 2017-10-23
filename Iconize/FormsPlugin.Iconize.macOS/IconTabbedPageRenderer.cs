using System;
using System.Collections.Generic;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.macOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using System.Linq;
using Plugin.Iconize.macOS;

[assembly: ExportRenderer(typeof(IconTabbedPage), typeof(IconTabbedPageRenderer))]
namespace FormsPlugin.Iconize.macOS
{
    public class IconTabbedPageRenderer : TabbedPageRenderer
    {
		private readonly List<String> _icons = new List<String>();

		/// <summary>
		/// Raises the <see cref="E:ElementChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="VisualElementChangedEventArgs" /> instance containing the event data.</param>
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			_icons.Clear();
			if (e.NewElement != null)
			{
				foreach (var page in ((TabbedPage)e.NewElement).Children)
				{
					_icons.Add(page.Icon.File);
					page.Icon = null;
				}
			}

			base.OnElementChanged(e);
		}

		public override void ViewWillAppear()
		{
			base.ViewWillAppear();

            for (int i = 0; i < TabView.Items.Count(); i++)
            {
                var icon = Plugin.Iconize.Iconize.FindIconForKey(_icons?[i]);
                if (icon == null)
                    continue;

                using (var image = icon.ToNSImage(18))
				{
                    TabView.Items[i].Image = image;
				}
			}
		}
    }
}
