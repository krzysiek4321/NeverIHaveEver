﻿using System;
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
		public MidPage ()
		{
			InitializeComponent ();

            bool getSuccess = false;
            do
            {
                try { RequestingQuestions.Get(); getSuccess = true; }
                catch (Exception e)
                {

                }
            } while (!getSuccess);
        }
	}
}