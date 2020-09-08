// Created by Rofiq Setiawan (rofiqsetiawan@gmail.com)

#nullable enable

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Demo.Fragments;
using Fragment = Android.Support.V4.App.Fragment;
using R = Demo.Resource;

namespace Demo
{
    [Register("id.karamunting.bubblenavigationdemo.EqualBottomBarActivity")]
    [Activity]
    public class EqualBottomBarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(R.Layout.activity_equal_bottom_bar);

            var fragment = SupportFragmentManager.FindFragmentById(R.Id.content_frame) as EqualBottomBarFragment;
            if (fragment == null)
            {
                fragment = new EqualBottomBarFragment();
                AddFragment(fragment, R.Id.content_frame);
            }
        }

        private void AddFragment(Fragment fragment, int id)
        {
            SupportFragmentManager.BeginTransaction()
                .Add(id, fragment)
                .Commit();
        }
    }
}