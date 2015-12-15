using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Plugin.Iconize.iOS.Controls
{
    public class IconLabel : UILabel
    {
        public IconLabel()
        {
            // Intentionally left blank
        }

        public IconLabel(NSCoder coder)
            : base(coder)
        {
            // Intentionally left blank
        }

        public IconLabel(CGRect frame)
            : base(frame)
        {
            // Intentionally left blank
        }

        public override String Text
        {
            get { return base.AttributedText.Value; }
            set { base.AttributedText = this.Compute(value); }
        }
    }
}