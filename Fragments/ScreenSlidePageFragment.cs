// Created by Rofiq Setiawan (rofiqsetiawan@gmail.com)

#nullable enable

using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Annotation;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using R = Demo.Resource;

namespace Demo.Fragments
{
    /// <summary>
    /// A simple <see cref="Fragment"/> subclass.<br/>
    /// Use the <see cref="ScreenSlidePageFragment.NewInstance(string, int)"/> factory method to create an instance of this fragment.
    /// </summary>
    [Register("id.karamunting.bubblenavigationdemo.fragments.ScreenSlidePageFragment")]
    public class ScreenSlidePageFragment : Fragment
    {
        private const string ArgTitle = "arg_title";
        private const string ArgBgColor = "arg_bg_color";

        private string _title = "Default title.";
        private int _bgColorResId = R.Color.blue_inactive;
        private View? _inflatedView;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Arguments != null)
            {
                _title = Arguments.GetString(ArgTitle, "")!;
                _bgColorResId = Arguments.GetInt(ArgBgColor);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the layout for this fragment
            _inflatedView = inflater.Inflate(R.Layout.fragment_screen_slide_page, container, false)!;
            return _inflatedView;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            _inflatedView!.SetBackgroundColor(new Color(ContextCompat.GetColor(Context, _bgColorResId)));
            _inflatedView.FindViewById<TextView>(R.Id.screen_slide_title)!.Text = _title;
        }

        /// <summary>
        /// Use this factory method to create a new instance of this fragment using the provided parameters.
        /// </summary>
        /// <param name="title">Title parameter</param>
        /// <param name="bgColorId">Background Color</param>
        /// <returns>A new instance of fragment <see cref="ScreenSlidePageFragment"/>.</returns>
        public static ScreenSlidePageFragment NewInstance(string title, [ColorInt] int bgColorId)
        {
            using var b = new Bundle();
            b.PutString(ArgTitle, title);
            b.PutInt(ArgBgColor, bgColorId);

            return new ScreenSlidePageFragment { Arguments = b };
        }
    }
}