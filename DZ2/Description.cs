using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Description
    {
        public int episodeNumber { get; private set; }
        public TimeSpan duration { get; private set; }
        public string episodeName { get; private set; }

        public Description(int episodeNumber, TimeSpan duration, string episodeName)
        {
            this.episodeNumber = episodeNumber;
            this.duration = duration;
            this.episodeName = episodeName;
        }
        public override string ToString()
        {
            return $"{episodeNumber},{duration},{episodeName}";
        }

    }
}
