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
                    
        public void Info(string messageInfo)
        {
            this.ReportLevel = ReportLevel.Info;
            this.Message = messageInfo;
            this.InsertInLog();
        }

        public void Error(string messageError)
        {
            this.ReportLevel = ReportLevel.Error;
            this.Message = messageError;
            this.InsertInLog();
        }

        public void Warn(string messageWarn)
        {
            this.ReportLevel = ReportLevel.Warn;
            this.Message = messageWarn;
            this.InsertInLog();
        }

        public void Critical(string messageCritical)
        {
            this.ReportLevel = ReportLevel.Critical;
            this.Message = messageCritical;
            this.InsertInLog();
        }

        public void Fatal(string messageFatal)
        {
            this.ReportLevel = ReportLevel.Fatal;
            this.Message = messageFatal;
            this.InsertInLog();
        }
               
        private void InsertInLog()
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(this.ReportLevel, this.Message);
            }
        }
    }
}
