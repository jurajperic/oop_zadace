using System;

namespace ClassLibrary
{
    public class Episode
    {
       int viewers;
       double maxScore;
       double totalScore;

        public Episode(int viewers,double totalScore,double maxScore)
        {
            this.viewers = viewers;
            this.totalScore = totalScore;
            this.maxScore = maxScore;
        }

        public Episode() { }
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

        
    }
}
