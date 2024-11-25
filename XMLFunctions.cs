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
        static readonly string subjectFileExtension = ".xml";
        List<string> subjects = [];
        XDocument? subjectXml;
        XElement? topicXml;
        XElement? SubTopicXml;
        XElement? QuestionXml;
        int questionIndex = 0; 
        public string newQuestion = string.Empty;
        string currentAnswer = string.Empty;
        bool? currentGrade = null;
        XElement? gradeElement;
        XElement? questionElement;

        /// <summary>
        /// Reads the xml directory and extracts the top-level subject names from the xml file names
        /// </summary>
        /// <returns>The names of the top-level subjects</returns>
        public List<string> InitializeDoc()
        {
            foreach (string filePath in Directory.GetFiles(rootPath, "*.xml")) 
                if (!string.IsNullOrEmpty(filePath)) subjects.Add( Path.GetFileNameWithoutExtension(filePath));

            return subjects;
        }

        public void AddSubject(string subject)
        {
            XElement subjectNameElement = new XElement("subjectName", subject);
            XElement subjectElement = new XElement("subject", subjectNameElement);
            subjectXml = new XDocument(subjectElement);
            if (subjects != null) subjects.Add( subject);
            UpdateXMLFile(subject);
        }

        public void AddTopic(string topic, int count) 
        {
            if (subjectXml == null) return;

            subjectXml.Add(new XElement("topic", new XElement("topicName", topic)));
            SubTopicXml = null;
        }
        public void AddSubTopic(string subTopic, int count) 
        {
            XElement? topicElement = topicXml;
            if (topicElement == null) return;
            topicElement.Add(new XElement("subTopic", new XElement("subTopicName", subTopic)));
        }

        /// <summary>
        /// Create an ungraded question and answer pair. GetQuestion compares the grade with input parameter skipPassed.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        public void AddQAG(string question, string answer)
        {
            XElement? subtopicElement = topicXml;
            if (subtopicElement == null) return;
            foreach (XElement node in subtopicElement.Descendants("questions"))
            {
                node.Add(new XElement("qaPair", new XElement("question", question), new XElement("answer", answer), new XElement("grade","-1")));
                return;
            }
        }

        public Collection<string> UpdateSelectedSubject(int selectedIndex)
        {
            if (subjects == null) return new Collection<string>();

            Collection<string> items = [];
            subjectXml = XDocument.Load(rootPath + subjects[selectedIndex] + subjectFileExtension);

            if (subjectXml == null)  return items; 

            foreach (XElement kiddle in subjectXml.Descendants("topicName"))
            {
                items.Add(kiddle.Value);
            }

            return items;
        }

        public Collection<string> UpdateSelectedTopic(int selectedIndex)
        {
            Collection<string> items = [];
            topicXml = GetTopicNode(selectedIndex);
            if (topicXml == null) { return items; }

            foreach (XElement descElement in topicXml.Descendants("subTopicName"))
            {
                items.Add(descElement.Value);
            }

            return items;
        }

        public void UpdateSelectedSubtopic(int selectedIndex)
        {
            SubTopicXml = GetSubTopicNode(selectedIndex);
        }

        /// <summary>
        /// Gets the current question, counting only unpassed questions if skipPassed.
        /// </summary>
        /// <param name="skipPassed"></param>
        /// <returns></returns>
        public string GetQuestion(bool skipPassed)
        {
            XElement? subtopicElement = topicXml;
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
            if (subjectXml == null) return;
            foreach (XElement qNode in subjectXml.Descendants("grade"))
            {
                qNode.Remove();
            }

        }

        public void RemoveSubject(int index)
        {
            if ((subjects == null) || (subjects.Count < index + 1))  return; 
            subjectXml = null;
            if (File.Exists(rootPath + subjects[index] + subjectFileExtension)) File.Delete(rootPath + subjects[index] + subjectFileExtension);
            subjects.RemoveAt(index);
        }
        public void RemoveTopic(int index)
        {
            XElement? topicNode = GetTopicNode(index);
            if (topicNode == null)  return; 
            topicNode.Remove();
        }

        public void RemoveSubTopic(int index)
        {
            XElement? subtopicNode = GetSubTopicNode(index);
            if (subtopicNode == null)  return; 
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
            if (subjectXml == null) { return; }
            subjectXml.Save(rootPath + subjectName + subjectFileExtension); 
        }

        private XElement? GetSubjectNode(int index)
        {
            if (subjects == null) return null;
            subjectXml = XDocument.Load(rootPath + subjects[index] + subjectFileExtension);
            foreach (XElement node in subjectXml.Descendants("subject")) return node;
            return null;
        }

        private XElement? GetTopicNode(int index)
        {
            if (subjectXml == null)  return null; 
            int currentIndex = 0;

            foreach (XElement descElement in subjectXml.Descendants())
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
            if (topicXml == null)  return null; 
            int currentIndex = 0;

            foreach (XElement descElement in topicXml.Descendants())
            {
                if (descElement.Name.LocalName == "subtopic") 
                {
                    if (currentIndex++ == index)
                    {
                        SubTopicXml = descElement;
                        return descElement;
                    }
                }
            }
            return null;
        }

        private XElement? GetQuestionNode(int index)
        {
            XElement? subTopicElement = topicXml;
            if (subTopicElement == null)  return null; 
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
    }
}
