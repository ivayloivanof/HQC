namespace Logger.Models
{
    using Interfaces;

    public class Logger : ILogger
    {
        private ReportLevel LayoutType { get; set; }
    }
}
