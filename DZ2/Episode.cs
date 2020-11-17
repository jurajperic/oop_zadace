using System;

namespace ClassLibrary
{
    public class Episode
    {
       int viewers;
       double maxScore;
       double totalScore;
       Description description; 

        public Episode(int viewers,double totalScore,double maxScore, Description description)
        {
            this.viewers = viewers;
            this.totalScore = totalScore;
            this.maxScore = maxScore;
            this.description = description;
        }

        public Episode() {
            viewers = 0;
            totalScore = 0;
            maxScore = 0;
            description = null;
        }

        public void AddView(double score)
        {
            viewers++;
            totalScore += score;
            if (score > maxScore)
            {
                maxScore = score;
            }
        }

        public double GetMaxScore()
        {
            return maxScore;
        }

        public int GetViewerCount()
        {
            return viewers;
        }

        public double GetAverageScore()
        {
            return totalScore / viewers;
        }

        public override string ToString()
        {
            return $"{viewers},{totalScore},{maxScore},{description}";
        }

        public static bool operator >(Episode episodeOne, Episode episodeTwo)
        {
            return episodeOne.GetAverageScore() > episodeTwo.GetAverageScore();
        }

        public static bool operator <(Episode episodeOne, Episode episodeTwo)
        {
            return episodeOne.GetAverageScore() < episodeTwo.GetAverageScore();
        }
    }
}
