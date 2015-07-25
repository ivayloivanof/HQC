namespace Logger.Models
{
    using global::Logger.Interfaces;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(SimpleLayout simpleLayout)
        {
            this.SimpleLayout = simpleLayout;
        }

        public SimpleLayout SimpleLayout { get; set; }
    }
}
