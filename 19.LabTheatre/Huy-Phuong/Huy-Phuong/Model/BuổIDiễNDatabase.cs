namespace Theatre.Model
{
    using System;
    using System.Collections.Generic;

    using global::Theatre.Exception;
    using global::Theatre.Interface;

    internal class BuổIDiễNDatabase : IPerformanceDatabase
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

            var e2 = startDateTime + duration;
            if (kiemTra(sortedTheatres, startDateTime, e2))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var entertainment = new Entertainment(theatreName, performanceTitle, startDateTime, duration, price);
            sortedTheatres.Add(entertainment);
        }

        public IEnumerable<Entertainment> ListAllPerformances()
        {
            var theaters = this.sortedDictionary.Keys;
            var result2 = new List<Entertainment>();

            foreach (var t in theaters)
            {
                var performances = this.sortedDictionary[t];
                result2.AddRange(performances);
            }

            return result2;
        }

        IEnumerable<Entertainment> IPerformanceDatabase.ListPerformances(string theatreName)
        {
            if (!this.sortedDictionary.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var asfd = this.sortedDictionary[theatreName];
            return asfd;
        }

        protected internal static bool kiemTra(IEnumerable<Entertainment> performances, DateTime ss2, DateTime ee2)
        {
            foreach (var p in performances)
            {
                var ss = p.s2;
                var ee = p.s2 + p.ThoiGian;
                var kiemTra = (ss <= ss2 && ss2 <= ee) ||
                                (ss <= ee2 && ee2 <= ee) ||
                                (ss2 <= ss && ss <= ee2) ||
                                (ss2 <= ee && ee <= ee2);

                if (kiemTra)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
