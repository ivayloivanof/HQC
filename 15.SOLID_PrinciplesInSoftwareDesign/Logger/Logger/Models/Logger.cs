namespace Logger.Models
{
    using System.Collections.Generic;

    using Interfaces;

    public class Logger : ILogger
    {
        public Logger(IAppender appender, IAppender appenderTwo = null)
        {
            this.Appenders.Add(appender);
        }

        private ReportLevel ReportLevel { get; set; }

        private IList<IAppender> Appenders { get; set; }

        public void Info(string message)
        {
            this.ReportLevel = ReportLevel.Info;
        }

        public void Error(string message)
        {
            this.ReportLevel = ReportLevel.Error;
        }

        public void Warning(string message)
        {
            this.ReportLevel = ReportLevel.Warning;
        }

        public void Critical(string message)
        {
            this.ReportLevel = ReportLevel.Critical;
        }

        public void Fatal(string message)
        {
            this.ReportLevel = ReportLevel.Fatal;
        }
    }
}
