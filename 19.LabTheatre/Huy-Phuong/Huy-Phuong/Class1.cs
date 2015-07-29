namespace Theater
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Class1
    {
        public static string ExecuteAddTheatreCommand(string[] parameters)
        {
            var theatreName = parameters[0];
            NhaHat.universal.AddTheatre(theatreName);

            return "Theatre added";
        }

        public static string ExecutePrintAllTheatresCommand()
        {
            var theatresCount = NhaHat.universal.ListTheatres().Count();
            if (theatresCount > 0)
            {
                var resultTheatres = new LinkedList<string>();
                for (var i = 0; i < theatresCount; i++)
                {
                    NhaHat.universal.ListTheatres().Skip(i).ToList().ForEach(t => resultTheatres.AddLast(t));
                    foreach (var t in NhaHat.universal.ListTheatres().Skip(i + 1))
                    {
                        resultTheatres.Remove(t);
                    }
                } 
                
                return String.Join(", ", resultTheatres);
            } 
            
            return "No theatres";
        }
    }
}
