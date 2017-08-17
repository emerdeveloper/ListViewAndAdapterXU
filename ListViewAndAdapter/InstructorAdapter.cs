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
using System.IO;
using Android.Graphics.Drawables;

namespace ListViewAndAdapter
{
    public class InstructorAdapter : BaseAdapter<Instructor>
    {
        //Collect of Instructor that will be pass to Constructor
        List<Instructor> Instructors;

        //Constructor
        //We reference to the collection of instructor
        public InstructorAdapter(List<Instructor> Instructors) {
            this.Instructors = Instructors;
        }

        //it takes an integer position and returns the instructor at that position in the list
        public override Instructor this[int position] {
            get {
                return Instructors[position];
            }
        }

        //It should return the number of instructors in the list
        public override int Count {
            get {
                return Instructors.Count;
            }
        }

        //Use the instructor's position in the list as its id (this means you can just return the input argument as the result of this method)
        //going content the information about the collection
        public override long GetItemId(int position)
        {
            return position;
        }

        //This will be who generate of rows to listView
        //We use Inflater Access
        public override View GetView(int position, 
            View convertView, //this is a layout
            ViewGroup parent)//The ViewGroup that will contain your inflated layout, //thos content a context
        {
            //our Adapter need a inflater
            var inflater = LayoutInflater.From(parent.Context);
            //var view = inflater.Inflate(Resource.Layout.InstructorRow, parent, false);

            var view = convertView;

            if (view == null) {
                view = inflater.Inflate(Resource.Layout.InstructorRow, parent, false);

                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var specialty = view.FindViewById<TextView>(Resource.Id.specialtyTextView);

                //View has a Tag property you can use to store any extra info you need
                //the object ViewHolder populate it with the view references, and store it in the Tag property of the layout. 
                view.Tag = new ViewHolder()
                {
                    Photo = photo,
                    Name = name,
                    Specialty = specialty,
                };
            }
            var holder = (ViewHolder)view.Tag;

            //Get Images
            /** Stream stream = parent.Context.Assets.Open(Instructors[position].ImageUrl);
             Drawable drawable = Drawable.CreateFromStream(stream, null);
             photo.SetImageDrawable(drawable);*/

            //Now we want to populate the views with our code-behind data, 
            //we use the references in the holder instead of looking them up again with FindViewById.
            holder.Photo.SetImageDrawable(ImageAssetManager.Get(parent.Context,Instructors[position].ImageUrl));
            holder.Name.Text = Instructors[position].Name;
            holder.Specialty.Text = Instructors[position].Specialty;

            return view;
        }
    }
}