namespace Logger.Interfaces
{
    using Logger.Models;

    internal interface ILayout
    {
        void Layout(ReportLevel reportLevel, string message);
    }
}
