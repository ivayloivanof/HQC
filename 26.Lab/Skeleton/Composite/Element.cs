namespace DOMBuilder
{
    using System;

    public class Element
    {
        public Element(string type, params Element[] children)
        {
            this.Type = type;
            this.ChildrenElement = children;
            this.View = true;
        }

        public string Type { get; private set; }

        public Element[] ChildrenElement { get; private set; }

        public bool View { get; set; }
        
        public void Display()
        {
            int numberWitespace = 0;
            if (this.ChildrenElement.Length == 0)
            {
                this.PrintTagWithoutChildren(this.Type, numberWitespace);
            }

            if (this.ChildrenElement.Length > 0)
            {
            }

            numberWitespace += 4;
        }

        private void PrintTagWithoutChildren(string tag, int witeSpace)
        {
            Console.WriteLine("{0}<{1}>", new string(' ', witeSpace), tag);
            Console.WriteLine("{0}</{1}>", new string(' ', witeSpace), tag);
            this.View = false;
        }
    }
}
