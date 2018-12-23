using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NeverIHaveEver
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CarouselPage carouselPage = new CarouselPage();
            carouselPage.Children.Add(new LeftPage());
            carouselPage.Children.Add(new MidPage());
            carouselPage.Children.Add(new RightPage());
            carouselPage.CurrentPage = carouselPage.Children[1];

            MainPage = carouselPage;
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
