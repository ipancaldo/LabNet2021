using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PokemonType
    {
        //string name;
        //string url;

        //public string Name { get => name; set => name = value; }
        //public string Url { get => url; set => url = value; }

        //public string name { get; set; }
        //public string url { get; set; }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

        public string name { get; set; }
        //HATEOAS?
        public string url { get; set; }

    }
}
