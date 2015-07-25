namespace Logger.Models
{
    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public ReportLevel LayoutType { get; set; }

        // SimpleLayout - defines the format "<date-time> - <report level> - <message>"
        public void Layout(ReportLevel reportLevel, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
