using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class RockBand : Band
    {
        // Constructors

        public RockBand(string name,int yearFormed, List<string> members) : base(name, yearFormed, members)
        {
            SubGenre = "Rock";
        }

        // Methods
        public override string ToString()
        {
            return Name + " - " + SubGenre;
        }
    }
}
