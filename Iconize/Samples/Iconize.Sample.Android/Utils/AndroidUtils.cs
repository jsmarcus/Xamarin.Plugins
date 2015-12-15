using System;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;

namespace Iconize.Sample.Android.Utils
{
    public sealed class AndroidUtils
    {
        private AndroidUtils()
        {

        }

        /** Returns the available screensize, including status bar and navigation bar */
        public static Size GetScreenSize(Activity context)
        {
            var display = context.WindowManager.DefaultDisplay;
            int realWidth;
            int realHeight;

            if ((Int32)Build.VERSION.SdkInt >= 17)
            {
                var realMetrics = new DisplayMetrics();
                display.GetRealMetrics(realMetrics);
                realWidth = realMetrics.WidthPixels;
                realHeight = realMetrics.HeightPixels;
            }
            else if ((Int32)Build.VERSION.SdkInt >= 14)
            {
                try
                {
                    var displayClass = Java.Lang.Class.FromType(typeof(Display));
                    var mGetRawH = displayClass.GetMethod("getRawHeight");
                    var mGetRawW = displayClass.GetMethod("getRawWidth");
                    realWidth = (Int32)mGetRawW.Invoke(display);
                    realHeight = (Int32)mGetRawH.Invoke(display);
                }
                catch (Exception e)
                {
                    //this may not be 100% accurate, but it's all we've got
                    realWidth = display.Width;
                    realHeight = display.Height;
                    //Log.e("Display Info", "Couldn't use reflection to get the real display metrics.");
                }
            }
            else
            {
                //This should be close, as lower API devices should not have window navigation bars
                realWidth = display.Width;
                realHeight = display.Height;
            }

            return new Size(realWidth, realHeight);
        }

        public sealed class Size
        {
            public readonly Int32 Width;
            public readonly Int32 Height;

            public Size(Int32 width, Int32 height)
            {
                Width = width;
                Height = height;
            }
        }
    }
}