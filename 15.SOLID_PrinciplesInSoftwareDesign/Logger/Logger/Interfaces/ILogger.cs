namespace Logger.Interfaces
{
    internal interface ILogger
    {
        void Info(string message);

        void Error(string message);

        void Warning(string message);

        void Critical(string message);

        void Fatal(string message);
    }
}
