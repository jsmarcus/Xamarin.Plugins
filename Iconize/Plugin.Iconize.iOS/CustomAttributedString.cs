using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Plugin.Iconize.iOS
{
    public class CustomAttributedString : NSAttributedString
    {
        private static readonly Int32 ROTATION_DURATION = 2000;
        private static readonly CGRect TEXT_BOUNDS = new CGRect();
        //private static readonly Paint LOCAL_PAINT = new Paint();
        private static readonly Single BASELINE_RATIO = 1 / 7f;

        private readonly String _icon;
        private readonly UIFont _font;
        private readonly Single _iconSizePx;
        private readonly Single _iconSizeRatio;
        private readonly UIColor _iconColor;
        private readonly Boolean _rotate;
        private readonly Boolean _baselineAligned;
        private readonly Int64 _rotationStartTime;

        public CustomAttributedString(IIcon icon, UIFont font, Single iconSizePx, Single iconSizeRatio, UIColor iconColor, Boolean rotate, Boolean baselineAligned)
        {
            _rotate = rotate;
            _baselineAligned = baselineAligned;
            _icon = icon.Character.ToString();
            _font = font;
            _iconSizePx = iconSizePx;
            _iconSizeRatio = iconSizeRatio;
            _iconColor = iconColor;
            _rotationStartTime = DateTime.Now.Ticks;

            var opt = new UIStringAttributes
            {
                Font = font
            };
            if (baselineAligned == true)
                opt.BaselineOffset = 0f;
            if (iconColor != UIColor.DarkTextColor)
                opt.ForegroundColor = iconColor;
        }
    }
}
