namespace Logger.Interfaces
{
    using Logger.Models;

    public interface ILayout
    {
        string Layout(ReportLevel reportLevel, string message);
    }
}
