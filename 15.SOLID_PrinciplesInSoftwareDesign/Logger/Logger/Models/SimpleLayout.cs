namespace Logger.Models
{
    using System;

    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Layout(ReportLevel reportLevel, string message)
        {
            return string.Format("<{0}> - <{1}> - <{2}>", DateTime.Now, reportLevel.ToString(), message);
        }
    }
}
