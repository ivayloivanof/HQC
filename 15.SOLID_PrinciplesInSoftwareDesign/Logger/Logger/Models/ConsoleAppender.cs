namespace Logger.Models
{
    using Interfaces;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(SimpleLayout simpleLayout)
        {
            this.SimpleLayout = simpleLayout;
        }

        public SimpleLayout SimpleLayout { get; set; }


    }
}
