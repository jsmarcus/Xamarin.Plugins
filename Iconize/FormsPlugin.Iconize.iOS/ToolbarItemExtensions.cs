using System.Collections.Generic;
using Plugin.Iconize.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace FormsPlugin.Iconize.iOS
{
    /// <summary>
    /// Defines the <see cref="ToolbarItemExtensions" /> extensions.
    /// </summary>
    public static class ToolbarItemExtensions
    {
        ///// <summary>
        ///// Finds the view.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="controller">The controller.</param>
        ///// <returns></returns>
        //public static T FindView<T>(this UIViewController controller)
        //    where T : UIViewController
        //{
        //    if (controller == null)
        //        return null;

        //    if (controller is T)
        //        return controller as T;

        //    if (controller.ChildViewControllers.Length != 0)
        //    {
        //        for (var i = 0; i < controller.ChildViewControllers.Length; i++)
        //        {
        //            var child = controller.ChildViewControllers[i];
        //            if (child is T)
        //                return child as T;

        //            var view = FindView<T>(child);
        //            if (view != null)
        //                return view;
        //        }
        //    }

        //    return null;
        //}

        /// <summary>
        /// Updates the toolbar items.
        /// </summary>
        /// <param name="page">The page.</param>
        public static void UpdateToolbarItems(this Page page, UINavigationController controller)
        {
            //if (UIApplication.SharedApplication.Windows.Length == 0)
            //    return;

            //var navController = FindView<UINavigationController>(UIApplication.SharedApplication.Windows[0].RootViewController);

            var navController = controller.TopViewController;

            if (navController == null)
                return;

            if (navController.NavigationItem.RightBarButtonItems != null)
            {
                for (var i = 0; i < navController.NavigationItem.RightBarButtonItems.Length; ++i)
                    navController.NavigationItem.RightBarButtonItems[i].Dispose();
            }

            if (navController.ToolbarItems != null)
            {
                for (var i = 0; i < navController.ToolbarItems.Length; ++i)
                    navController.ToolbarItems[i].Dispose();
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
                        barButtonItem.Image = Plugin.Iconize.Iconize.FindIconForKey(iconItem.Icon).ToUIImage(24).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
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

                navController.NavigationItem.SetRightBarButtonItems(list1 == null ? new UIBarButtonItem[0] : list1.ToArray(), false);
                navController.ToolbarItems = (list2 == null ? new UIBarButtonItem[0] : list2.ToArray());
            }
        }
    }
}