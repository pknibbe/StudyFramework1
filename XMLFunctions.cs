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
        static readonly string rootPath = "D:\\repos/C#/StudyFramework1/XML/";
        static readonly string subjectFileExtension = ".xml";
        readonly List<string> subjects = [];
        XDocument? subjectXml;
        XElement? subjectElement;
        string? subjectName;
        XElement? topicElement;
        XElement? subTopicElement;
        XElement? questionElement = null;
        XElement? answerElement = null;
        XElement? gradeElement = null;
        XElement? qaElement;
        int questionIndex = 0; 
        public string newQuestion = string.Empty;
        string currentAnswer = string.Empty;
        bool? currentGrade = null;

        /// <summary>
        /// Reads the xml directory and extracts the top-level subject names from the xml file names
        /// </summary>
        /// <returns>The names of the top-level subjects</returns>
        public List<string> InitializeDoc()
        {
            foreach (string filePath in Directory.GetFiles(rootPath, "*" + subjectFileExtension)) 
                if (!string.IsNullOrEmpty(filePath)) subjects.Add( Path.GetFileNameWithoutExtension(filePath));

            return subjects;
        }

        /// <summary>
        /// Creates a new subject xml document if it doesn't already exist
        /// </summary>
        /// <param name="subject"></param>
        public void AddSubject(string subject)
        {
            if (File.Exists(rootPath + subject + subjectFileExtension))
            {
                //labelResult.Text = subject + " already exists";
                return;
            }
            subjectElement = new XElement("subject", new XElement("subjectName", subject));
            subjectXml = new XDocument(subjectElement);
            subjects?.Add( subject);
            subjectName = subject;
            UpdateXMLFile(subjectName);
        }

        /// <summary>
        /// Add a major topic to the current subject xml
        /// </summary>
        /// <param name="topic"></param>
        public void AddTopic(string topic) 
        {
            XElement newTopicNameElement = new("topicName", topic);
            if ((subjectElement == null) || subjectElement.Descendants("topicName").Contains(newTopicNameElement)) return;
            topicElement = new XElement("topic", newTopicNameElement);
            subjectElement.Add(topicElement);
            subTopicElement = null;
            if (!string.IsNullOrEmpty(subjectName)) UpdateXMLFile(subjectName);
        }

        /// <summary>
        /// Add a minor topic to the current major topic in the subject xml
        /// </summary>
        /// <param name="subTopic"></param>
        public void AddSubTopic(string subTopic) 
        {
            XElement newSubTopicNameElement = new("subTopicName", subTopic);
            if ((topicElement == null) || topicElement.Descendants("subTopicName").Contains(newSubTopicNameElement)) return;
            subTopicElement = new XElement("subTopic", newSubTopicNameElement);
            topicElement.Add(subTopicElement);
            if (!string.IsNullOrEmpty(subjectName)) UpdateXMLFile(subjectName);
        }

        /// <summary>
        /// Create an ungraded question and answer pair. GetQuestion compares the grade with input parameter skipPassed.
        /// </summary>
        /// <param name="question">The question to ask the user</param>
        /// <param name="answer">The answer to show the user</param>
        public void AddQAG(string question, string answer)
        {
            questionElement = new XElement("question", question);
            answerElement = new XElement("answer", answer);
            gradeElement = new XElement("grade", "-1");
            AddQAGElements();
        }

        /// <summary>
        /// Loads the current subject from the xml files
        /// </summary>
        /// <param name="selectedIndex"></param>
        /// <returns>The names of the topics within the subject</returns>
        public Collection<string> UpdateSelectedSubject(int selectedIndex)
        {
            if (subjects == null) return [];
            subjectName = subjects[selectedIndex];

            Collection<string> items = [];
            if (!File.Exists(rootPath + subjects[selectedIndex] + subjectFileExtension)) return items;
            subjectXml = XDocument.Load(rootPath + subjects[selectedIndex] + subjectFileExtension);

            foreach (XElement node in subjectXml.Descendants("subject")) subjectElement = node;

            if (subjectElement == null)  return items; 

            foreach (XElement descTopicElement in subjectElement.Descendants("topicName"))
            {
                items.Add(descTopicElement.Value);
            }

            return items;
        }

        /// <summary>
        /// Loads the current major topic from the subject xml
        /// </summary>
        /// <param name="selectedIndex"></param>
        /// <returns>The names of the minor topics within the major topic</returns>
        public Collection<string> UpdateSelectedTopic(int selectedIndex)
        {
            Collection<string> items = [];
            topicElement = GetTopicNode(selectedIndex);
            if (topicElement == null) { return items; }

            foreach (XElement descElement in topicElement.Descendants("subTopicName"))
            {
                items.Add(descElement.Value);
            }

            return items;
        }

        /// <summary>
        /// Loads the current minor topic from the major topic. Does not preload the questions as only one at a time will be displayed
        /// </summary>
        /// <param name="selectedIndex"></param>
        public void UpdateSelectedSubtopic(int selectedIndex)
        {
            subTopicElement = GetSubTopicNode(selectedIndex);
            questionIndex = 0;
        }

        /// <summary>
        /// Gets the current question, counting only unpassed questions if skipPassed.
        /// </summary>
        /// <param name="skipPassed"></param>
        /// <returns></returns>
        public string GetQuestion(bool skipPassed)
        {
            if (subTopicElement == null) {return string.Empty; }
            int currentIndex = 0;
            string returnValue = string.Empty;
            currentGrade = null;

            foreach (XElement descElement in subTopicElement.Descendants("qaPair"))
            {
                if (descElement == null) return returnValue;
                foreach (XElement qNode in descElement.Descendants("grade"))
                {
                    gradeElement = qNode;
                    if ((gradeElement != null) && (qNode.Value != null) && (qNode.Value != "-1"))
                    {
                        currentGrade = qNode.Value != "0";
                    }
                }
                if (skipPassed && (currentGrade == true)) continue;

                if (currentIndex++ != questionIndex) continue;

                qaElement = descElement;

                foreach (XElement qNode in descElement.Descendants("question"))
                {
                    questionElement = qNode;
                    returnValue = qNode.Value;
                }
                foreach (XElement qNode in descElement.Descendants("answer"))
                {
                    answerElement = qNode;
                    currentAnswer = qNode.Value;
                }
                if (gradeElement == null)
                {
                    gradeElement = new XElement("grade", "-1");
                    qaElement.Remove();
                    if (questionElement != null)
                    {
                        qaElement = new XElement("qaPair", questionElement, answerElement, gradeElement);
                        descElement.Add(qaElement);
                    }
                }
                return returnValue;
            }
            return returnValue;
        }

        public string GetAnswer() { return currentAnswer; }

        public void MarkAnswerCorrect() 
        {
            if (gradeElement != null)
            {
                gradeElement.Value = "1";
            }
            else
            {
                gradeElement = new XElement("grade", "1");
            }
            if (subTopicElement == null)  return;
            qaElement?.Remove();
            AddQAGElements();

        }
        public void MarkAnswerIncorrect()
        {
            if (gradeElement != null)
            {
                gradeElement.Value = "0";
            }
            else
            {
                gradeElement = new XElement("grade", "0");
            }
            if (subTopicElement == null) return;
            qaElement?.Remove();
            AddQAGElements();
        }

        public void ClearAllMarks()
        {
            if (subjectXml == null) return;
            foreach (XElement qNode in subjectXml.Descendants("grade"))
            {
                qNode.Remove();
            }
            if (!string.IsNullOrEmpty(subjectName)) UpdateXMLFile(subjectName);
        }

        public void RemoveSubject(int index)
        {
            if ((subjects == null) || (subjects.Count < index + 1))  return; 
            subjectXml = null;
            if (File.Exists(rootPath + subjects[index] + subjectFileExtension)) File.Delete(rootPath + subjects[index] + subjectFileExtension);
            subjects.RemoveAt(index);
            subjectElement = null;
            subjectName = string.Empty;
        }
        public void RemoveTopic()
        {
            if (topicElement == null)  return;
            topicElement.Remove();
            if (!string.IsNullOrEmpty(subjectName)) UpdateXMLFile(subjectName);
            topicElement = null;
        }

        public void RemoveSubTopic()
        {
            if (subTopicElement == null)  return;
            subTopicElement.Remove();
            if (!string.IsNullOrEmpty(subjectName)) UpdateXMLFile(subjectName);
            subTopicElement = null;
        }

        public void RemoveQuestion()
        {
            if (qaElement == null)  return; 
            qaElement.Remove();
            qaElement = null;
            gradeElement = null;
            currentAnswer = string.Empty;
            questionIndex = 0;
            if (!string.IsNullOrEmpty(subjectName)) UpdateXMLFile(subjectName);
        }

        public void UpdateXMLFile(string subjectName)
        {
            if (subjectXml == null) { return; }
            subjectXml.Save(rootPath + subjectName + subjectFileExtension); 
        }

        public void ResetQuestionIndex()
            { questionIndex = 0; }

        private void AddQAGElements()
        {
            if (subTopicElement == null) return;
            if (subTopicElement.Descendants("question").Contains(questionElement)) return;
            IEnumerable<XElement> elements = subTopicElement.Descendants("questions");
            if ((elements == null) || (!elements.Any())) subTopicElement.Add(new XElement("questions"));

            foreach (XElement node in subTopicElement.Descendants("questions"))
            {
                node?.Add(new XElement("qaPair", questionElement, answerElement, gradeElement));
                if (!string.IsNullOrEmpty(subjectName)) UpdateXMLFile(subjectName);
            }
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
            if (topicElement == null)  return null; 
            int currentIndex = 0;

            foreach (XElement descElement in topicElement.Descendants())
            {
                if (descElement.Name.LocalName == "subtopic") 
                {
                    if (currentIndex++ == index)
                    {
                        subTopicElement = descElement;
                        return descElement;
                    }
                }
            }
            return null;
        }
    }
}
