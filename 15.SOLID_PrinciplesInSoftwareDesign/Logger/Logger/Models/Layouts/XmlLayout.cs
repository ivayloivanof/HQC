namespace Logger.Models.Layouts
{
    using System;
    using System.Text;

    using Interfaces;

    public class XmlLayout : ILayout
    {
        private StringBuilder stringBuilder = new StringBuilder();

        public string Layout(ReportLevel reportLevel, string message)
        {
            this.stringBuilder.AppendLine("<log>");

            this.stringBuilder.Append("\t<date>");
            this.stringBuilder.Append(string.Format("{0}", DateTime.Now));
            this.stringBuilder.AppendLine("</date>");

            this.stringBuilder.Append("\t<level>");
            this.stringBuilder.Append(string.Format("{0}", reportLevel.ToString()));
            this.stringBuilder.AppendLine("</level>");

            this.stringBuilder.Append("\t<message>");
            this.stringBuilder.Append(string.Format("{0}", message));
            this.stringBuilder.AppendLine("</message>");

            this.stringBuilder.AppendLine("</log>");

            return this.stringBuilder.ToString();
        }
    }
}
