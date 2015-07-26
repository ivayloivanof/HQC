namespace Logger.Models
{
    using System;

    public class ConsoleAppender : Appenders
    {
        public ConsoleAppender(SimpleLayout simpleLayout)
        {
            this.SimpleLayout = simpleLayout;
        }

        public override void Append(ReportLevel reportLevel, string message)
        {
            var messageFormated = this.SimpleLayout.Layout(reportLevel, message);
            Console.WriteLine(messageFormated);
        }
    }
}
