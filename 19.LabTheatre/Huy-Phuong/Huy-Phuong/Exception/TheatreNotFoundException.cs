namespace Theatre.Exception
{
    using System;

    internal class TheatreNotFoundException : Exception
    {
        public TheatreNotFoundException(string message)
            : base(message)
        {
        }
    }
}
