namespace Logger.Models
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Logger : ILogger
    {
        private IList<IAppender> appenders;

        private string messages;

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

        private string Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("This is empty message.");
                }

                this.messages = value.Trim();
            }
        }
                    
        public void Info(string message)
        {
            this.ReportLevel = ReportLevel.Info;
            this.Messages = message;
            this.InsertInLog();
        }

        public void Error(string message)
        {
            this.ReportLevel = ReportLevel.Error;
            this.Messages = message;
            this.InsertInLog();
        }

        public void Warning(string message)
        {
            this.ReportLevel = ReportLevel.Warning;
            this.Messages = message;
            this.InsertInLog();
        }

        public void Critical(string message)
        {
            this.ReportLevel = ReportLevel.Critical;
            this.Messages = message;
            this.InsertInLog();
        }

        public void Fatal(string message)
        {
            this.ReportLevel = ReportLevel.Fatal;
            this.Messages = message;
            this.InsertInLog();
        }
               
        private void InsertInLog()
        {
            for (var appender = 0; appender < this.appenders.Count; appender++)
            {
                this.appenders[appender].SimpleLayout.Layout(this.ReportLevel, this.Messages);
            }
        }
    }
}
