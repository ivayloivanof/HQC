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

            this.sb.Append("\t<date>");
            this.sb.Append(string.Format("{0}", DateTime.Now));
            this.sb.AppendLine("</date>");

            this.sb.Append("\t<level>");
            this.sb.Append(string.Format("{0}", reportLevel.ToString()));
            this.sb.AppendLine("</level>");

            this.sb.Append("\t<message>");
            this.sb.Append(string.Format("{0}", message));
            this.sb.AppendLine("</message>");

            this.sb.AppendLine("</log>");

            return this.sb.ToString();
        }
    }
}
