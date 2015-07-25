namespace Logger.Models
{
    using global::Logger.Interfaces;

    public class FileAppender : IAppender
    {
        public FileAppender(SimpleLayout simpleLayout)
        {
            this.SimpleLayout = simpleLayout;
        }

        public SimpleLayout SimpleLayout { get; set; }
    }
}
