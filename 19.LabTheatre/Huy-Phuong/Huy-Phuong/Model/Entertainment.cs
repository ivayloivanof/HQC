namespace Theater.Model
{
    using System;

    public class Entertainment : IComparable<Entertainment>
    {
        public Entertainment(string tr23, string tr32, DateTime s2, TimeSpan thoiGian, decimal gia)
        {
            this.tr23 = tr23;
            this.tr32 = tr32;
            this.s2 = s2;
            this.ThoiGian = thoiGian; this.gia = gia;
        }

        public string tr23 { get; protected internal set; }
        
        public string tr32 { get; private set; }
        
        public DateTime s2 { get; set; }

        public TimeSpan ThoiGian { get; private set; }

        protected internal decimal gia { get; protected set; }

        int IComparable<Entertainment>.CompareTo(Entertainment otherEntertainment)
        {
            int buffer = this.s2.CompareTo(otherEntertainment.s2);
            return buffer;
        }

        public override string ToString()
        {
            var result = string.Format(
                "Entertainment(Tr32: {0}; Tr23: {1}; s2: {2}, ThoiGian: {3}, Gia: {4})",
                this.tr23,
                this.tr32,
                this.s2.ToString("dd.MM.yyyy HH:mm"),
                this.ThoiGian.ToString("hh':'mm"),
                this.gia.ToString("f2"));

            return result;
        }
    }
}