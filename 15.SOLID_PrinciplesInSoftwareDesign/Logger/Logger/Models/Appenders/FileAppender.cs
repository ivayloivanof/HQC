namespace Logger.Models.Appenders
{
    using System;
    using System.IO;

    using Interfaces;

    public class FileAppender : Appenders
    {
        private string file;

        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
        }
        
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

        public override void Append(ReportLevel reportLevel, string message)
        {
            var messageFormated = this.Layout.Layout(reportLevel, message);
            using (var writer = new StreamWriter(this.File, true))
            {
                writer.WriteLine(messageFormated);
            }
        }
    }
}
