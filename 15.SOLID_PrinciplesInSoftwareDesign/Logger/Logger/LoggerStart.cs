namespace Logger
{
    using Logger.Models;

    public class LoggerStart
    {
        public static void Main()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender();
            var fileAppender = new FileAppender();

        }
    }
}
