// Created by Rofiq Setiawan (rofiqsetiawan@gmail.com)

using Android.Support.V4.App;
using Demo.Fragments;
using System.Collections.Generic;

namespace Demo.Adapters
{
    /// <summary>
    /// A simple pager adapter that represents 5 <see cref="ScreenSlidePageFragment"/> objects, in sequence.
    /// </summary>
    public class ScreenSlidePagerAdapter : FragmentStatePagerAdapter
    {
        private readonly List<ScreenSlidePageFragment> _fragmentList;

        public ScreenSlidePagerAdapter(List<ScreenSlidePageFragment> fragmentList, FragmentManager fm)
            : this(fm)
        {
            _fragmentList = fragmentList;
        }

        public ScreenSlidePagerAdapter(FragmentManager fm) : base(fm)
        {
        }

        public override int Count => _fragmentList?.Count ?? 0;

        public override Fragment GetItem(int position)
        {
            return position >= 0 && position < _fragmentList.Count
                ? _fragmentList[position]
                : new ScreenSlidePageFragment();
        }
    }
}