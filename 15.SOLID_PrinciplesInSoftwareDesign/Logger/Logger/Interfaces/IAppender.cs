namespace Logger.Interfaces
{
    using Models;

    public interface IAppender
    {
        ILayout Layout { get; set; }

        string File { get; set; }

        void Append(ReportLevel reportLevel, string message);
    }
}
