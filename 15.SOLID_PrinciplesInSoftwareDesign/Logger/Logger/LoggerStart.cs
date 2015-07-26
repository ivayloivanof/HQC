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

                logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine();
        }
    }
}
