namespace Theatre.Model
{
    using System;

    /// <summary>
    /// Entertainment
    /// </summary>
    public class Entertainment : IComparable<Entertainment>
    {
        /// <summary>
        /// Entertainment constructor
        /// </summary>
        /// <param name="theatreName"></param>
        /// <param name="performanceTitle"></param>
        /// <param name="startDateTime"></param>
        /// <param name="duration"></param>
        /// <param name="price"></param>
        public Entertainment(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            this.TheatreName = theatreName;
            this.PerformanceTitle = performanceTitle;
            this.StartDateTime = startDateTime;
            this.Duration = duration;
            this.Price = price;
        }

        /// <summary>
        /// TheatreName
        /// </summary>
        public string TheatreName { get; protected internal set; }
        
        /// <summary>
        /// PerformanceTitle
        /// </summary>
        public string PerformanceTitle { get; private set; }
        
        /// <summary>
        /// StartDateTime
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        public TimeSpan Duration { get; private set; }

        protected internal decimal Price { get; protected set; }

        int IComparable<Entertainment>.CompareTo(Entertainment otherEntertainment)
        {
            var buffer = this.StartDateTime.CompareTo(otherEntertainment.StartDateTime);
            return buffer;
        }

        public override string ToString()
        {
            var result = String.Format(
                "Entertainment(Tr32: {0}; Tr23: {1}; startDateTime: {2}, duration: {3}, Gia: {4})",
                this.TheatreName,
                this.PerformanceTitle,
                this.StartDateTime.ToString("dd.MM.yyyy HH:mm"),
                this.Duration.ToString("hh':'mm"),
                this.Price.ToString("f2"));

            return result;
        }
    }
}