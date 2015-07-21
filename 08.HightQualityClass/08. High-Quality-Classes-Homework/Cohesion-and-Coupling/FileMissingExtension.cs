namespace CohesionAndCoupling
{
    using System;

    public class FileMissingExtension : Exception
    {
        public FileMissingExtension(string messages) 
            : base(messages)
        {
        }
    }
}
