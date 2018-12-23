using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace NeverIHaveEver
{
    public class RequestingQuestions
    {
        /// <summary>
        /// This class creates a file containing list of questions that are downloaded form a server separated by end of line. You can provide Your own server uri.
        /// </summary>
        /// <param name="uri" = https://django-learning-app.herokuapp.com/whatever/ ></param>
        /// <returns>Returns True if everything worked fine, otherwise throws an exception.</returns>
        public static Boolean Get(string uri = "https://django-learning-app.herokuapp.com/whatever/")
        {
            try
            {
                if (!Directory.Exists("Data")) System.IO.Directory.CreateDirectory("Data");
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create folder", e);
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {

                        using (StreamReader reader = new StreamReader(stream))
                        {
                            try
                            {
                                var dic = JsonConvert.DeserializeObject<Dictionary<int, string>>(reader.ReadToEnd());
                                try
                                {
                                    using (System.IO.StreamWriter file =
                                        new System.IO.StreamWriter(@"Data/questions.txt"))
                                    {
                                        for (int i = 1; i < dic.Count + 1; i++)
                                        {
                                            file.WriteLine(dic[i]);
                                            Console.WriteLine(dic[i]);
                                        }
                                    }
                                }
                                catch (IOException e)
                                {
                                    throw new IOException("Problem with creating/editing file occured!", e);
                                }
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                throw new IndexOutOfRangeException("problem with converting json response into dict. Is the response format correct?", e);
                            }
                        }
                    }
                }
            }
            catch (WebException e)
            {
                throw new WebException("Error, bad server response", e);
            }
            return true;
        }
    }
}
