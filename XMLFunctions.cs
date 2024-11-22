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
        readonly static string rootPath = "D:\\repos/C#/StudyFramework1/XML/";
        readonly string docPath = rootPath + "XMLFile1.xml";
        XDocument xml = new();
        int subjectIndex = 0;
        int topicIndex = 0;
        int subTopicIndex = 0;
        int questionIndex = 0; 
        public string newQuestion = string.Empty;

        /// <summary>
        /// Reads the xml file and extracts the top-level subject names
        /// </summary>
        /// <returns>The names of the top-level subjects</returns>
        public Collection<string> InitializeDoc()
        {
            Collection<string> items = [];
            xml = XDocument.Load(docPath);

            if ((xml == null) || (xml.Root == null))  return items; 

            var query = from c in xml.Root.Descendants("subjectName") select c;
            if ((query == null) || (query.ToString() == string.Empty))  return items; 
            foreach (XElement element in query)
            {
                if (element.FirstNode == null)  continue; 
                items.Add(element.FirstNode.ToString());
            }

            return items;
        }

        public void AddSubject(string subject, int count) 
        {
            if ((xml == null) || (xml.Root == null)) return;
            foreach (XElement node in xml.Root.Descendants("subjects"))
            {
                node.Add(new XElement("subject", new XElement("subjectName", subject)));
                subjectIndex = count;
                return;
            }
        }
        public void AddTopic(string topic, int count) 
        {
            if ((xml == null) || (xml.Root == null)) return;
            XElement? subjectElement = GetSubjectNode(subjectIndex);
            if (subjectElement == null) return;
            foreach (XElement node in subjectElement.Descendants("Topics"))
            {
                node.Add(new XElement("topic", new XElement("topicName", topic)));
                topicIndex = count;
                return;
            }
        }
        public void AddSubTopic(string subTopic, int count) 
        {
            if ((xml == null) || (xml.Root == null)) return;
            XElement? topicElement = GetTopicNode(topicIndex);
            if (topicElement == null) return;
            foreach (XElement node in topicElement.Descendants("subTopics"))
            {
                node.Add(new XElement("subTopic", new XElement("subTopicName", subTopic)));
                subTopicIndex = count;
                return;
            }
        }

        public void AddQAG(string question, string answer)
        {
            if ((xml == null) || (xml.Root == null)) return;
            XElement? subtopicElement = GetSubTopicNode(subTopicIndex);
            if (subtopicElement == null) return;
            foreach (XElement node in subtopicElement.Descendants("questions"))
            {
                node.Add(new XElement("qaPair", new XElement("question", question), new XElement("answer", answer), new XElement("grade",0)));
                return;
            }
        }

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

        public void UpdateSelectedSubtopic(int selectedIndex)
        {
            if ((xml == null) || (xml.Root == null)) { return; }
            XElement? subtopicElement = GetSubTopicNode(selectedIndex);
            if (subtopicElement == null) { return; }
            subTopicIndex = selectedIndex;
            questionIndex = 0;

/*            foreach (XElement descElement in subtopicElement.Descendants("qaPair"))
            {
                if (descElement.Value != null)
                {
                    foreach (XElement qNode in descElement.Descendants("question"))
                    {
                        if (qNode.Value != null)
                        {
                            foreach (XElement aNode in descElement.Descendants("answer"))
                            {
                                if (aNode.Value != null)
                                {
                                    qaPairs.Add(qNode.Value, aNode.Value);
                                }
                            }
                        }
                    }
                }
            }*/
        }

        public string GetQuestion(bool skipPassed)
        {
            XElement? subtopicElement = GetSubTopicNode(subTopicIndex);
            if (subtopicElement == null) {return string.Empty; }
            int currentIndex = 0;

            foreach (XElement descElement in subtopicElement.Descendants("qaPair"))
            {
                if (descElement.Value != null)
                {
                    foreach (XElement qNode in descElement.Descendants("question"))
                    {
                        if (qNode.Value != null)
                        {
                            if (currentIndex++ == questionIndex) return qNode.Value;
                        }
                    }
                }
            }
            return string.Empty;
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

        public void RemoveQuestion(int index)
        {
            if ((xml == null) || (xml.Root == null)) { return; }
            XElement? questionNode = GetQuestionNode(index);
            if (questionNode == null) { return; }
            questionNode.Remove();
        }

        public void UpdateXMLFile(string subjectName)
        {
            if ((xml == null) || (xml.Root == null)) { return; }
            XElement? subjectElement = GetSubjectNode(subjectIndex);
            if (subjectElement == null) { return; }
            subjectElement.Save(rootPath + subjectName); 
        }

        private XElement? GetSubjectNode(int index)
        {
            int currentIndex = 0;
            if ((xml == null) || (xml.Root == null)) { return null; }

            foreach (XElement descElement in xml.Root.Descendants())
            {
                if (descElement.Name.LocalName == "subject")
                {
                    if (currentIndex++ == index) return descElement;
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
                if (descElement.Name.LocalName == "topic") 
                {
                    if (currentIndex++ == index) return descElement;
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
                if (descElement.Name.LocalName == "subtopic") 
                {
                    if (currentIndex++ == index) return descElement;
                }
            }
            return null;
        }

        private XElement? GetQuestionNode(int index)
        {
            if ((xml == null) || (xml.Root == null)) { return null; }
            XElement? subTopicElement = GetSubTopicNode(subTopicIndex);
            if (subTopicElement == null) { return null; }
            int currentIndex = 0;

            foreach (XElement descElement in subTopicElement.Descendants())
            {
                if (descElement.Name.LocalName == "qaPair")
                {
                    if (currentIndex++ == index) return descElement;
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
