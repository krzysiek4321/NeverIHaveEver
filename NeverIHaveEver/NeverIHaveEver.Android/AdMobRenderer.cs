using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using NeverIHaveEver;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NeverIHaveEver.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]

namespace NeverIHaveEver.Droid
{
    public class AdMobRenderer : ViewRenderer<AdMobView, Android.Gms.Ads.AdView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var ad = new AdView(Android.App.Application.Context);
                ad.AdSize = AdSize.Banner;
                ad.AdUnitId = "ca-app-pub-4133089494678561/3825197196";

                var requestBuilder = new AdRequest.Builder();
                ad.LoadAd(requestBuilder.Build());
                SetNativeControl(ad);
            }
        }

        public AdMobRenderer()
        {

        }
    }
}