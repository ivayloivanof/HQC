namespace Theatre.Exception
{
    using System;

    /// <summary>
    /// TimeDurationOverlapException
    /// </summary>
    public class TimeDurationOverlapException : Exception
    {
        /// <summary>
        /// TimeDurationOverlapException constructor
        /// </summary>
        /// <param name="mesasge"></param>
        public TimeDurationOverlapException(string mesasge)
            : base(mesasge)
        {
        }
    }
}