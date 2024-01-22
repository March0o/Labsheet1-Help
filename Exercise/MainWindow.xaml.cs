using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Band> Bands = new List<Band>();
        string filter = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create Bands
            for (int i = 0; i < 6; i++)
            {
                List<string> list = new List<string>();
                list.Add("Member1");
                list.Add("Member2");

                if (i < 2)
                {
                    Band band = new RockBand($"Rock Band {i}", 2003, list);
                    Bands.Add(band);
                }
                else if (i < 4)
                {
                    Band band = new IndieBand($"Indie Band {i}", 2003, list);
                    Bands.Add(band);
                }
                else
                {
                    Band band = new PopBand($"Pop Band {i}", 2003, list);
                    Bands.Add(band);
                }
            }

            // Populate ComboBox
            string[] genres = { "Rock", "Pop", "Indie" };

            CbxGenre.ItemsSource = null;
            CbxGenre.ItemsSource = genres;



            Update(Bands);
        }

        private void LbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbxBands.SelectedItem != null) { UpdateInfo(); }

        }

        private void CbxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filter = CbxGenre.SelectedItem as string;
            List<Band> filteredBands = new List<Band>();

            for (int i = 0; i < Bands.Count; i++)
            {
                if (Bands[i].SubGenre == filter)
                {
                    filteredBands.Add(Bands[i]);
                }
            }



            Update(filteredBands);
        }

        // Methods
        public List<Band> MakeCopy(List<Band> original)
        {
            List<Band> copy = new List<Band>();
            foreach (Band band in original) { copy.Add(band); }
            return copy;
        }

        public string membersString(List<string> members)
        {
            string membersString = "";
            for (int i = 0; i < members.Count; i++)
            {
                membersString += members[i] + ", ";
            }
            return membersString;
        }

        public void UpdateInfo()
        {
            Band selected = LbxBands.SelectedItem as Band;

            // Update InfoBoxes
            TblkDateFormed.Text = selected.YearFormed.ToString();
            TblkMembers.Text = membersString(selected.Members);

            // Update Listbox
            LbxAlbums.ItemsSource = null;
            LbxAlbums.ItemsSource = selected.Albums;
        }

        public void Update(List<Band> bandsToDisplay)
        {
            LbxBands.ItemsSource = null;
            LbxBands.ItemsSource = bandsToDisplay;

            LbxAlbums.ItemsSource = null;
        }

        public void CreateFile()
        {
            Band selectedBand = LbxBands.SelectedItem as Band;

            using (StreamWriter sw = new StreamWriter(System.IO.Directory.GetCurrentDirectory() + @"/save.txt"))
            {
                sw.WriteLine(selectedBand.Name);
                sw.WriteLine(selectedBand.YearFormed);
                sw.WriteLine($"Members" + membersString(selectedBand.Members));
                sw.WriteLine("Albums");
                foreach (Album album in selectedBand.Albums)
                { sw.WriteLine(album.Name + album.ReleaseYear + album.Sales); }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateFile();
        }
    }
}