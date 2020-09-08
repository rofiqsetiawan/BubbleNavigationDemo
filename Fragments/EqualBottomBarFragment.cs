// Created by Rofiq Setiawan (rofiqsetiawan@gmail.com)

#nullable enable

using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Demo.Adapters;
using Gauravk.BubbleNavigation;
using System.Collections.Generic;
using R = Demo.Resource;

namespace Demo.Fragments
{
    [Register("id.karamunting.bubblenavigationdemo.fragments.EqualBottomBarFragment")]
    public class EqualBottomBarFragment : Fragment
    {
        private View? _inflatedView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the layout for this fragment
            _inflatedView = inflater.Inflate(R.Layout.fragment_equal_bottom_bar, container, false)!;
            return _inflatedView;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            var fragList = new List<ScreenSlidePageFragment>()
            {
                ScreenSlidePageFragment.NewInstance(GetString(R.String.shop), R.Color.blue_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.photos), R.Color.purple_inactive),
                ScreenSlidePageFragment.NewInstance(GetString(R.String.call), R.Color.green_inactive)
            };
            var pagerAdapter = new ScreenSlidePagerAdapter(fragList, ChildFragmentManager);

            var viewPager = _inflatedView!.FindViewById<ViewPager>(R.Id.view_pager)!;
            viewPager.Adapter = pagerAdapter;

            // Disable swipe
            viewPager.SetOnTouchListener(
                new MyViewOnTouchListener((v, motionEvent) => true)
            );

            var equalNavigationBar =
                _inflatedView.FindViewById<BubbleNavigationLinearView>(R.Id.equal_navigation_bar)!;
            equalNavigationBar.NavigationChange += (s, e) => viewPager.SetCurrentItem(e.Position, true);

            // Change the initial activate element
            const int newInitialPosition = 2;
            equalNavigationBar.SetCurrentActiveItem(newInitialPosition);
            viewPager.SetCurrentItem(newInitialPosition, false);
        }
    }
}