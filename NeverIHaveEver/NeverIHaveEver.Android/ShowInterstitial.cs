using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NeverIHaveEver;
using Xamarin.Forms;


[assembly: Dependency(typeof(IAdMobService))]
namespace NeverIHaveEver.Droid
{
    public class ShowInterstitial : IAdMobService
    {
        public void ShowAd()
        {
            var FinalInterstitialAd = AdWrapper.ConstructFullPageAdd();
            var intListenr = new adlistener();

            intListenr.AdLoaded += () => { if (FinalInterstitialAd.IsLoaded) FinalInterstitialAd.Show(); };
            FinalInterstitialAd.AdListener = intListenr;
            AdWrapper.CustomBuild(FinalInterstitialAd);
        }
    }
}