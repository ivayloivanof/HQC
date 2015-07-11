namespace _01.ReformatCode
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private readonly DateTime date;
        private readonly string title;
        private readonly string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int byDate = this.date.CompareTo(other.date);
            int byTitle = this.title.CompareTo(other.title);

            int byLocation;
            byLocation = this.location.CompareTo(other.location);
            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                
                return byTitle;
            }

            else return byDate;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + title);
            if (location != null && location != "")
            {
                toString.Append(" | " + location);
            }

            return toString.ToString();
        }
    }
}