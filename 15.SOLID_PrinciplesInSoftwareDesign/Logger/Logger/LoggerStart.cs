namespace Logger
{
    using System;

    using Logger.Interfaces;
    using Logger.Models;

    public class LoggerStart
    {
        public static void Main()
        {
            try
            {
                var simpleLayout = new SimpleLayout();
                IAppender consoleAppender = new ConsoleAppender(simpleLayout);
                IAppender fileAppender = new FileAppender(simpleLayout);
                ILogger logger = new Logger(consoleAppender);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine();
        }
    }
}
