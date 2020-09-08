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
    [Register("id.karamunting.bubblenavigationdemo.BottomBarActivity")]
    [Activity]
    public class BottomBarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(R.Layout.activity_bottom_bar);

            var fragList = new List<ScreenSlidePageFragment>
            {
                ScreenSlidePageFragment.NewInstance(GetString(R.String.home), R.Color.red_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.search), R.Color.blue_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.likes), R.Color.blue_grey_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.notification), R.Color.green_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.profile), R.Color.purple_inactive)
            };
            var pagerAdapter = new ScreenSlidePagerAdapter(fragList, SupportFragmentManager);

            var bubbleNavigationLinear = FindViewById<BubbleNavigationLinearView>(R.Id.bottom_navigation_view_linear)!;
            bubbleNavigationLinear.SetTypeface(Typeface.CreateFromAsset(Assets, "rubik.ttf"));
            bubbleNavigationLinear.SetBadgeValue(0, "40");
            bubbleNavigationLinear.SetBadgeValue(1, null); //invisible badge
            bubbleNavigationLinear.SetBadgeValue(2, "7");
            bubbleNavigationLinear.SetBadgeValue(3, "2");
            bubbleNavigationLinear.SetBadgeValue(4, ""); //empty badge

            var viewPager = FindViewById<ViewPager>(R.Id.view_pager)!;

            viewPager.Adapter = pagerAdapter;
            viewPager.PageScrollStateChanged += null;
            viewPager.PageScrolled += null;
            viewPager.PageSelected += (s, e) => bubbleNavigationLinear.SetCurrentActiveItem(e.Position);

            bubbleNavigationLinear.NavigationChange += (s, e) => viewPager.SetCurrentItem(e.Position, true);
        }
    }
}