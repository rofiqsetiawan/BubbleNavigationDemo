// Created by Rofiq Setiawan (rofiqsetiawan@gmail.com)

#nullable enable

using Android.App;
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
    [Register("id.karamunting.bubblenavigationdemo.TopBarActivity")]
    [Activity]
    public class TopBarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(R.Layout.activity_top_bar);

            var fragList = new List<ScreenSlidePageFragment>
            {
                ScreenSlidePageFragment.NewInstance(GetString(R.String.restaurant), R.Color.orange_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.room), R.Color.red_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.happy), R.Color.green_inactive)
            };
            var pagerAdapter = new ScreenSlidePagerAdapter(fragList, SupportFragmentManager);

            var viewPager = FindViewById<ViewPager>(R.Id.view_pager)!;
            var topNavigationConstraint = FindViewById<BubbleNavigationConstraintView>(R.Id.top_navigation_constraint)!;

            viewPager.Adapter = pagerAdapter;
            viewPager.PageScrollStateChanged += null;
            viewPager.PageScrolled += null;
            viewPager.PageSelected += (s, e) => topNavigationConstraint.SetCurrentActiveItem(e.Position);

            topNavigationConstraint.NavigationChange += (s, e) => viewPager.SetCurrentItem(e.Position, true);
        }
    }
}