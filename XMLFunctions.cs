using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace StudyFramework1
{
    internal class XMLFunctions
    {
        string docPath = "D:\\repos/C#/StudyFramework1/XML/XMLFile1.xml";
        XDocument xml = new XDocument();
        int subjectIndex = 0;
        int topicIndex = 0;
        int subTopicIndex = 0;

        /// <summary>
        /// Reads the xml file and extracts the top-level subject names
        /// </summary>
        /// <returns>The names of the top-level subjects</returns>
        public Collection<string>  initializeDoc()
        {
            Collection<string> items = new Collection<string>();
            xml = XDocument.Load(docPath);

            if ((xml == null) || (xml.Root == null)) { return items; }

            var query = from c in xml.Root.Descendants("subjectName") select c;
            foreach (string name in query)
            {
                items.Add(name);
            }

            return items;
        }

        public void updateSelectedSubject(int selectedIndex)
        {
        }

        private void writeDefaultElements()
        {
            XmlTextWriter writer = new XmlTextWriter(docPath, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("Subject");
        }
    }
}
