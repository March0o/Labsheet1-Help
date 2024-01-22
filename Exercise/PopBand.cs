using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class PopBand : Band
    {
        // Constructors

        public PopBand(string name,int yearFormed, List<string> members) : base(name, yearFormed, members)
        {
            SubGenre = "Pop";
        }

        // Methods
        public override string ToString()
        {
            return Name + " - " + SubGenre;
        }
    }
}
