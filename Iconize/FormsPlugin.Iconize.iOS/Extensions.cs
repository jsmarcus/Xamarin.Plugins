using System.Collections.Generic;
using Plugin.Iconize.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace FormsPlugin.Iconize.iOS
{
    public static class Extensions
    {
        public static void UpdateToolbarItems(this Page page)
        {
            if (UIApplication.SharedApplication.Windows.Length == 0)
                return;

            if (UIApplication.SharedApplication.Windows[0].RootViewController.ChildViewControllers.Length == 0)
                return;

            var viewController = (UIApplication.SharedApplication.Windows[0].RootViewController.ChildViewControllers[0] as UINavigationController).TopViewController;

            if (viewController.NavigationItem.RightBarButtonItems != null)
            {
                foreach (var item in viewController.NavigationItem.RightBarButtonItems)
                {
                    item.Dispose();
                }
            }

            if (viewController.ToolbarItems != null)
            {
                foreach (var item in viewController.ToolbarItems)
                {
                    item.Dispose();
                }
            }

            var toolbarItems = page.GetToolbarItems();

            if (toolbarItems != null)
            {
                var list1 = (List<UIBarButtonItem>)null;
                var list2 = (List<UIBarButtonItem>)null;

                foreach (var toolbarItem in toolbarItems)
                {
                    var barButtonItem = toolbarItem.ToUIBarButtonItem(toolbarItem.Order == ToolbarItemOrder.Secondary);
                    if (toolbarItem is IconToolbarItem)
                    {
                        var iconItem = toolbarItem as IconToolbarItem;
                        barButtonItem.Image = Plugin.Iconize.Iconize.FindIconForKey(iconItem.Icon).ToUIImage(22);
                        if (iconItem.IconColor != Color.Default)
                            barButtonItem.TintColor = iconItem.IconColor.ToUIColor();
                    }

                    if (toolbarItem.Order == ToolbarItemOrder.Secondary)
                        (list2 = list2 ?? new List<UIBarButtonItem>()).Add(barButtonItem);
                    else
                        (list1 = list1 ?? new List<UIBarButtonItem>()).Add(barButtonItem);
                }

                if (list1 != null)
                    list1.Reverse();

                viewController.NavigationItem.SetRightBarButtonItems(list1 == null ? new UIBarButtonItem[0] : list1.ToArray(), false);
                viewController.ToolbarItems = (list2 == null ? new UIBarButtonItem[0] : list2.ToArray());
            }
        }

        private static IList<ToolbarItem> GetToolbarItems(this Page page)
        {
            if (page is IPageContainer<Page>)
                return (page as IPageContainer<Page>).CurrentPage?.GetToolbarItems();

            return page.ToolbarItems;
        }
    }
}