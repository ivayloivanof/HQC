namespace Logger.Models.Appenders
{
    using Interfaces;

    using Models.Layouts;

    public abstract class Appenders : IAppender
    {
        public ILayout Layout { get; set; }

        public virtual string File { get; set; }

        public abstract void Append(ReportLevel reportLevel, string message);
    }
}
