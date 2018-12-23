using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeverIHaveEver;
using System.IO;


namespace Testy
{
    [TestClass]
    public class ServerConnectionTests
    {
        [TestMethod]
        public void DoesServerConnectionWork()

        {
            RequestingQuestions.Get(); // Download questions and create file in Data folder
            Assert.IsTrue(new FileInfo(@"Data/questions.txt").Exists);
        }
        [TestMethod]
        public void DoesReadAllQuestionsWork()
        {
            DirectoryInfo d = new DirectoryInfo(@"Data/");

            if (d.Exists)
            {
                FileInfo[] files = d.GetFiles();
                foreach (var f in files)
                    Console.WriteLine(f.Name);
                Assert.IsTrue(files.Length > 0);
            }
            else { Assert.Fail(); }
        }
    }
}
