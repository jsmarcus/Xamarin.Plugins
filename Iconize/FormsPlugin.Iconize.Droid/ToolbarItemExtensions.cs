using System;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Plugin.Iconize.Droid;
using Plugin.Iconize.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FormsPlugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="ToolbarItemExtensions" /> extensions.
    /// </summary>
    public static class ToolbarItemExtensions
    {
        /// <summary>
        /// Updates the toolbar items.
        /// </summary>
        /// <param name="page">The page.</param>
        public static void UpdateToolbarItems(this Page page, Context context)
        {
            var toolbar = (context as Activity)?.FindViewById<Toolbar>(IconControls.ToolbarId);
            if (toolbar != null)
            {
                toolbar.Menu.Clear();

                var toolbarItems = page.GetToolbarItems();
                if (toolbarItems != null)
                {
                    foreach (var toolbarItem in toolbarItems)
                    {
                        var menuItem = toolbar.Menu.Add(toolbarItem.Text);
                        menuItem.SetOnMenuItemClickListener(new MenuClickListener(toolbarItem.Activate));

                        if (String.IsNullOrEmpty(toolbarItem.Icon) == false)
                        {
                            if (toolbarItem is IconToolbarItem)
                            {
                                var iconItem = toolbarItem as IconToolbarItem;
                                var drawable = new IconDrawable(toolbar.Context, iconItem.Icon);
                                if (drawable != null)
                                {
                                    if (iconItem.IconColor != Color.Default)
                                        drawable = drawable.Color(iconItem.IconColor.ToAndroid());

                                    menuItem.SetIcon(drawable.ActionBarSize());
                                }
                            }
                            else
                            {
                                var drawable = ResourceManager.GetDrawable(toolbar.Context.Resources, toolbarItem.Icon);
                                if (drawable != null)
                                    menuItem.SetIcon(drawable);
                            }
                        }

                        if (toolbarItem.Order != ToolbarItemOrder.Secondary)
                        {
                            menuItem.SetShowAsAction(ShowAsAction.Always);
                        }
                    }
                }
            }
        }
    }
}