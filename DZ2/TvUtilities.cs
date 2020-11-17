using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public static class TvUtilities
    {
        public static double GenerateRandomScore()
        {
            Random random = new Random();
            return random.NextDouble() * 10;
        }

        public static Episode Parse(string text)
        {
            
            string[] parametars = text.Split(',');

            int viewers = int.Parse(parametars[0]);
            double totalScore = double.Parse(parametars[1]);
            double maxGrade = double.Parse(parametars[2]);
            int episodeNumber = int.Parse(parametars[3]);
            TimeSpan duration = TimeSpan.Parse(parametars[4]);
            string name = parametars[5];
            Description description = new Description(episodeNumber, duration, name);
            Episode episode = new Episode(viewers, totalScore, maxGrade, description);
            return episode;
        }

        public static void Sort(Episode[] episodes)
        {
            int i, j;
            Episode temp;
            for (i = 0; i < episodes.Length; i++)
                for (j = i; j < episodes.Length - i - 1; j++)
                    if (episodes[j] < episodes[j + 1])
                    {

                        temp = episodes[j];
                        episodes[j] = episodes[j + 1];
                        episodes[j + 1] = temp;
                    }
        }
    }
}
