using System;
using Android.Support.V4.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using Android.Views;
using Android.App;

namespace Android_Content
{
    [Activity(Label = "Android_Content", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        ViewPager viewPager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.MainLayout);

            viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            
            viewPager.Adapter = new FragAdapter(SupportFragmentManager);
        }
        
    }

    public class FragAdapter : FragmentPagerAdapter
    {

        public FragAdapter (Android.Support.V4.App.FragmentManager fm) : base(fm)
        {

        }

        public override int Count
        {
            get
            {
                return 2;  
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return new Frag();
        }

    }

    public class Frag : Android.Support.V4.App.Fragment
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.frag, container, false);
            return view;
        }

    }

}

