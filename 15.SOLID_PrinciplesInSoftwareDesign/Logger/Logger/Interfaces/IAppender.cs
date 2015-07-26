namespace Logger.Interfaces
{
    using Models;

    public interface IAppender
    {
        SimpleLayout SimpleLayout { get; set; }

        string File { get; set; }

        void Append(ReportLevel reportLevel, string message);
    }
}
