using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Card;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.View;
using Android.Graphics;
using TestMaterialCardView;
using TestMaterialCardView.Droid;
[assembly: Xamarin.Forms.ExportRenderer(typeof(Page1), typeof(Page1Renderer))]

namespace TestMaterialCardView.Droid
{
    public class Page1Renderer:PageRenderer, IOnClickListener, IOnTouchListener
    {
        Activity activity;
        global::Android.Views.View view;
        MaterialCardView material_card;
        private readonly Context _localContext;
        TextView textview;
        LinearLayout linearLayoutCard;

        Android.Widget.Button localButton;
        bool _yes = true;
        public Page1Renderer(Context context) : base(context)
        {
            _localContext = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }

            if (e.NewElement != null)
            {
                activity = this.Context as Activity;
                view = activity.LayoutInflater.Inflate(Resource.Layout.main_layout, this, false);
               
                activity.SetContentView(view);
                material_card = (MaterialCardView)view.FindViewById(Resource.Id.material_card);
                localButton = (Android.Widget.Button)view.FindViewById(Resource.Id.button);

                localButton?.SetOnClickListener(this);
                textview = (TextView)view.FindViewById(Resource.Id.textview);
                linearLayoutCard =(LinearLayout) view.FindViewById(Resource.Id.linearLayoutCard);
            }
        }

        public void OnClick(Android.Views.View v)
        {
            // throw new NotImplementedException();
            if (_yes)
            {
                material_card.StrokeColor = Android.Graphics.Color.ParseColor("#FFFFFF");
                material_card.StrokeWidth = 0;
                //material_card.LayoutParameters.LayoutAnimationParameters
                //linearLayoutCard?.SetMinimumHeight(material_card.Height+20);
                //linearLayoutCard?.SetMinimumWidth(material_card.Width+20);
                material_card.SetPadding(0, 0, 0, 0);
                linearLayoutCard.LayoutParameters.Width = material_card.Width;
                linearLayoutCard.LayoutParameters.Height = material_card.Height;
                linearLayoutCard.SetPadding(0, 0, 0, 0);
                textview.Text = "Border out";
                _yes = false;
               // return true;
            }
            else
            {
                material_card.StrokeColor = Android.Graphics.Color.ParseColor("#123456");
                material_card.StrokeWidth = 20;
                //linearLayoutCard?.SetMinimumHeight(material_card.Height);
                //linearLayoutCard?.SetMinimumWidth(material_card.Width);
                material_card.SetPadding(0, 0, 0, 0);
                linearLayoutCard.LayoutParameters.Width = material_card.Width;
                linearLayoutCard.LayoutParameters.Height = material_card.Height;
                linearLayoutCard.SetPadding(0, 0, 0, 0);
                textview.Text = "Border in";
                _yes = true;
                //return true;
            }
        }

        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            return true;

        }
    }
}