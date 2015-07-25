namespace Logger.Models
{
    using System;

    using Interfaces;

    public class FileAppender : IAppender
    {
        private string file;

        public FileAppender(SimpleLayout simpleLayout)
        {
            this.SimpleLayout = simpleLayout;
        }

        public SimpleLayout SimpleLayout { get; set; }

        public string File
        {
            get
            {
                return this.file;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("This name of file is empty.");
                }

                this.file = value;
            }
        }
        
    }
}
