namespace Theatre
{
    using System;
    using System.Globalization;
    using System.Linq;

    using global::Theatre.Exception;
    using global::Theatre.Interface;
    using global::Theatre.Model;

    internal class Theatre
    {
        public static IPerformanceDatabase universal = new BuổIDiễNDatabase();

        public static void Main()
        {
            int loop = 0;
            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    loop++;
                    if (loop > 11)
                    {
                        break;
                    }

                    continue;
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
                            resultInfo = Execute.ExecuteAddTheatreCommand(parameters);
                            break;
                        case "PrintAllTheatres":
                            resultInfo = Execute.ExecutePrintAllTheatresCommand();
                            break;
                        case "AddPerformance":
                            var theatreName = parameters[0];
                            var performanceTitle = parameters[1];
                            DateTime startDateTime = DateTime.ParseExact(parameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                            TimeSpan duration = TimeSpan.Parse(parameters[3]);
                            var price = decimal.Parse(parameters[4]);
                            Theatre.universal.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
                            resultInfo = "Performance added";
                            break;
                        case "PrintAllPerformances":
                            resultInfo = Execute.ExecutePrintAllPerformancesCommand();
                            break;
                        case "PrintPerformances":
                            var theaderName = parameters[0];
                            var performances = Theatre.universal.ListPerformances(theaderName).Select(p =>
                                {
                                    var result1 = p.s2.ToString("dd.MM.yyyy HH:mm");
                                    return String.Format("({0}, {1})", p.tr32, result1);
                                }).ToList();

                            resultInfo = performances.Any() ? String.Join(", ", performances) : "No performances";

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