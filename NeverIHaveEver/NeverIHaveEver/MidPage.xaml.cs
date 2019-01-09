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
	public partial class MidPage : ContentPage
	{
        string[] quotes = new string[] {
            "\"Truth is the cry of all, but the game of the few\" ~ George Berkeley",
            "\"The search for the truth is the most important work in the whole world — and the most dangerous.\" ~ James Clavell",
            "\"Truth was the only daughter of Time.\" ~ Leonardo da Vinci",
            "\"Vows are spoken to be broken\" ~ Martin Gore",
            "\"All truths are not to be told.\" ~ George Herbert",
            "\"Beauty is truth, truth beauty, — that is all ye know on earth, and all ye need to know.\" ~ John Keats",
            "\"Truth does not belong to an individual.\" ~ Jiddu Krishnamurti",
            "\"Truth has no path. Truth is living and, therefore, changing.\" ~ Bruce Lee",
            "\"Suppose truth is a woman, what then?\" ~ Friedrich Nietzsche",
            "\"Repetition does not transform a lie into a truth.\" ~ Franklin D. Roosevelt"};
            
        public MidPage ()
		{
			InitializeComponent ();

            Random rnd = new Random();
            int i = rnd.Next(0, 10);
            quotes_lbl.Text = quotes[i];
        }

        protected override bool OnBackButtonPressed()
    {
        Device.BeginInvokeOnMainThread(async() => {
            await this.Navigation.PopAsync();
        });

        return true;
    }
	}
}