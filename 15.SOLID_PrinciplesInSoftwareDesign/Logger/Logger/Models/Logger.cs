namespace Logger.Models
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class Logger : ILogger
    {
        private IList<IAppender> appenders;

        private string message;

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

        private string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("This is empty message.");
                }

                this.message = value.Trim();
            }
        }
                    
        public void Info(string message)
        {
            this.ReportLevel = ReportLevel.Info;
            this.Message = message;
            this.InsertInLog();
        }

        public void Error(string message)
        {
            this.ReportLevel = ReportLevel.Error;
            this.Message = message;
            this.InsertInLog();
        }

        public void Warning(string message)
        {
            this.ReportLevel = ReportLevel.Warning;
            this.Message = message;
            this.InsertInLog();
        }

        public void Critical(string message)
        {
            this.ReportLevel = ReportLevel.Critical;
            this.Message = message;
            this.InsertInLog();
        }

        public void Fatal(string message)
        {
            this.ReportLevel = ReportLevel.Fatal;
            this.Message = message;
            this.InsertInLog();
        }
               
        private void InsertInLog()
        {
            foreach (IAppender appender in this.appenders)
            {
                var a = appender.SimpleLayout.Layout(this.ReportLevel, this.Message);
            }
        }
    }
}
