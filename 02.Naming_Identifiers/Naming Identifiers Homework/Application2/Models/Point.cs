namespace Mines.Models
{
    using System;

    class Point
    {
        private string name;
        private int points;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name", "This name is empty!");
                }

                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Points", "This points cannot be negative!");
                }
                this.points = value;
            }
        }

        public Point(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }
}
