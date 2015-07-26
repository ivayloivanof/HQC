namespace Logger.Models
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Logger : ILogger
    {
        private IList<IAppender> appenders;

        public Logger(IAppender appender, IAppender appenderTwo, IAppender appenderThree)
        {
            this.appenders = new List<IAppender>();
            this.Appenders = appender;
            this.Appenders = appenderTwo;
            this.Appenders = appenderThree;
        }

        public Logger(IAppender appender, IAppender appenderTwo)
        {
            this.appenders = new List<IAppender>();
            this.Appenders = appender;
            this.Appenders = appenderTwo;
        }

        public Logger(IAppender appender)
        {
            this.appenders = new List<IAppender>();
            this.Appenders = appender;
        }

        private ReportLevel ReportLevel { get; set; }

        private IAppender Appenders 
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("This appender is not valid.");
                }

                this.appenders.Add(value);
            }
        }

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
