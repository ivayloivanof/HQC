namespace Theater.Exception
{
    using System;

    public class TimeDurationOverlapException : Exception
    {
        public TimeDurationOverlapException(string mesasge)
            : base(mesasge)
        {
        }
    }
}