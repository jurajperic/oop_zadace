namespace ClassLibraryTvShows
{
    public class Season
    {
        public int id { get; set; }
        public string url { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public int? episodeOrder { get; set; }
        public string premiereDate { get; set; }
        public string endDate { get; set; }
        public Network network { get; set; }
        public object webChannel { get; set; }
        public Image image { get; set; }
        public string summary { get; set; }
        public Links _links { get; set; }
    }
}
