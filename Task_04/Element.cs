using System;
using System.Collections.Generic;
using System.Text;

namespace Task_04
{
    /// <summary>
    /// Tree structure for xml's elements
    /// </summary>
    class Element : IComparable<Element>
    {
        private string name;
        private string value;
        private SortedDictionary<string, string> attributes;
        private List<Element> children;

        public Element() {
            children = new List<Element>();
            attributes = new SortedDictionary<string, string>();
        }

        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }
        public SortedDictionary<string, string> Attributes { get => attributes; set => attributes = value; }
        
        public void AddChilds(Element element)
        {
            children.Add(element);
        }

        public int CompareTo(Element e)
        {
            return Name.CompareTo(e.Name);
        }

        public void Sort()
        {
            children.Sort();
            foreach(Element child in children)
            {
                child.Sort();
            }
        }

        public string AttributesToString()
        {
            StringBuilder attributesList = new StringBuilder();
            foreach (string key in attributes.Keys)
            {
                attributesList.Append(key + "-" + attributes[key] + "; ");
            }
            return attributesList.ToString();
        }
        
        /// <summary>
        /// Print all tree structure in tree view like:
        /// root
        ///   |-1 
        ///   | |-1.1
        ///   | \-1.2
        ///   \-2
        ///     |-2.1
        ///     |-2.2
        ///     \-2.3
        /// </summary>
        /// <param name="indent"></param>
        /// <param name="last">Flag for check last element in list</param>
        public void Print(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            StringBuilder result = new StringBuilder();
            result.Append(Name);
            if(!Value.Equals(" "))
            {
                result.Append(" value: " + Value);
            }
            if(!AttributesToString().Equals(""))
            {
                result.Append(" attributes: " + AttributesToString());
            }
            Console.WriteLine(result.ToString());
            for (int i = 0; i < children.Count; i++)
                children[i].Print(indent, i == children.Count - 1);
        }
    }
}
