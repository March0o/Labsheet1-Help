using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class Album
    {
        // Attributes
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int Sales { get; set; }

        //  Constructors
        public Album(string name)
        {
            Name = name;

            // Random
            Random rnd = new Random();
            ReleaseYear = rnd.Next(1950, 2050);
            Sales = rnd.Next(0, 200000000);
        }

        // Methods
        public override string ToString() 
        {
            return Name;
        }
    }
}
