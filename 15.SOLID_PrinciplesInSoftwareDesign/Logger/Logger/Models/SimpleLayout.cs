namespace Logger.Models
{
    using System;

    using Interfaces;

    public class SimpleLayout : ILayout
    {
        private ReportLevel LayoutType { get; set; }

        public void Layout(ReportLevel reportLevel, string message)
        {
            var messages = string.Format("<{0}> - <{1}> - <{2}>", DateTime.Now, reportLevel.ToString(), message);
        }
    }
}
