namespace Theatre
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Execute
    /// </summary>
    public static class Execute
    {
        /// <summary>
        /// ExecuteAddTheatreCommand
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string ExecuteAddTheatreCommand(string[] parameters)
        {
            var theatreName = parameters[0];
            Theatre.universal.AddTheatre(theatreName);

            return "Theatre added";
        }

        /// <summary>
        /// ExecutePrintAllTheatresCommand
        /// </summary>
        /// <returns></returns>
        public static string ExecutePrintAllTheatresCommand()
        {
            var theatresCount = Theatre.universal.ListTheatres().Count();
            if (theatresCount > 0)
            {
                var resultTheatres = new LinkedList<string>();
                for (var i = 0; i < theatresCount; i++)
                {
                    Theatre.universal.ListTheatres().Skip(i).ToList().ForEach(t => resultTheatres.AddLast(t));
                    foreach (var t in Theatre.universal.ListTheatres().Skip(i + 1))
                    {
                        resultTheatres.Remove(t);
                    }
                } 
                
                return string.Join(", ", resultTheatres);
            } 
            
            return "No theatres";
        }

        /// <summary>
        /// ExecutePrintAllPerformancesCommand
        /// </summary>
        /// <returns></returns>
        public static string ExecutePrintAllPerformancesCommand()
        {
            var performances = Theatre.universal.ListAllPerformances().ToList();
            var result = string.Empty;

            if (!performances.Any())
            {
                return "No performances";
            }

            for (var i = 0; i < performances.Count; i++)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(result);
                if (i > 0)
                {
                    stringBuilder.Append(", ");
                }

                var result1 = performances[i].StartDateTime.ToString("dd.MM.yyyy HH:mm");
                stringBuilder.AppendFormat("({0}, {1}, {2})", performances[i].PerformanceTitle, performances[i].TheatreName, result1);

                result = stringBuilder.ToString();
            }

            return result;
        }
    }
}
