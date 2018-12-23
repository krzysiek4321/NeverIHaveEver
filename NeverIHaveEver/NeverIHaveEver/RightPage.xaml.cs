﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NeverIHaveEver
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RightPage : ContentPage
	{
        private List<string> questionFileNameList;
        private Questions questions;
        
		public RightPage ()
		{
			InitializeComponent ();
            RequestingQuestions.Get();
            ReadAllQuestions();

            if (questionFileNameList == null)
                throw new Exception("empty question folder");
            if (questionFileNameList.Count > 1)
                SelectQuestionSet();
            else questions = new Questions(new StreamReader(questionFileNameList[0]));
		}

        private void SelectQuestionSet()
        {
            throw new NotImplementedException();
        }

        public void ReadAllQuestions()
        {
            DirectoryInfo d = new DirectoryInfo(@"Data/");

            if (d.Exists)
            {
                FileInfo[] files = d.GetFiles();
                questionFileNameList = new List<string>(
                    files.ToList().ConvertAll((x)=>x.FullName)
                    );
            }
            else
            {
                throw new Exception("ReadAllQuestions: dir doesn't exist");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            quest_lbl.Text = questions.GetRandomQuestion();
        }
    }
}