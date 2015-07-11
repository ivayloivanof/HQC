namespace _01.ReformatCode
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private static StringBuilder output = new StringBuilder();
        private readonly DateTime date;
        private readonly string title;
        private readonly string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public string Output
        {
            get
            {
                return output.ToString();
            }
        }

        public static void EventAdded()
        {
            output.AppendLine("Event added");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendLine(string.Format("{0} events deleted", x));
            }
        }

        public static void NoEventsFound()
        {
            output.AppendLine("No events found");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.AppendLine(eventToPrint.ToString());
            }
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;

            int byDate = this.date.CompareTo(other.date);
            int byTitle = this.title.CompareTo(other.title);
            int byLocation = this.location.CompareTo(other.location);

            if (byDate == 0)
            {
                return byTitle == 0 ? byLocation : byTitle;
            }

            return byDate;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | ");
            toString.Append(this.title);

            if (!string.IsNullOrEmpty(this.location))
            {
                toString.Append(" | ");
                toString.Append(this.location);
            }

            return toString.ToString();
        }
    }
}