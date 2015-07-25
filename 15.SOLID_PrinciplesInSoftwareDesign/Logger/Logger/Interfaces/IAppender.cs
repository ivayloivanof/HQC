namespace Logger.Interfaces
{
    using Logger.Models;

    internal interface IAppender
    {
        SimpleLayout SimpleLayout { get; set; }
    }
}
