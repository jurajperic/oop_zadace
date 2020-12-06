using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Season
    {
        Episode[] episodes;
        int seasonNumber;
        
        public Season(int seasonNumber, Episode[] episodes)
        {
            this.seasonNumber = seasonNumber;
            this.episodes = episodes;
            
        }
        public int Length { get => episodes.Length; }
        public Episode this[int episodeNumber]
        {
            get { return episodes[episodeNumber]; }
            set { episodes[episodeNumber] = value; }
        }

        private TimeSpan GetTotalDuration(Episode[] episodes)
        {
            TimeSpan totalDuration = new TimeSpan();
            foreach (var episode in episodes)
            {
                totalDuration += episode.Description.duration;
            }
            return totalDuration;
        }

        private int GetTotalViewers(Episode[] episodes)
        {
            int totalViewers = 0;
            foreach (var episode in episodes)
            {
                totalViewers += episode.GetViewerCount();
            }
            return totalViewers;
        }
        public override string ToString()
        {

            string seperator = "=================================================";
            string episodes = string.Join<Episode>(Environment.NewLine, this.episodes);
            string season = $"Season:{seasonNumber}";
            string viewers = $"Total viewers: {GetTotalViewers(this.episodes)}";
            string duration = $"Total duration: {GetTotalDuration(this.episodes)}";
            return season + "\n"+ seperator +"\n" +episodes+ "\n"+ "Report:"+ "\n" + seperator + "\n"+ viewers + "\n" + duration + "\n" + seperator +"\n";

        }
    }
}
