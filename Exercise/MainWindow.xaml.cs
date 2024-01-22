using System.Text;
using System.Windows;
using System.Windows.Controls;
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
        List<Band> FilteredBands = new List<Band>();
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
            if (LbxAlbums.SelectedItem != null) { UpdateInfo(); }

        }

        private void CbxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filter = CbxGenre.SelectedItem as string;

            FilteredBands.Clear();
            for (int i = 0; i < Bands.Count; i++)
            {
                if (Bands[i].SubGenre == filter)
                {
                    FilteredBands.Add(Bands[i]);
                }
            }



            Update(FilteredBands);
        }

        // Methods
        public List<Band> MakeCopy(List<Band> original)
        {
            List<Band> copy = new List<Band>();
            foreach (Band band in original) { copy.Add(band); }
            return copy;
        }

        public void UpdateInfo()
        {
            Band selected = LbxBands.SelectedItem as Band;

            // Update InfoBoxes
            TblkDateFormed.Text = selected.YearFormed.ToString();
            string members = "";
            for (int i = 0; i < selected.Members.Count; i++)
            {
                members += selected.Members[i] + ", ";
            }

            TblkMembers.Text = members;

            // Update Listbox
            LbxAlbums.ItemsSource = null;
            LbxAlbums.ItemsSource = selected.Albums;
        }

        public void Update(List<Band> bandsToDisplay)
        {
            LbxBands.ItemsSource = null;
            FilteredBands.Sort();
            LbxBands.ItemsSource = bandsToDisplay;

            LbxAlbums.ItemsSource = null;
        }
    }
}