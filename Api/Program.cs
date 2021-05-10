using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Api
{
    class Program
    {

        private static void GetItem()
        {
            var url = $"https://pokeapi.co/api/v2/type/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody

                            var obj = JsonConvert.DeserializeObject(responseBody);

                            Console.WriteLine(obj);


                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error

            }            
            
            //var url = $"https://www.dolarsi.com/api/api.php?type=valoresprincipales";
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //request.Accept = "application/json";

            //try
            //{
            //    using (WebResponse response = request.GetResponse())
            //    {
            //        using (Stream strReader = response.GetResponseStream())
            //        {
            //            if (strReader == null) return;
            //            using (StreamReader objReader = new StreamReader(strReader))
            //            {
            //                string responseBody = objReader.ReadToEnd();
            //                // Do something with responseBody

            //                var obj = JsonConvert.DeserializeObject(responseBody);

            //                Console.WriteLine(obj);


            //            }
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    // Handle error

            //}
        }

        private static void GetItems()
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        /* private static void GetItems(string filter)
         {
             var url = $"http://localhost:8080/items?filter={filter}";
             var request = (HttpWebRequest)WebRequest.Create(url);
             request.Method = "GET";
             request.ContentType = "application/json";
             request.Accept = "application/json";

             try
             {
                 using (WebResponse response = request.GetResponse())
                 {
                     using (Stream strReader = response.GetResponseStream())
                     {
                         if (strReader == null) return;
                         using (StreamReader objReader = new StreamReader(strReader))
                         {
                             string responseBody = objReader.ReadToEnd();
                             // Do something with responseBody
                             Console.WriteLine(responseBody);
                         }
                     }
                 }
             }
             catch (WebException ex)
             {
                 // Handle error
             }
         }*/

        private static void PostItem(string data)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"data\":\"{data}\"}}";
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        private static void PutItem(int id, string data)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"id\":\"{id}\",\"data\":\"{data}\"}}";
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        private static void DeleteItem(int id)
        {
            var url = $"https://pokeapi.co/api/v2/ability/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        static void Main(string[] args)
        {
            GetItem();


            //GetItems();
            //GetItems("ABC");
            //PostItem("NewItem");
            //PutItem(4, "ReplaceItem");
            //DeleteItem(5);
            Console.ReadLine();
        }
    }
}
