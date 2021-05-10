using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PublicApiLogic
    {
        public object GetAll()
        {
            var url = $"https://www.dolarsi.com/api/api.php?type=valoresprincipales";
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
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            var obj = JsonConvert.DeserializeObject(responseBody);



                            //var casas = JsonConvert.DeserializeObject<List<Casa>>(responseBody);




                            return obj;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                return null;

            }
        }
    }
}
