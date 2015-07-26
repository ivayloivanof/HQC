namespace Logger.Models.Layouts
{
    using System;
    using System.Text;

    using Interfaces;

    public class XmlLayout : ILayout
    {
        private StringBuilder sb = new StringBuilder();

        public string Layout(ReportLevel reportLevel, string message)
        {
            this.sb.AppendLine("<log>");

            this.sb.AppendLine("\t<date>");
            this.sb.AppendLine(string.Format("{0}", DateTime.Now));
            this.sb.AppendLine("\t</date>");

            this.sb.AppendLine("\t<level>");
            this.sb.AppendLine(string.Format("{0}", reportLevel.ToString()));
            this.sb.AppendLine("\t</level>");

            this.sb.AppendLine("\t<message>");
            this.sb.AppendLine(string.Format("{0}", message));
            this.sb.AppendLine("\t</message>");

            this.sb.AppendLine("</log>");

            return this.sb.ToString();
        }
    }
}
