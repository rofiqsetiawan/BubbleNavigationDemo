// Created by Rofiq Setiawan (rofiqsetiawan@gmail.com)

#nullable enable

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using R = Demo.Resource;

namespace Demo
{
    [Register("id.karamunting.bubblenavigationdemo.MainActivity")]
    [Activity(MainLauncher = true)]
    public sealed class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(R.Layout.activity_main);

            FindViewById<Button>(R.Id.open_top_navigation_bar)!.Click += (s, e) => LaunchTopBarActivity();

            FindViewById<Button>(R.Id.open_top_float_navigation_bar)!.Click += (s, e) => LaunchFloatingBarActivity();

            FindViewById<Button>(R.Id.open_bottom_equal_navigation_bar)!.Click += (s, e) => LaunchEqualBarActivity();

            FindViewById<Button>(R.Id.open_bottom_navigation_bar)!.Click += (s, e) => LaunchBottomBarActivity();
        }

        private void LaunchBottomBarActivity()
        {
            using var intent = new Intent(this, typeof(BottomBarActivity));
            StartActivity(intent);
        }

        private void LaunchFloatingBarActivity()
        {
            using var intent = new Intent(this, typeof(FloatingTopBarActivity));
            StartActivity(intent);
        }

        private void LaunchTopBarActivity()
        {
            using var intent = new Intent(this, typeof(TopBarActivity));
            StartActivity(intent);
        }

        private void LaunchEqualBarActivity()
        {
            using var intent = new Intent(this, typeof(EqualBottomBarActivity));
            StartActivity(intent);
        }
    }
}