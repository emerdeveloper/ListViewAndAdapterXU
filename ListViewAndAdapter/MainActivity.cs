using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ListViewAndAdapter
{
    [Activity(Label = "ListViewAndAdapter", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var instructorList = FindViewById<ListView>(Resource.Id.instructorListView);

            var adapter = new ArrayAdapter<Instructor>(this,//context
                Android.Resource.Layout.SimpleListItem1,//The id of the layout file to use for the row
                InstructorData.Instructor);//The collection of instructors

            //Load the ArrayAdapter into the Adapter property of the ListView
            instructorList.Adapter = adapter;
        }
    }
}

