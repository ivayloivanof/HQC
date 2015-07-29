namespace Theatre.Interface
{
    using System;
    using System.Collections.Generic;

    using global::Theatre.Model;

    // Do not modify the interface members
    // Moving the interface to separate namespace is allowed
    // Adding XML documentation is allowed
    // TODO: document this interface definition
    internal interface IPerformanceDatabase
    {
        // TODO: document this method, its parameters, return value, exceptions, etc.
        void AddTheatre(string theatreName);

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<string> ListTheatres();

        // TODO: document this method, its parameters, return value, exceptions, etc.
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<Entertainment> ListAllPerformances();

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<Entertainment> ListPerformances(string theatreName);
    }
}
