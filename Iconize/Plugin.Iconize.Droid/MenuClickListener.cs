using System;
using Android.Runtime;
using Android.Views;

namespace Plugin.Iconize.Droid
{
    public class MenuClickListener : Java.Lang.Object, IMenuItemOnMenuItemClickListener, IJavaObject, IDisposable
    {
        private readonly Action _callback;

        public MenuClickListener(Action callback)
        {
            _callback = callback;
        }

        public bool OnMenuItemClick(IMenuItem item)
        {
            _callback?.Invoke();
            return true;
        }
    }
}