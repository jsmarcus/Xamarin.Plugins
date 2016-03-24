using System;
using Android.Graphics;
using Android.OS;
using Android.Text.Style;
using Java.Lang;

namespace Plugin.Iconize.Droid
{
    public class CustomTypefaceSpan : ReplacementSpan
    {
        private static readonly Int32 ROTATION_DURATION = 2000;
        private static readonly Rect TEXT_BOUNDS = new Rect();
        private static readonly Paint LOCAL_PAINT = new Paint();
        private static readonly Single BASELINE_RATIO = 1 / 7f;

        private readonly System.String _icon;
        private readonly Typeface _type;
        private readonly Single _iconSizePx;
        private readonly Single _iconSizeRatio;
        private readonly Int32 _iconColor;
        private readonly System.Boolean _rotate;
        private readonly System.Boolean _baselineAligned;
        private readonly Int64 _rotationStartTime;

        public System.Boolean IsAnimated => _rotate;

        public CustomTypefaceSpan(IIcon icon, Typeface type, Single iconSizePx, Single iconSizeRatio, Int32 iconColor, System.Boolean rotate, System.Boolean baselineAligned)
        {
            _rotate = rotate;
            _baselineAligned = baselineAligned;
            _icon = icon.Character.ToString();
            _type = type;
            _iconSizePx = iconSizePx;
            _iconSizeRatio = iconSizeRatio;
            _iconColor = iconColor;
            _rotationStartTime = SystemClock.CurrentThreadTimeMillis();
        }

        private void ApplyCustomTypeFace(Paint paint, Typeface tf)
        {
            paint.FakeBoldText = false;
            paint.TextSkewX = 0f;
            paint.SetTypeface(tf);
            if (_rotate)
                paint.ClearShadowLayer();
            if (_iconSizeRatio > 0)
                paint.TextSize = (paint.TextSize * _iconSizeRatio);
            else if (_iconSizePx > 0)
                paint.TextSize = _iconSizePx;
            if (_iconColor < Int32.MaxValue)
                paint.Color = new Color(_iconColor);
            paint.Flags = paint.Flags | PaintFlags.SubpixelText;
        }

        public override void Draw(Canvas canvas, ICharSequence text, Int32 start, Int32 end, Single x, Int32 top, Int32 y, Int32 bottom, Paint paint)
        {
            ApplyCustomTypeFace(paint, _type);
            paint.GetTextBounds(_icon, 0, 1, TEXT_BOUNDS);
            canvas.Save();
            var baselineRatio = _baselineAligned ? 0f : BASELINE_RATIO;
            if (_rotate)
            {
                var rotation = (SystemClock.CurrentThreadTimeMillis() - _rotationStartTime) / (Single)ROTATION_DURATION * 360f;
                var centerX = x + TEXT_BOUNDS.Width() / 2f;
                var centerY = y - TEXT_BOUNDS.Height() / 2f + TEXT_BOUNDS.Height() * baselineRatio;
                canvas.Rotate(rotation, centerX, centerY);
            }

            canvas.DrawText(_icon, x - TEXT_BOUNDS.Left, y - TEXT_BOUNDS.Bottom + TEXT_BOUNDS.Height() * baselineRatio, paint);
            canvas.Restore();
        }

        public override Int32 GetSize(Paint paint, ICharSequence text, Int32 start, Int32 end, Paint.FontMetricsInt fm)
        {
            LOCAL_PAINT.Set(paint);
            ApplyCustomTypeFace(LOCAL_PAINT, _type);
            LOCAL_PAINT.GetTextBounds(_icon, 0, 1, TEXT_BOUNDS);
            if (fm != null)
            {
                var baselineRatio = _baselineAligned ? 0 : BASELINE_RATIO;
                fm.Descent = (Int32)(TEXT_BOUNDS.Height() * baselineRatio);
                fm.Ascent = -(TEXT_BOUNDS.Height() - fm.Descent);
                fm.Top = fm.Ascent;
                fm.Bottom = fm.Descent;
            }
            return TEXT_BOUNDS.Width();
        }
    }
}