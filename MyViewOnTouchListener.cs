// Created by Rofiq Setiawan (rofiqsetiawan@gmail.com)

using System;
using Android.Views;

namespace Demo
{
    internal sealed class MyViewOnTouchListener : Java.Lang.Object, View.IOnTouchListener
    {
        private readonly Func<View, MotionEvent, bool> _onTouch;

        public MyViewOnTouchListener(Func<View, MotionEvent, bool> onTouch)
        {
            _onTouch = onTouch;
        }

        public bool OnTouch(View v, MotionEvent e) => _onTouch != null && _onTouch.Invoke(v, e);
    }
}