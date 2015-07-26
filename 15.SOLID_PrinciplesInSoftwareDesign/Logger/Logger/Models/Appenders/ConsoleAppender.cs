namespace Logger.Models.Appenders
{
    using System;

    using Interfaces;

    public class ConsoleAppender : Appenders
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public override void Append(ReportLevel reportLevel, string message)
        {
            var messageFormated = this.Layout.Layout(reportLevel, message);
            Console.WriteLine(messageFormated);
        }
    }
}
