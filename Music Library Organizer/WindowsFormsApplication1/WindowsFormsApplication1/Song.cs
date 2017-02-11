using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongLibrary
{
    [Serializable]
    public enum Label { None, HipHop, Rock, RB, Electronic, Classic };

    [Serializable]
    public class SongInfo
    {
        public SongInfo()
        {
            Title = "Enter a song title ...";
            RecordLabel = Label.None;
            Producer = "Enter Producer's full name";
            Year = 2010;
            Length = new TimeSpan();
        }
        public string Title { get; set; }
        public Label RecordLabel { get; set; }
        public string Producer { get; set; }
        public int Year { get; set; }
        public TimeSpan Length { get; set; }
        public string Review { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}