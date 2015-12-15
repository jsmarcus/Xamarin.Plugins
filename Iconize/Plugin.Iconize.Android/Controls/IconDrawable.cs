using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using R = Android.Resource;

namespace Plugin.Iconize.Android.Controls
{
    public class IconDrawable : Drawable
    {
        public static readonly Int32 ANDROID_ACTIONBAR_ICON_SIZE_DP = 24;

        private Context _context;

        private IIcon _icon;

        private TextPaint _paint;

        private Int32 _size = -1;

        private Int32 _alpha = 255;

        /// <summary>
        /// Create an <see cref="IconDrawable"/>.
        /// </summary>
        /// <param name="context">Your activity or application context.</param>
        /// <param name="iconKey">The icon key you want this drawable to display.</param>
        /// <exception cref="ArgumentException">If the key doesn't match any icon.</exception>
        public IconDrawable(Context context, String iconKey)
        {
            var icon = Iconize.FindIconForKey(iconKey);
            if (icon == null)
            {
                throw new ArgumentException("No icon with that key \"" + iconKey + "\".");
            }
            Init(context, icon);
        }

        /// <summary>
        /// Create an <see cref="IconDrawable"/>.
        /// </summary>
        /// <param name="context">Your activity or application context.</param>
        /// <param name="icon">The icon you want this drawable to display.</param>
        public IconDrawable(Context context, IIcon icon)
        {
            Init(context, icon);
        }

        private void Init(Context context, IIcon icon)
        {
            _context = context;
            _icon = icon;
            _paint = new TextPaint();
            var module = Iconize.FindModuleOf(icon);
            if (module == null)
            {
                throw new Java.Lang.IllegalStateException("Unable to find the module associated " +
                        "with icon " + icon.Key + ", have you registered the module " +
                        "you are trying to use with Iconize.With(...) in your Application?");
            }
            _paint.SetTypeface(module.GetTypeface(context));
            _paint.SetStyle(Paint.Style.Fill);
            _paint.TextAlign = Paint.Align.Center;
            _paint.UnderlineText = false;
            _paint.Color = global::Android.Graphics.Color.Black;
            _paint.AntiAlias = true;
        }

        /// <summary>
        /// Set the size of this icon to the standard Android ActionBar.
        /// </summary>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable ActionBarSize()
        {
            return SizeDp(ANDROID_ACTIONBAR_ICON_SIZE_DP);
        }

        /// <summary>
        /// Set the size of the drawable.
        /// </summary>
        /// <param name="dimenRes">The dimension resource.</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable SizeRes(Int32 dimenRes)
        {
            return SizePx(_context.Resources.GetDimensionPixelSize(dimenRes));
        }

        /// <summary>
        /// Set the size of the drawable.
        /// </summary>
        /// <param name="size">The size in density-independent pixels (dp).</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable SizeDp(Int32 size)
        {
            return SizePx(ConvertDpToPx(_context, size));
        }

        /// <summary>
        /// Set the size of the drawable.
        /// </summary>
        /// <param name="size">The size in pixels (px).</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable SizePx(Int32 size)
        {
            _size = size;
            SetBounds(0, 0, size, size);
            InvalidateSelf();
            return this;
        }

        /// <summary>
        /// Set the color of the drawable.
        /// </summary>
        /// <param name="color">The color, usually from android.graphics.Color or 0xFF012345.</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable Color(Int32 color)
        {
            _paint.Color = new Color(color);
            InvalidateSelf();
            return this;
        }

        /// <summary>
        /// Set the color of the drawable.
        /// </summary>
        /// <param name="colorRes">The color resource, from your R file.</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public IconDrawable ColorRes(Int32 colorRes)
        {
            _paint.Color = _context.Resources.GetColor(colorRes);
            InvalidateSelf();
            return this;
        }

        /// <summary>
        /// Set the alpha of this drawable.
        /// </summary>
        /// <param name="alpha">The alpha, between 0 (transparent) and 255 (opaque).</param>
        /// <returns>The current IconDrawable for chaining.</returns>
        public new IconDrawable Alpha(Int32 alpha)
        {
            SetAlpha(alpha);
            InvalidateSelf();
            return this;
        }

        public override Int32 IntrinsicHeight
        {
            get { return _size; }
        }

        public override Int32 IntrinsicWidth
        {
            get { return _size; }
        }

        public override void Draw(Canvas canvas)
        {
            var bounds = Bounds;
            var height = bounds.Height();
            _paint.TextSize = height;
            var textBounds = new Rect();
            var textValue = _icon.Character.ToString();
            _paint.GetTextBounds(textValue, 0, 1, textBounds);
            var textHeight = textBounds.Height();
            var textBottom = bounds.Top + (height - textHeight) / 2f + textHeight - textBounds.Bottom;
            canvas.DrawText(textValue, bounds.ExactCenterX(), textBottom, _paint);
        }

        public override Boolean IsStateful
        {
            get { return true; }
        }

        public override Boolean SetState(Int32[] stateSet)
        {
            var oldValue = _paint.Alpha;
            var newValue = IsEnabled(stateSet) ? _alpha : _alpha / 2;
            _paint.Alpha = newValue;
            return oldValue != newValue;
        }

        public override void SetAlpha(Int32 alpha)
        {
            _alpha = alpha;
            _paint.Alpha = alpha;
        }

        public override void SetColorFilter(ColorFilter colorFilter)
        {
            _paint.SetColorFilter(colorFilter);
        }

        public override void ClearColorFilter()
        {
            _paint.SetColorFilter(null);
        }

        public override Int32 Opacity
        {
            get { return _alpha; }
        }

        /// <summary>
        /// Sets paint style.
        /// </summary>
        /// <param name="style">The style to be applied.</param>
        public void SetStyle(Paint.Style style)
        {
            _paint.SetStyle(style);
        }

        // Util
        private Boolean IsEnabled(Int32[] stateSet)
        {
            foreach (var state in stateSet)
                if (state == R.Attribute.StateEnabled)
                    return true;
            return false;
        }

        // Util
        private Int32 ConvertDpToPx(Context context, Single dp)
        {
            return (Int32)TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, context.Resources.DisplayMetrics);
        }
    }
}