using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Java.Lang;

namespace Plugin.Iconize.Droid.Controls
{
    public class IconToggleButton : ToggleButton, IHasOnViewAttachListener
    {
        private HasOnViewAttachListenerDelegate _delegate;

        public IconToggleButton(Context context)
            : base(context)
        {
            Init();
        }

        public IconToggleButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Init();
        }

        public IconToggleButton(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            Init();
        }

        public IconToggleButton(Context context, IAttributeSet attrs, Int32 defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            Init();
        }

        private void Init()
        {
            TransformationMethod = null;
        }

        public override void SetText(ICharSequence text, BufferType type)
        {
            base.SetText(this.Compute(Context, text, TextSize), type);
        }

        public void SetOnViewAttachListener(IOnViewAttachListener listener)
        {
            if (_delegate == null)
                _delegate = new HasOnViewAttachListenerDelegate(this);
            _delegate.SetOnViewAttachListener(listener);
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            _delegate.OnAttachedToWindow();
        }

        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            _delegate.OnDetachedFromWindow();
        }
    }
}