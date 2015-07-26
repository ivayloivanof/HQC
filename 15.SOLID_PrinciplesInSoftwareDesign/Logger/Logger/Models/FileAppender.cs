namespace Logger.Models
{
    using System;

    using System.IO;

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

        public void Append(ReportLevel reportLevel, string message)
        {
            var messageFormated = this.SimpleLayout.Layout(reportLevel, message);
            using (StreamWriter writer = new StreamWriter(this.File, true))
            {
                writer.WriteLine(messageFormated);
            }
        }
    }
}
