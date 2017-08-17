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

namespace ListViewAndAdapter
{
    /**
     * contains a class that contains nothing but three properties, one for each view in the InstructorRow.axml layout file.
     * This will be used to implement the view-holder pattern.
     * Notice that its base class is Java.Lang.Object; 
     * this is required to store an instance of this class in the Tag field of a view.
     * */
    public class ViewHolder : Java.Lang.Object
    {
        public ImageView Photo { get; set; }
        public TextView Name { get; set; }
        public TextView Specialty { get; set; }
    }
}