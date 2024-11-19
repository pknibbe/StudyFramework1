using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace StudyFramework1
{
    internal class XMLFunctions
    {
        readonly string docPath = "D:\\repos/C#/StudyFramework1/XML/XMLFile1.xml";
        XDocument xml = new();
        int subjectIndex = 0;
        int topicIndex = 0;
        int subTopicIndex = 0;

        /// <summary>
        /// Reads the xml file and extracts the top-level subject names
        /// </summary>
        /// <returns>The names of the top-level subjects</returns>
        public Collection<string> InitializeDoc()
        {
            Collection<string> items = [];
            xml = XDocument.Load(docPath);

            if ((xml == null) || (xml.Root == null)) { return items; }

            var query = from c in xml.Root.Descendants("subjectName") select c;
            if ((query == null) || (query.ToString() == string.Empty)) { return items; }
            foreach (XElement element in query)
            {
                if (element.FirstNode == null) { continue; }
                items.Add(element.FirstNode.ToString());
            }

            return items;
        }

        public void AddSubject(string subject) { }
        public void AddTopic(string topic) { }
        public void AddSubTopic(string subTopic) { }

        public Collection<string> UpdateSelectedSubject(int selectedIndex)
        {
            topicIndex = 0; subTopicIndex = 0;

            Collection<string> items = [];
            if ((xml == null) || (xml.Root == null)) { return items; }
            XElement? subjectElement = GetSubjectNode(selectedIndex);
            if (subjectElement == null) { return items; }
            subjectIndex = selectedIndex;

            foreach (XElement kiddle in subjectElement.Descendants("topicName"))
            {
                items.Add(kiddle.Value);
            }

            return items;
        }

        public Collection<string> UpdateSelectedTopic(int selectedIndex)
        {
            subTopicIndex = 0;
            Collection<string> items = [];
            if ((xml == null) || (xml.Root == null)) { return items; }
            XElement? topicElement = GetTopicNode(selectedIndex);
            if (topicElement == null) { return items; }
            topicIndex = selectedIndex;

            foreach (XElement descElement in topicElement.Descendants("subTopicName"))
            {
                items.Add(descElement.Value);
            }

            return items;
        }

        public Collection<string> UpdateSelectedSubtopic(int selectedIndex)
        {
            Collection<string> items = [];
            if ((xml == null) || (xml.Root == null)) { return items; }
            XElement? subtopicElement = GetSubTopicNode(selectedIndex);
            if (subtopicElement == null) { return items; }
/*            topicIndex = selectedIndex;

            foreach (XElement descElement in subtopicElement.Descendants("subTopicName"))
            {
                items.Add(descElement.Value);
            }*/

            return items;
        }

        public void RemoveSubject(int index)
        {
            if ((xml == null) || (xml.Root == null)) { return; }
            XElement? subjectNode = GetSubjectNode(index);
            if (subjectNode == null) { return; }
            subjectNode.Remove();
        }
        public void RemoveTopic(int index)
        {
            if ((xml == null) || (xml.Root == null)) { return; }
            XElement? topicNode = GetTopicNode(index);
            if (topicNode == null) { return; }
            topicNode.Remove();
        }

        public void RemoveSubTopic(int index)
        {
            if ((xml == null) || (xml.Root == null)) { return; }
            XElement? subtopicNode = GetSubTopicNode(index);
            if (subtopicNode == null) { return; }
            subtopicNode.Remove();
        }

        public void UpdateXMLFile() { xml.Save(docPath); }

        private XElement? GetSubjectNode(int index)
        {
            int currentIndex = 0;
            if ((xml == null) || (xml.Root == null)) { return null; }

            IEnumerable<XElement> desc = xml.Root.Descendants();
            foreach (XElement descElement in desc)
            {
                if ((descElement.Name.LocalName == "subject") && (currentIndex == index))
                {
                    return descElement;
                }
            }
            return null;
        }
        private XElement? GetTopicNode(int index)
        {
            if ((xml == null) || (xml.Root == null)) { return null; }
            XElement? subjectElement = GetSubjectNode(subjectIndex);
            if (subjectElement == null) { return null; }
            int currentIndex = 0;

            foreach (XElement descElement in subjectElement.Descendants())
            {
                if ((descElement.Name.LocalName == "topic") && (currentIndex == index))
                {
                    return descElement;
                }
            }
            return null;
        }
        private XElement? GetSubTopicNode(int index)
        {
            if ((xml == null) || (xml.Root == null)) { return null; }
            XElement? topicElement = GetTopicNode(topicIndex);
            if (topicElement == null) { return null; }
            int currentIndex = 0;

            foreach (XElement descElement in topicElement.Descendants())
            {
                if ((descElement.Name.LocalName == "subTopic") && (currentIndex == index))
                {
                    return descElement;
                }
            }
            return null;
        }


        private void WriteDefaultElements()
        {
            XmlTextWriter writer = new(docPath, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("Subject");
        }
    }
}
