namespace Theater
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    using Theater.Interface;
    using Theater.Model;

    internal partial class NhaHat
    {
        public static IPerformanceDatabase universal = new BuổIDiễNDatabase();

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    return;
                }

                string[] lineArrayCommandAndSymbols = line.Split('(');
                string command = lineArrayCommandAndSymbols[0];
                string resultInfo;
                string[] chiHuyParts1;
                string[] chiHuyParams;
                try
                {
                    switch (command)
                    {
                        case "AddTheatre":
                            chiHuyParts1 = line.Split(
                                new[] { '(', ',', ')' },
                                StringSplitOptions.RemoveEmptyEntries);
                            chiHuyParams = chiHuyParts1.Skip(1).Select(p => p.Trim()).ToArray();
                            resultInfo = Class1.ExecuteAddTheatreCommand(chiHuyParams);
                            break;
                        case "PrintAllTheaters":
                            resultInfo = Class1.ExecutePrintAllTheatresCommand();
                            break;
                        case "AddPerformance":
                            chiHuyParts1 = line.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                            chiHuyParams = chiHuyParts1.Skip(1).Select(p => p.Trim()).ToArray();
                            string theatreName = chiHuyParams[0];
                            string performanceTitle = chiHuyParams[1];
                            DateTime result = DateTime.ParseExact(
                                chiHuyParams[2],
                                "dd.MM.yyyy HH:mm",
                                CultureInfo.InvariantCulture);
                            DateTime startDateTime = result;
                            TimeSpan result2 = TimeSpan.Parse(chiHuyParams[3]);
                            TimeSpan duration = result2;
                            decimal result3 = decimal.Parse(chiHuyParams[4], NumberStyles.Float);
                            decimal price = result3;
                            NhaHat.universal.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
                            resultInfo = "Performance added";
                            break;
                        case "PrintAllPerformances":
                            resultInfo = ExecutePrintAllPerformancesCommand();
                            break;
                        case "PrintPerformances":
                            lineArrayCommandAndSymbols = line.Split('(');
                            command = lineArrayCommandAndSymbols[0];
                            chiHuyParts1 = line.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                            chiHuyParams = chiHuyParts1.Skip(1).Select(p => p.Trim()).ToArray();
                            string theater = chiHuyParams[0];
                            var performances = universal.ListPerformances(theater).Select(p =>
                                {
                                    string result1 = p.s2.ToString("dd.MM.yyyy HH:mm");
                                    return string.Format("({0}, {1})", p.tr32, result1);
                                })
                                .ToList();
                            if (performances.Any())
                            {
                                resultInfo = string.Join(", ", performances);
                            }
                            else
                            {
                                resultInfo = "No performances";
                            }

                            break;
                        default: 
                            resultInfo = "Invalid command!";
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    resultInfo = "Error: " + ex.Message;
                }

                Console.WriteLine(resultInfo);
            }
        }
    }
}