using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;

namespace ListViewAndAdapter
{
    /**
     * this class creates a Drawable from an image file packaged as an Android Asset. 
     * It maintains a dictionary keyed by the image filename so it will create exactly one copy of each image.
     * */
    public static class ImageAssetManager
    {
        static Dictionary<string, Drawable> cache = new Dictionary<string, Drawable>();

        //we pass it a Context and a path relative to your Assets folder and it returns the file as a Drawable.
        public static Drawable Get(Context context, string url)
        {
            if (!cache.ContainsKey(url))
            {
                var drawable = Drawable.CreateFromStream(context.Assets.Open(url), null);

                cache.Add(url, drawable);
            }

            return cache[url];
        }
    }
}