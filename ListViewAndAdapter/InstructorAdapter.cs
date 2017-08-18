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
using Java.Lang;

namespace ListViewAndAdapter
{
    public class InstructorAdapter : BaseAdapter<Instructor> , ISectionIndexer
    {
        //Collect of Instructor that will be pass to Constructor
        List<Instructor> Instructors;
        //theses will be useful to use in the methods of ISectionIndexer
        Java.Lang.Object[] sectionHeaders;
        Dictionary<int, int> positionForSectionMap;
        Dictionary<int, int> sectionForPositionMap;
        //Constructor
        //We reference to the collection of instructor
        public InstructorAdapter(List<Instructor> Instructors) {
            this.Instructors = Instructors;

            //Call each of the three SectionIndexerBuilder methods and store the results in fields inside your adapter class.
            sectionHeaders = SectionIndexerBuilder.BuildSectionHeaders(Instructors);
            positionForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap(Instructors);
            sectionForPositionMap = SectionIndexerBuilder.BuildSectionForPositionMap(Instructors);
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

        //methods of ISectionIndexer
        //We use the three variables that declarate above to retun in this methods
        public int GetPositionForSection(int sectionIndex)
        {
            return positionForSectionMap[sectionIndex];
        }

        public int GetSectionForPosition(int position)
        {
            return sectionForPositionMap[position];
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionHeaders;
        }
    }
}