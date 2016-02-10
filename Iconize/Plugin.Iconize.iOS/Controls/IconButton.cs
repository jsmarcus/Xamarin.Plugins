using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Plugin.Iconize.iOS.Controls
{
    public class IconButton : UIButton
    {
        public IconButton()
        {
            // Intentionally left blank
        }

        public IconButton(NSCoder coder)
            : base(coder)
        {
            // Intentionally left blank
        }

        public IconButton(CGRect frame)
            : base(frame)
        {
            // Intentionally left blank
        }

        public override String Title(UIControlState state)
        {
            return base.GetAttributedTitle(state).Value;
        }

        public override void SetTitle(String title, UIControlState forState)
        {
            base.SetAttributedTitle(this.Compute(title, Font.PointSize), forState);
        }
    }
}