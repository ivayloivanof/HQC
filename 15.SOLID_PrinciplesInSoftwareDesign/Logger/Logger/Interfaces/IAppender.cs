namespace Logger.Interfaces
{
    using Models;

    public interface IAppender
    {
        SimpleLayout SimpleLayout { get; set; }
    }
}
