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
        string currentAnswer = string.Empty;
        bool? currentGrade = null;
        XElement? gradeElement;
        XElement? questionElement;

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

        /// <summary>
        /// Create an ungraded question and answer pair. GetQuestion compares the grade with input parameter skipPassed.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        public void AddQAG(string question, string answer)
        {
            if ((xml == null) || (xml.Root == null)) return;
            XElement? subtopicElement = GetSubTopicNode(subTopicIndex);
            if (subtopicElement == null) return;
            foreach (XElement node in subtopicElement.Descendants("questions"))
            {
                node.Add(new XElement("qaPair", new XElement("question", question), new XElement("answer", answer), new XElement("grade","-1")));
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

        /// <summary>
        /// Gets the current question, counting only unpassed questions if skipPassed.
        /// </summary>
        /// <param name="skipPassed"></param>
        /// <returns></returns>
        public string GetQuestion(bool skipPassed)
        {
            XElement? subtopicElement = GetSubTopicNode(subTopicIndex);
            if (subtopicElement == null) {return string.Empty; }
            int currentIndex = 0;
            string returnValue = string.Empty;

            foreach (XElement descElement in subtopicElement.Descendants("qaPair"))
            {
                foreach (XElement qNode in descElement.Descendants("grade"))
                {
                    gradeElement = qNode;
                    if ((qNode.Value == null) || (qNode.Value == "-1"))
                    {
                        currentGrade = null;
                    }
                    else
                    {
                        currentGrade = (qNode.Value == "0") ? false : true;
                    }
                }
                if (skipPassed && (currentGrade == true)) continue;

                if (currentIndex++ != questionIndex) continue;
                if (descElement.Value != null)
                {
                    questionElement = descElement;
                    foreach (XElement qNode in descElement.Descendants("question"))
                    {
                         returnValue = qNode.Value;
                    }
                    foreach (XElement qNode in descElement.Descendants("answer"))
                    {
                        currentAnswer = qNode.Value;
                    }

                }
            }
            return string.Empty;
        }

        public string getAnswer() { return currentAnswer; }

        public void markAnswerCorrect() { if (gradeElement != null) gradeElement.Value = "1"; }
        public void markAnswerIncorrect() { if (gradeElement != null) gradeElement.Value = "0"; }

        public void clearAllMarks()
        {
            foreach (XElement qNode in xml.Descendants("grade"))
            {
                qNode.Remove();
            }

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

        public void RemoveQuestion()
        {
            if (questionElement == null)  return; 
            questionElement.Remove();
            questionElement = null;
            gradeElement = null;
            currentAnswer = string.Empty;
            questionIndex = 0;
        }

        public void UpdateXMLFile(string subjectName)
        {
            if ((xml == null) || (xml.Root == null)) { return; }
            XElement? subjectElement = GetSubjectNode(subjectIndex);
            if (subjectElement == null) { return; }
            subjectElement.Save(rootPath + subjectName + ".xml"); 
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
