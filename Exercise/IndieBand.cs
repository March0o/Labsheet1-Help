using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class IndieBand : Band
    {
        // Constructors

        public IndieBand(string name,int yearFormed, List<string> members) : base(name, yearFormed, members)
        {
            SubGenre = "Indie";
        }

        // Methods
        public override string ToString()
        {
            return Name + " - " + SubGenre;
        }
    }
}
