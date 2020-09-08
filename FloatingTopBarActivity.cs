// Created by Rofiq Setiawan (rofiqsetiawan@gmail.com)

#nullable enable

using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Demo.Adapters;
using Demo.Fragments;
using Gauravk.BubbleNavigation;
using System.Collections.Generic;
using R = Demo.Resource;

namespace Demo
{
    [Register("id.karamunting.bubblenavigationdemo.FloatingTopBarActivity")]
    [Activity]
    public class FloatingTopBarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(R.Layout.activity_floating_top_bar);

            var floatingTopBarNavigation =
                FindViewById<BubbleNavigationConstraintView>(R.Id.floating_top_bar_navigation)!;
            floatingTopBarNavigation.SetTypeface(Typeface.CreateFromAsset(Assets, "rubik.ttf"));
            floatingTopBarNavigation.SetBadgeValue(0, "3");
            floatingTopBarNavigation.SetBadgeValue(1, "9+"); // Invisible badge

            var fragList = new List<ScreenSlidePageFragment>
            {
                ScreenSlidePageFragment.NewInstance(GetString(R.String.home), R.Color.red_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.search), R.Color.blue_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.likes), R.Color.blue_grey_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.notification), R.Color.green_inactive)
            };
            var pagerAdapter = new ScreenSlidePagerAdapter(fragList, SupportFragmentManager);

            var viewPager = FindViewById<ViewPager>(R.Id.view_pager)!;
            viewPager.Adapter = pagerAdapter;

            // Disable swipe
            viewPager.SetOnTouchListener(
                new MyViewOnTouchListener((v, motionEvent) => true)
            );

            floatingTopBarNavigation.NavigationChange += (s, e) => viewPager.SetCurrentItem(e.Position, true);
        }
    }
}