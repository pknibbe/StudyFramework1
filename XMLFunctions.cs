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
        // block of variables used in current version of functions
        int questionIndex = 0;
        XDocument? subTopicDoc;
        IEnumerable<XElement>? questionAnswerGroups;
        string? currentSubTopicXMLPath;
        string? currentQuestion;
        string? currentAnswer;
        bool? currentGrade;
        // end of block of current variables

        /*        XDocument? subjectXml;
                XElement? subjectElement;
                string? subjectName;

                readonly List<XElement> topics = [];
                XElement? topicElement;
                string? topicName;

                readonly List<XElement> subTopics = [];
                XElement? subTopicElement;
                string? subTopicName;*/



        /*        static readonly string rootPath = "D:\\repos/C#/StudyFramework1/XML/";
                static readonly string subjectFileExtension = ".xml";
                static readonly string separator = "/";
                readonly List<string> subjects = [];
                string? subjectDirectoryPath;
                string? topicDirectoryPath;
                string? subTopicDirectoryPath;
                XElement? questionElement = null;
                XElement? answerElement = null;
                XElement? gradeElement = null;
                XElement? qaElement;
                public string newQuestion = string.Empty;
                string currentAnswer = string.Empty;
                bool? currentGrade = null;*/

        /// <summary>
        /// Uses the xmlPath to load the xml if it differs from the current path. 
        /// Looks up the current question based on index and whether the user wants to skip questions that have already been marked as answered correctly
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="skipPassed"></param>
        /// <returns>The text of the current question</returns>
        public string GetCurrentQuestion(string xmlPath, bool skipPassed)
        {
            string retVal = "Unable to find the current question.";
            if ((string.IsNullOrEmpty(currentSubTopicXMLPath)) || !(currentSubTopicXMLPath == xmlPath))
            {
                subTopicDoc = XDocument.Load(xmlPath);
                questionAnswerGroups = subTopicDoc.Descendants("qaPair");
                currentSubTopicXMLPath = xmlPath;
            }

            int currentIndex = 0;
            if (questionAnswerGroups == null) return retVal;
            foreach (XElement qap in questionAnswerGroups)
            {
                if (skipPassed && QuestionIsPassed(qap)) continue;
                if (questionIndex == currentIndex++)
                {
                    foreach (XElement question in qap.Descendants("question")) currentQuestion = question.Value;
                    foreach (XElement answer in qap.Descendants("answer")) currentAnswer = answer.Value;
                    foreach (XElement grade in qap.Descendants("grade")) currentGrade = QuestionIsPassed(grade);

                    if (string.IsNullOrEmpty(currentQuestion)) return string.Empty;
                    return currentQuestion;
                }                
            }
            return retVal;
        }

        public void AddSubTopic(string subTopicName, string subTopicDirectoryPath)
        {
            subTopicDoc = new XDocument(new XElement("subTopicName", subTopicName));
            subTopicDoc.Save(subTopicDirectoryPath);
            currentSubTopicXMLPath = subTopicDirectoryPath;
            questionIndex = 0;
        }

        private static bool QuestionIsPassed(XElement qap)
        {
            foreach (XElement grade in qap.Descendants("grade")) return (grade.Value == "1");
            return false;
        }

        // Functions below this point are based on an older way of managing the information in subject-wide xml files.

        /// <summary>
        /// Add a minor topic to the current major topic in the subject xml
        /// </summary>
        /// <param name="subTopic"></param>
 /*       public void AddSubTopic(string subTopic) 
        {
            XElement newSubTopicNameElement = new("subTopicName", subTopic);
            if ((topicElement == null) || topicElement.Descendants("subTopicName").Contains(newSubTopicNameElement)) return;
            subTopicElement = new XElement("subtopic", newSubTopicNameElement);
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
            if ((subjects == null) || (subjects.Count <= selectedIndex)) return [];
            subjectName = subjects[selectedIndex];
            subjectDirectoryPath = rootPath + "/" + subjectName;

            return GetTopicsFromSubjectXMLFile(selectedIndex);
        }

        /// <summary>
        /// Loads the current major topic from the subject xml
        /// </summary>
        /// <param name="selectedIndex"></param>
        /// <returns>The names of the minor topics within the major topic</returns>
        //public Collection<string> UpdateSelectedTopic(int selectedIndex)
        //{
        //    Collection<string> items = [];
        //    topicElement = GetTopicNode(selectedIndex);
        //    if (topics.Count > selectedIndex) topicName = topics[selectedIndex];
        //    subjectDirectoryPath = rootPath + "/" + subjectName;
        //    topicDirectoryPath = subjectDirectoryPath + "/" + topicName;

        //    return GetSubTopicsFromTopicXElement();
        //}

        /// <summary>
        /// Loads the current minor topic from the major topic. Does not preload the questions as only one at a time will be displayed
        /// </summary>
        /// <param name="selectedIndex"></param>
        //public void UpdateSelectedSubtopic(int selectedIndex)
        //{
        //    subTopicElement = GetSubTopicNode(selectedIndex);
        //    if (subTopics.Count > selectedIndex) subTopicName = subTopics[selectedIndex];
        //    questionIndex = 0;
        //}

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

        public void UpdateQuestionText(string text)
        {
            if (qaElement == null) return;

            questionElement?.Remove();
            questionElement = new XElement("question", text);

            qaElement.Add(questionElement);
            if (!string.IsNullOrEmpty(subjectName)) UpdateXMLFile(subjectName);
        }

        public void UpdateAnswerText(string text)
        {
            if (qaElement == null) return;

            answerElement?.Remove();
            answerElement = new XElement("answer", text);

            qaElement.Add(answerElement);
            if (!string.IsNullOrEmpty(subjectName)) UpdateXMLFile(subjectName);
        }

        private void SaveSubTopic(XElement subTopic)
        {
            if (string.IsNullOrEmpty(subTopic.Value)) return;
            subTopicDoc = new XDocument();
            subTopicDoc.Add(subTopic);
            foreach (XElement topic in subTopic.Descendants("subTopicName")) subTopicName = topic.Value;
            subTopicDoc.Save(rootPath + subjectName + separator + topicName + separator + subTopicName + subjectFileExtension);
        }

        private Collection<string> GetTopicsFromSubjectXMLFile(int selectedIndex)
        {
            Collection<string> items = [];
            topics.Clear();
            if (!File.Exists(rootPath + subjectName + subjectFileExtension)) return items;
            subjectXml = XDocument.Load(rootPath + subjects[selectedIndex] + subjectFileExtension);

            foreach (XElement node in subjectXml.Descendants("subject")) subjectElement = node;

            if (subjectElement == null) return items;

            foreach (XElement descTopicElement in subjectElement.Descendants("topicName"))
            {
                topics.Add(descTopicElement);
                items.Add(descTopicElement.Value);
            }

            return items;
        }

        private Collection<string> GetSubTopicsFromTopicXElement()
        {
            Collection<string> items = [];
            subTopics.Clear();
            if ((!Directory.Exists(topicDirectoryPath)) || (topicElement == null)) return items;
            foreach (XElement stElement in topicElement.Descendants("subTopicName"))
            {
                subTopicDirectoryPath = topicDirectoryPath + "/" + stElement.Value;
                if (!Directory.Exists(subTopicDirectoryPath)) Directory.CreateDirectory(subTopicDirectoryPath);
                subTopics.Add(stElement);
                items.Add(stElement.Value);
            }
            return items;
        }

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
        }*/
    }
}