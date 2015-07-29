namespace Theater.Model
{
    using System;
    using System.Collections.Generic;

    using Theater.Exception;
    using Theater.Interface;

    internal class BuổIDiễNDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<BuoiDien>> sortedDictionary =
            new SortedDictionary<string, SortedSet<BuoiDien>>();

        public void AddTheatre(string theatreName)
        {
            if (!this.sortedDictionary.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theater");
            }

            this.sortedDictionary[theatreName] = new SortedSet<BuoiDien>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var t2 = this.sortedDictionary.Keys;
            return t2;
        }

        void IPerformanceDatabase.AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            if (!this.sortedDictionary.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theater does not exist");
            }

            var ps = this.sortedDictionary[theatreName];

            var e2 = startDateTime + duration;
            if (kiemTra(ps, startDateTime, e2))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var p = new BuoiDien(theatreName, performanceTitle, startDateTime, duration, price);
            ps.Add(p);
        }

        public IEnumerable<BuoiDien> ListAllPerformances()
        {
            var theaters = this.sortedDictionary.Keys;
            var result2 = new List<BuoiDien>();

            foreach (var t in theaters)
            {
                var performances = this.sortedDictionary[t];
                result2.AddRange(performances);
            }

            return result2;
        }

        IEnumerable<BuoiDien> IPerformanceDatabase.ListPerformances(string theatreName)
        {
            if (!this.sortedDictionary.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theater does not exist");
            }

            var asfd = this.sortedDictionary[theatreName];
            return asfd;
        }

        protected internal static bool kiemTra(IEnumerable<BuoiDien> performances, DateTime ss2, DateTime ee2)
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
