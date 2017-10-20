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

		/// <summary>
		/// Called prior to the <see cref="P:UIKit.UIViewController.View" /> being added to the view hierarchy.
		/// </summary>
		/// <param name="animated">If the appearance will be animated.</param>
		/// <remarks>
		/// <para>This method is called prior to the <see cref="T:UIKit.UIView" /> that is this <see cref="T:UIKit.UIViewController" />’s <see cref="P:UIKit.UIViewController.View" /> property being added to the display <see cref="T:UIKit.UIView" /> hierarchy. </para>
		/// <para>Application developers who override this method must call <c>base.ViewWillAppear()</c> in their overridden method.</para>
		/// </remarks>


		public override void ViewWillAppear()
		{
			base.ViewWillAppear();

            for (int i = 0; i < TabView.Items.Count(); i++)
            {
                var icon = Plugin.Iconize.Iconize.FindIconForKey(_icons?[i]);
                if (icon == null)
                    continue;

                using (var image = icon.ToNSImage(25))
				{
                    TabView.Items[i].Image = image;
				  //tab.SelectedImage = image;
				}
			}

            foreach (var tab in TabView.Items)
			{
    //            var icon = Plugin.Iconize.Iconize.FindIconForKey(_icons?[(Int32)tab]);
				//if (icon == null)
				//	continue;

				//using (var image = icon.ToUIImage(25))
				//{
				//	tab.Image = image;
				//	//tab.SelectedImage = image;
				//}
			}
		}
    }
}
