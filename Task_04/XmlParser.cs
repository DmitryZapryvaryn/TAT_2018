using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_04
{
    /// <summary>
    /// Class for parsing xml documents
    /// </summary>
    class XmlParser
    {
        private string xmlFile;
        private int currentIndex = 0;

        /// <summary>
        /// Builds a string which contains all xml file without multiple whitespaces
        /// </summary>
        /// <param name="url">Path to xml file</param>
        public XmlParser(string url)
        {
            StringBuilder result = new StringBuilder();
            foreach (string str in File.ReadAllLines(url))
            {
                result.Append(str);
            }
            
            //Replace multiple whitespaces to one whitespace
            xmlFile = Regex.Replace(result.ToString(), @"\s+", " ");
        }

        /// <summary>
        /// Main method to parse xml's elements
        /// </summary>
        /// <returns>
        /// Tree structure of xml's elements
        /// </returns>
        public Element ParseElement()
        {
            Element element = new Element();

            string startTag = GetNextTag();

            element.Name = GetNameOfTag(startTag);
            element.Value = GetTagValue(startTag);
            element.Attributes = GetAttributes(startTag);

            string closeTag = '/' + element.Name;

            //       </tagOne> _(whitespace)_ <tagTwo>
            //TagOneLength->|1        2       3
            currentIndex += startTag.Length + 3; 

            while (!GetNameOfTag(GetNextTag()).Equals(closeTag))
            {
                element.AddChilds(ParseElement());
            }

            currentIndex = xmlFile.IndexOf(closeTag, currentIndex) + closeTag.Length + 1;

            return element;
        }

        private string GetNextTag()
        {
            int startIndex = xmlFile.IndexOf('<', currentIndex);
            int endIndex = xmlFile.IndexOf('>', startIndex);

            return xmlFile.Substring(startIndex + 1, endIndex - startIndex - 1);
        }

        private string GetNameOfTag(string tag)
        {
            if (!tag.Contains(" "))
            {
                return tag;
            }

            int endNameTagIndex = tag.IndexOf(' ');
            return tag.Substring(0, endNameTagIndex);
        }

        private string GetTagValue(string tagName)
        {
            int startIndex = xmlFile.IndexOf('>', currentIndex) + 1;
            int endIndex = xmlFile.IndexOf('<', startIndex);
            return new StringBuilder().Append(
                xmlFile.Substring(startIndex, endIndex - startIndex)).ToString();
        }

        private SortedDictionary<string, string> GetAttributes(string tag)
        {
            SortedDictionary<string, string> attributes = new SortedDictionary<string, string>();
            string attributeName;
            string attributeValue;

            for (int i = tag.IndexOf(' '); i + 1 < tag.Length;)
            { 
                if(i == -1)
                {
                    break;
                }
                int startNameIndex = i;
                int endNameIndex = tag.IndexOf('=', startNameIndex);
                attributeName = tag.Substring(startNameIndex + 1, endNameIndex - startNameIndex - 1);

                int endValueIndex = tag.IndexOf('"', endNameIndex + 2);
                attributeValue = tag.Substring(endNameIndex + 2, endValueIndex - endNameIndex - 2);

                attributes.Add(attributeName, attributeValue);

                i = endValueIndex + 1;

            }
            return attributes;
        }
    }
}
