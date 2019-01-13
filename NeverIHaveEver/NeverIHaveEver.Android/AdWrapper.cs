using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Gms.Ads;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace NeverIHaveEver
{
    public static class AdWrapper
    {

        public static InterstitialAd ConstructFullPageAdd()
        {
            var ad = new InterstitialAd(Forms.Context);
            ad.AdUnitId = "ca-app-pub-3940256099942544/1033173712";
            return ad;
        }


        public static InterstitialAd CustomBuild(this InterstitialAd ad)
        {
            var requestbuilder = new AdRequest.Builder();
            ad.LoadAd(requestbuilder.Build());
            return ad;
        }
    }
}