namespace _01.ReformatCode
{
    using System;
    using System.Collections.Generic;

    public class EventHolder
    {
        private MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> byDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            byTitle.Add(title.ToLower(), newEvent);
            byDate.Add(newEvent);
            Event.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in byTitle[title])
            {
                removed++;
                byDate.Remove(eventToRemove);
            }
            byTitle.Remove(title);
            Event.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.ViewEventsToShow = this.byDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;
            IEnumerable<Event> eventsToShow;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count) break;
                Event.PrintEvent(eventToShow);

                showed++;
            }

            if (showed == 0)
            {
                Event.NoEventsFound();
            }
        }
    }
}
