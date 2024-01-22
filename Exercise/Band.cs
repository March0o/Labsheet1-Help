using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public abstract class Band : IComparable<Band>
    {
        // Attributes
        public string Name { get; set; }
        public int YearFormed { get; set; }
        public List<string> Members { get; set; } = new List<string>();
        public string SubGenre { get; set; }

        public List<Album> Albums { get; set; } = new List<Album>();

        //  Constructors
        public Band() { }

        public Band(string name, int yearFormed, List<string> members)
        {
            Name = name;
            YearFormed = yearFormed;
            Members = members;

            List<Album> albums = new List<Album>();
            for (int i = 0; i < Members.Count; i++)
            {
                albums.Add(new Album($"Album {i}"));
            }
            Albums = albums;
        }
        public int CompareTo(Band other)
        {
            Band that = other as Band;
            return this.Name.CompareTo(that.Name);
        }

        //  Methods
        public override string ToString() { return Name; }
    }
}
