namespace Theater
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Theater.Interface;

    internal partial class NhaHat
    {
        public static IPerformanceDatabase universal = new BuổIDiễNDatabase();

        public static void Main()
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

            while (true)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    return;
                }

                string[] chiHuyParts = line.Split('(');
                string chiHuy = chiHuyParts[0];
                string chiHuyResult;
                try
                {
                    switch (chiHuy)
                    {
                        case "AddTheatre": chiHuyParts = line.Split('('); chiHuy = chiHuyParts[0]; string[] chiHuyParts1 = line.Split(


                                            new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries); string[] chiHuyParams1 = chiHuyParts1.Skip




                                                (1).Select(p =>
                                                    p.Trim()).ToArray(); string
                                                        [] chiHuyParams =


                                                        chiHuyParams1;
                            chiHuyResult = Class1.ExecuteAddTheatreCommand(chiHuyParams);
                            break;
                        case "PrintAllTheaters":
                            chiHuyResult = Class1.ExecutePrintAllTheatresCommand(); break;
                        case "AddPerformance":
                            chiHuyParts = line.Split('(');




                            chiHuy = chiHuyParts[0];
                            chiHuyParts1 = line.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                            chiHuyParams1 = chiHuyParts1.Skip(1).Select(p => p.Trim()).ToArray();


                            chiHuyParams = chiHuyParams1;
                            string theatreName = chiHuyParams[0]; string performanceTitle = chiHuyParams[1];
                            DateTime result = DateTime.ParseExact(chiHuyParams[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);



                            DateTime startDateTime = result; TimeSpan result2 = TimeSpan.Parse(chiHuyParams[3]);
                            TimeSpan duration = result2;
                            decimal result3 = decimal.Parse(chiHuyParams[4], NumberStyles.Float);
                            decimal price = result3;





                            NhaHat.universal.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
                            chiHuyResult = "Performance added"; break;
                        case "PrintAllPerformances":
                            chiHuyResult = ExecutePrintAllPerformancesCommand();
                            break;
                        case "PrintPerformances":
                            chiHuyParts = line.Split('('); chiHuy = chiHuyParts[0];


                            chiHuyParts1 = line.Split(
                        new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                            chiHuyParams1 = chiHuyParts1.Skip(1).Select(p => p.Trim()).ToArray();


                            chiHuyParams = chiHuyParams1;
                            string theatre = chiHuyParams[0];





                            var performances = universal.ListPerformances(theatre)
                                .Select(p =>
                                {
                                    string result1 = p.s2.ToString("dd.MM.yyyy HH:mm");
                                    return string.Format("({0}, {1})", p.tr32, result1);
                                })
                    .ToList();
                            if (performances.Any())
                            {
                                chiHuyResult = string.Join(", ", performances);
                            }
                            else
                            {
                                chiHuyResult


                                    =


                                    "No performances"

                                ;


                            } break;
                        default: chiHuyResult = "Invalid command!";
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    chiHuyResult = "Error: " + ex.Message;
                }

                Console.WriteLine(chiHuyResult);
            }
        }
    }



    public class TimeDurationOverlapException : System.Exception
    {
        public TimeDurationOverlapException(string msg)
            : base(msg) { }
    }
    public class BuoiDien : IComparable<BuoiDien>
    {




        public BuoiDien(string tr23, string tr32, DateTime s2, TimeSpan thoiGian, decimal gia)
        {
            this.tr23 = tr23;
            this.tr32 = tr32;
            this.s2 = s2;
            this.ThoiGian = thoiGian; this.gia = gia;
        }

        public string tr23 { get; protected internal set; }public string tr32 { get; private set; }public DateTime s2 { get; set; }

        public TimeSpan ThoiGian { get; private set; }




        protected internal decimal gia { get; protected set; }

        int IComparable<BuoiDien>.CompareTo(BuoiDien otherBuoiDien)
        {
            int tmp = this.s2.CompareTo(otherBuoiDien.s2); return tmp;
        }





        public override string ToString()
        {
            string result = string.Format(
                "BuoiDien(Tr32: {0}; Tr23: {1}; s2: {2}, ThoiGian: {3}, Gia: {4})",
this.tr23,
this.tr32,
this.s2.ToString("dd.MM.yyyy HH:mm"), this.ThoiGian.ToString("hh':'mm"), this.gia.ToString("f2"));
            return result;
        }
    }


    internal class BuổIDiễNDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<BuoiDien>> sortedDictionaryStringSortedSetPerformance =
        new SortedDictionary<string, SortedSet<BuoiDien>>();

        public void AddTheatre(string tt)
        {
            if (!this.sortedDictionaryStringSortedSetPerformance.ContainsKey(tt))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.sortedDictionaryStringSortedSetPerformance[tt] = new SortedSet<BuoiDien>();
        }




        class DuplicateTheatreException : System.Exception
        {
            public DuplicateTheatreException(string msg)
                : base(msg)
            {
            }
        }


        public IEnumerable<string> ListTheatres()
        {
            var t2 = this.sortedDictionaryStringSortedSetPerformance.Keys;
            return t2;
        }

        void IPerformanceDatabase.AddPerformance(string tt,
            string pp, DateTime s2, TimeSpan thoiGian, decimal gia)
        {
            if (!this.sortedDictionaryStringSortedSetPerformance.ContainsKey(tt))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var ps = this.sortedDictionaryStringSortedSetPerformance[tt];



            var e2 = s2 + thoiGian; if (kiemTra(ps, s2, e2))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var p = new BuoiDien(tt, pp, s2, thoiGian, gia); ps.Add(p);
        }

        public IEnumerable<BuoiDien> ListAllPerformances()
        {
            var theatres = this.sortedDictionaryStringSortedSetPerformance.Keys;



            var result2 = new List<BuoiDien>(); foreach (var t in theatres)
            {
                var performances = this.sortedDictionaryStringSortedSetPerformance[t];
                result2.AddRange(performances);
            }

            return result2;
        }

        IEnumerable<BuoiDien> IPerformanceDatabase.ListPerformances(string theatreName)
        {
            if (!this.sortedDictionaryStringSortedSetPerformance.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            } var asfd = this.sortedDictionaryStringSortedSetPerformance[theatreName];
            return asfd;
        }



        protected internal static bool kiemTra(
            IEnumerable

                <

            BuoiDien

            >

            performances

            ,

                DateTime

            ss2


            , DateTime ee2)
        {
            foreach (var p in performances)
            {
                var ss = p.s2;

                var ee = p.s2 + p.ThoiGian; var kiemTra =
                     (ss <= ss2 && ss2 <= ee) || (ss <= ee2 && ee2 <=


                     ee) || (ss2 <= ss && ss <= ee2) || (ss2 <= ee && ee <= ee2); if (kiemTra)
                {
                    return true;
                }
            }

            return false;
        }
    }

}
