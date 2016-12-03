using System;
using System.Collections.Generic;
using System.Linq;
using AllContent_Client;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Square.Picasso;

namespace Android_Content
{
    public class NewsListFragment : Android.Support.V4.App.ListFragment
    {
        private FavoritList fv;

        // ¬Œ“ “”“ ¬—≈ ◊»—“Œ ƒÀﬂ “≈—“¿
        public static List<ContentUnit> list_cu; // ¬ÓÚ Ú‡Í ËÌÍ‡ÔÒÛÎˇˆËˇ Ë‰ÂÚ Ì‡ıÛÈ
        private uint test_cnt = 40;
        private void TestUnits()
        {
            
            for (int i = 0; i < test_cnt; ++i)
            {
                ContentUnit cu = new ContentUnit() { header = "KEK lol #" + i, description = "SNOVA KEK omgwtf plsno", imgUrl = "http://vignette3.wikia.nocookie.net/animeandmangauniverse/images/e/e5/Kallen_Kozuki.jpg/revision/latest?cb=20120129132316.jpg" };
                cu.date = (i % 31).ToString() + ".12.0000";
                cu.URL = "https://tjournal.ru/37885-v-saudovskoi-aravii-vipal-sneg";
                list_cu.Add(cu);
            }
        }
        ////////////////////////

       

     
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            fv = FavoritList.Favorits;
            ///// “Œ∆≈ ƒÀﬂ “≈—“¿ 
            list_cu = new List<ContentUnit>();
            TestUnits();
            ContentUnitAdapter adapter = new ContentUnitAdapter(Activity, list_cu);
            ListAdapter = adapter;
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ContentUnit cu = ((ContentUnitAdapter)ListAdapter).GetItem(position);
            Intent intent = new Intent(Activity, Java.Lang.Class.FromType(typeof(WebActivity)));
            intent.SetData(Android.Net.Uri.Parse(cu.URL));
            StartActivity(intent);
        }

    }
        
    class ContentUnitAdapter : ArrayAdapter<ContentUnit>
    {
        Activity activity;
        public ContentUnitAdapter(Activity _activity, List<ContentUnit> content_list) : base(_activity, 0, content_list)
        {
            activity = _activity;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            if (convertView == null)
                convertView = activity.LayoutInflater.Inflate(Resource.Layout.unit_list, null);
            ContentUnit cu = GetItem(position);
            ImageView iv = convertView.FindViewById<ImageView>(Resource.Id.content_imgImageView);
            Picasso.With(activity).Load(cu.imgUrl).Into(iv);
            
            TextView header = convertView.FindViewById<TextView>(Resource.Id.content_HeaderTextView);
            header.Text = cu.header;
            TextView description = convertView.FindViewById<TextView>(Resource.Id.content_DescriptionTextView);
            description.Text = cu.description;
            TextView date = convertView.FindViewById<TextView>(Resource.Id.content_DateTextView);
            date.Text = cu.date;
            return convertView;
        }
    }
}