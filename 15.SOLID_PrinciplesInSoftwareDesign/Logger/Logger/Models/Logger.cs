namespace Logger.Models
{
    using Interfaces;

    public class Logger : ILogger
    {
        private ReportLevel ReportLevel { get; set; }

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
