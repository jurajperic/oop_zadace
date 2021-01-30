using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using ClassLibraryTvShows;

namespace TvShowsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        IEnumerable<Show> shows;
        IEnumerable<Season> seasons;
        IEnumerable<Episode> episodes;
        BitmapImage defaultImage = new BitmapImage(new Uri("pack://application:,,,/images/novapoz.jpg"));
        WebResponse response;
        WebRequest request;
        StreamReader reader;
        string series_json;

        string summary;
        public MainWindow()
        {
            InitializeComponent();
            request=HttpWebRequest.Create("http://api.tvmaze.com/shows");
             response = request.GetResponse();
             reader = new StreamReader(response.GetResponseStream());
             series_json = reader.ReadToEnd();
          
            shows = JsonConvert.DeserializeObject<List<Show>>(series_json);
            
            SeriesList.ItemsSource = shows.Select(query => query.name);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

             request = HttpWebRequest.Create($"http://api.tvmaze.com/search/shows?q={SearchBox.Text}");

             response = request.GetResponse();
             reader = new StreamReader(response.GetResponseStream());
             series_json = reader.ReadToEnd();
            List<Root> myRoot;
            myRoot = JsonConvert.DeserializeObject<List<Root>>(series_json);

            shows = myRoot.Select(root => root.show);
            SeriesList.ItemsSource = shows.Select(show=>show.name);

        }

        private void SeriesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EpisodesList.ItemsSource = null;
            
            Show tvShow = shows.First(show => show.name == SeriesList.SelectedValue.ToString());
            
            
             request = HttpWebRequest.Create($"http://api.tvmaze.com/shows/{tvShow.id}/seasons");

             response = request.GetResponse();
             reader = new StreamReader(response.GetResponseStream());
             series_json = reader.ReadToEnd();
            seasons = JsonConvert.DeserializeObject<List<Season>>(series_json);
            
            SeasonsList.ItemsSource = seasons.Select(query => "Season "+query.number);
            ImageSourceConverter converter = new ImageSourceConverter();
            Background.ImageSource = tvShow.image !=null ? converter.ConvertFromString(tvShow.image.original) as ImageSource : defaultImage;
            summary = tvShow.summary;
            summary = Regex.Replace(summary ?? "", "<.*?>", String.Empty);
            DescriptionText.Text = summary;
            Score.Text = $"Rating: {tvShow.rating.average}";
        }

        private void SeasonsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            int id = seasons.First(season => season.number == int.Parse(SeasonsList.SelectedItem.ToString().Substring(6))).id;
            
            WebRequest request = HttpWebRequest.Create($"http://api.tvmaze.com/seasons/{id}/episodes");

            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string series_json = reader.ReadToEnd();
            episodes = JsonConvert.DeserializeObject<List<Episode>>(series_json);

            EpisodesList.ItemsSource = episodes.Select(query => query.number + ". " + query.name);
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                WebRequest request = HttpWebRequest.Create($"http://api.tvmaze.com/search/shows?q={SearchBox.Text}");

                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string series_json = reader.ReadToEnd();
                List<Root> myRoot;
                myRoot = JsonConvert.DeserializeObject<List<Root>>(series_json);

                shows = myRoot.Select(root => root.show);
                SeriesList.ItemsSource = shows.Select(show => show.name);


            }
            
        }

        private void SearchBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(SearchBox.Text=="Search...")
            SearchBox.Text = "";

        }
    }

   
    

    


}
