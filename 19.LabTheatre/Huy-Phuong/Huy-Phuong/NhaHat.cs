namespace Theater
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    using Theater.Exception;
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
                try
                {
                    var commands = line.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    var parameters = commands.Skip(1).Select(p => p.Trim()).ToArray();

                    switch (command)
                    {
                        case "AddTheatre":
                            resultInfo = Class1.ExecuteAddTheatreCommand(parameters);
                            break;
                        case "PrintAllTheatres":
                            resultInfo = Class1.ExecutePrintAllTheatresCommand();
                            break;
                        case "AddPerformance":
                            var theatreName = parameters[0];
                            var performanceTitle = parameters[1];
                            DateTime startDateTime = DateTime.ParseExact(parameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                            TimeSpan duration = TimeSpan.Parse(parameters[3]);
                            var price = decimal.Parse(parameters[4]);
                            NhaHat.universal.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
                            resultInfo = "Performance added";
                            break;
                        case "PrintAllPerformances":
                            resultInfo = ExecutePrintAllPerformancesCommand();
                            break;
                        case "PrintPerformances":
                            var theaderName = parameters[0];
                            var performances = universal.ListPerformances(theaderName).Select(p =>
                                {
                                    var result1 = p.s2.ToString("dd.MM.yyyy HH:mm");
                                    return string.Format("({0}, {1})", p.tr32, result1);
                                }).ToList();

                            resultInfo = performances.Any() ? string.Join(", ", performances) : "No performances";

                            break;
                        default: 
                            resultInfo = "Invalid command!";
                            break;
                    }
                }
                catch (DuplicateTheatreException ex)
                {
                    resultInfo = "Error: " + ex.Message;
                }
                catch (TimeDurationOverlapException ex)
                {
                    resultInfo = "Error: " + ex.Message;
                }
                catch (TheatreNotFoundException ex)
                {
                    resultInfo = "Error: " + ex.Message;
                }
                catch (FormatException ex)
                {
                    resultInfo = "Error: " + ex.Message;
                }

                Console.WriteLine(resultInfo);
            }
        }
    }
}