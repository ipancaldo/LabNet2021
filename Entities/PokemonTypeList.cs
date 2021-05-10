using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PokemonTypeList

    {
        //private List<PokemonType> pokemon;

        //public List<PokemonType> Pokemon { get => pokemon; set => pokemon = value; }        

        //private List<PokemonType> pokemon;

        //public List<PokemonType> Pokemon { get ; set; }
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<PokemonType> Pokemon { get; set; }
    }
}
