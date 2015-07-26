namespace Logger.Models
{
    using Interfaces;

    public abstract class Appenders : IAppender
    {
        public SimpleLayout SimpleLayout { get; set; }

        public virtual string File { get; set; }

        public abstract void Append(ReportLevel reportLevel, string message);
    }
}
