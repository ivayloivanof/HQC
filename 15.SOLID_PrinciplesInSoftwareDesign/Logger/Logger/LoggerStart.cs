namespace Logger
{
    using Logger.Interfaces;
    using Logger.Models;

    public class LoggerStart
    {
        public static void Main()
        {
            var simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            IAppender fileAppender = new FileAppender(simpleLayout);

        }
    }
}
