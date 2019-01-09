using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NeverIHaveEver
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
            InitializeComponent();

            GoAhead();

        }

        private async void GoAhead()
        {
            await UseDelay();
            GetPrepered();
        }

        async Task UseDelay()
        {
            await Task.Delay(3000);
        }

        async private void GetPrepered()
        {
            await VersionCheck();

            CarouselPage carouselPage = new CarouselPage();
            carouselPage.Children.Add(new LeftPage());
            carouselPage.Children.Add(new MidPage());
            carouselPage.Children.Add(new RightPage());
            carouselPage.CurrentPage = carouselPage.Children[1];

            App.Current.MainPage = carouselPage;
        }

        private async Task VersionCheck()
        {
            bool getSuccess = false;
            do
            {
                try { RequestingQuestions.Get(); getSuccess = true; }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    await DisplayAlert("No Internet Access", "Please check your online settings", "OK");
                }
            } while (getSuccess != true);
        }   
    }
}