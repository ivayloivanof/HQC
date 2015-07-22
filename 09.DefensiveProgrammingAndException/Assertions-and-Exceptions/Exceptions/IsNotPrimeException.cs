namespace Exceptions_Homework
{
    using System;

    public class IsNotPrimeException : Exception
    {
        public IsNotPrimeException(string messages) 
            : base(messages)
        {
        }
    }
}
