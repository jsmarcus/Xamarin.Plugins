using Android.Support.V4.View;
using View = Android.Views.View;

namespace Plugin.Iconize.Android
{
    /// <summary>
    /// Any TextView subclass that wishes to call <see cref="Iconize.AddIcons(TextView[])"/> on it
    /// needs to implement this interface if it ever want to use spinning icons.
    /// 
    /// IconTextView, IconButton and IconToggleButton already implement it, but if you need to implement it
    /// yourself, please use <see cref="HasOnViewAttachListenerDelegate"/>
    /// to help you.
    /// </summary>
    public interface IHasOnViewAttachListener
    {
        void SetOnViewAttachListener(IOnViewAttachListener listener);
    }

    public interface IOnViewAttachListener
    {
        void OnAttach();

        void OnDetach();
    }

    public class HasOnViewAttachListenerDelegate : IHasOnViewAttachListener
    {
        private readonly View _view;
        private IOnViewAttachListener _listener;

        public HasOnViewAttachListenerDelegate(View view)
        {
            _view = view;
        }

        public void SetOnViewAttachListener(IOnViewAttachListener listener)
        {
            if (_listener != null)
                _listener.OnDetach();
            _listener = listener;
            if (ViewCompat.IsAttachedToWindow(_view) && listener != null)
            {
                listener.OnAttach();
            }
        }

        public void OnAttachedToWindow()
        {
            if (_listener != null)
                _listener.OnAttach();
        }

        public void OnDetachedFromWindow()
        {
            if (_listener != null)
                _listener.OnDetach();
        }
    }
}