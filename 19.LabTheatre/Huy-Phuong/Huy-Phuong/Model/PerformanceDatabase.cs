namespace Theatre.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::Theatre.Exception;
    using global::Theatre.Interface;

    internal class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Entertainment>> sortedDictionary =
            new SortedDictionary<string, SortedSet<Entertainment>>();

        public void AddTheatre(string theatreName)
        {
            if (this.sortedDictionary.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.sortedDictionary[theatreName] = new SortedSet<Entertainment>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var sortedTheatres = this.sortedDictionary.Keys;
            return sortedTheatres;
        }

        void IPerformanceDatabase.AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            if (!this.sortedDictionary.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var sortedTheatres = this.sortedDictionary[theatreName];

            var endDateTime = startDateTime + duration;
            if (DurationOverlap(sortedTheatres, startDateTime, endDateTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var entertainment = new Entertainment(theatreName, performanceTitle, startDateTime, duration, price);
            sortedTheatres.Add(entertainment);
        }

        public IEnumerable<Entertainment> ListAllPerformances()
        {
            var theaters = this.sortedDictionary.Keys;
            var resultAllPerformances = new List<Entertainment>();

            foreach (var performances in theaters.Select(t => this.sortedDictionary[t]))
            {
                resultAllPerformances.AddRange(performances);
            }

            return resultAllPerformances;
        }

        IEnumerable<Entertainment> IPerformanceDatabase.ListPerformances(string theatreName)
        {
            if (!this.sortedDictionary.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var sortedTheatres = this.sortedDictionary[theatreName];
            return sortedTheatres;
        }

        protected internal static bool DurationOverlap(
            IEnumerable<Entertainment> performances, 
            DateTime startDateTime1, 
            DateTime endDateTime1)
        {
            foreach (var p in performances)
            {
                var startDateTime = p.StartDateTime;
                var endDateTime = p.StartDateTime + p.Duration;

                var a = startDateTime <= startDateTime1;
                var b = startDateTime1 <= endDateTime;
                var c = startDateTime <= endDateTime1;
                var d = endDateTime1 <= endDateTime;
                var e = startDateTime1 <= startDateTime;
                var j = startDateTime <= endDateTime1;
                var k = startDateTime1 <= endDateTime;
                var l = endDateTime <= endDateTime1;
                
                if ((a && b) || (c && d) || (e && j) || (k && l))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
