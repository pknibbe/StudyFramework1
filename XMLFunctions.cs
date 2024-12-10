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

        // Getters //


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
            SetSubTopicByPath(xmlPath);

            int currentIndex = 0;
            if ((questionAnswerGroups == null) || (!questionAnswerGroups.Any())) return retVal;
            foreach (XElement qap in questionAnswerGroups)
            {
                if (skipPassed && QuestionIsPassed(qap)) continue;
                if (questionIndex == currentIndex++)
                {
                    foreach (XElement question in qap.Descendants("question")) currentQuestion = question.Value;
                    foreach (XElement answer in qap.Descendants("answer")) currentAnswer = answer.Value;

                    if (!string.IsNullOrEmpty(currentQuestion)) return currentQuestion;
                    return retVal;
                }
            }
            return retVal;
        }

        public void IncrementQuestionIndex() { questionIndex++; }

        public string GetCurrentAnswer(string xmlPath, string questionText)
        {
            string retVal = "Unable to find the current answer.";
            SetSubTopicByPath(xmlPath);

            if (currentQuestion != questionText)
            {
                if ((questionAnswerGroups == null) || (!questionAnswerGroups.Any())) return retVal;
                foreach (XElement qap in questionAnswerGroups)
                {
                    foreach (XElement question in qap.Descendants("question"))
                        if (question.Value == questionText)
                        { currentQuestion = question.Value;
                            foreach (XElement answer in qap.Descendants("answer")) currentAnswer = answer.Value;
                        }
                }
            }

            if (string.IsNullOrEmpty(currentAnswer)) return retVal;
            return currentAnswer;
        }

        // Adders //
        public void AddSubTopic(string subTopicName, string subTopicDirectoryPath)
        {
            subTopicDoc = new XDocument(new XElement("subTopicName", subTopicName));
            currentSubTopicXMLPath = subTopicDirectoryPath;
            subTopicDoc.Save(currentSubTopicXMLPath);
            questionIndex = 0;
        }

        public void AddQAG(string xmlPath, string question, string answer)
        {
            SetSubTopicByPath(xmlPath);

            if (subTopicDoc == null) return;

            foreach (XElement stElement in subTopicDoc.Descendants("subtopic"))
                stElement.Add(new XElement("qaPair", new XElement("question", question), new XElement("answer", answer), new XElement("grade", "-1")));

            questionAnswerGroups = subTopicDoc.Descendants("qaPair");
            if (!string.IsNullOrEmpty(currentSubTopicXMLPath)) subTopicDoc.Save(currentSubTopicXMLPath);

            return;
        }

        // Deleters //
        public void RemoveSubTopic()
        {
            currentSubTopicXMLPath = string.Empty;
            questionIndex = 0;
            subTopicDoc = null;
            questionAnswerGroups = null;
            currentQuestion = string.Empty;
            currentAnswer = string.Empty;
        }
        public void RemoveQAG(string xmlPath, string questionText)
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;
            
            foreach (XElement qag in subTopicDoc.Descendants("qaPair"))
                foreach (XElement question in subTopicDoc.Descendants("question"))
                    if (question.Value == questionText) qag.Remove();

            if (!string.IsNullOrEmpty(currentSubTopicXMLPath)) subTopicDoc.Save(currentSubTopicXMLPath);
        }

        // Updaters //
        public void MarkAnswerCorrect(string xmlPath, string questionText) 
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;

            foreach (XElement qag in subTopicDoc.Descendants("qaPair"))
                foreach (XElement question in qag.Descendants("question"))
                    if (question.Value == questionText)
                        foreach (XElement grade in qag.Descendants("grade")) grade.Value = "1";
            if (!string.IsNullOrEmpty(currentSubTopicXMLPath)) subTopicDoc.Save(currentSubTopicXMLPath);
        }

        public void MarkAnswerIncorrect(string xmlPath, string questionText) 
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;

            foreach (XElement qag in subTopicDoc.Descendants("qaPair"))
                foreach (XElement question in qag.Descendants("question"))
                    if (question.Value == questionText)
                        foreach (XElement grade in qag.Descendants("grade")) grade.Value = "0";
            if (!string.IsNullOrEmpty(currentSubTopicXMLPath)) subTopicDoc.Save(currentSubTopicXMLPath);
        }

        public void ResetQuestionIndex() 
        {
            questionIndex = 0;
        }
        public void ClearAllMarks(string xmlPath) 
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;
            foreach (XElement grade in subTopicDoc.Descendants("grade")) grade.Value = "-1";
            if (!string.IsNullOrEmpty(currentSubTopicXMLPath)) subTopicDoc.Save(currentSubTopicXMLPath);
        }
        public void UpdateQuestionText(string xmlPath, string originalQuestionText, string newQuestionText) 
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;

            foreach (XElement qag in subTopicDoc.Descendants("qaPair"))
                foreach (XElement question in qag.Descendants("question"))
                    if (question.Value == originalQuestionText) question.Value = newQuestionText;
            if (!string.IsNullOrEmpty(currentSubTopicXMLPath)) subTopicDoc.Save(currentSubTopicXMLPath);
        }
        public void UpdateAnswerText(string xmlPath, string questionText, string answerText) 
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;

            foreach (XElement qag in subTopicDoc.Descendants("qaPair"))
                foreach (XElement question in qag.Descendants("question"))
                    if (question.Value == questionText)
                        foreach (XElement answer in qag.Descendants("answer")) answer.Value = answerText;
            if (!string.IsNullOrEmpty(currentSubTopicXMLPath)) subTopicDoc.Save(currentSubTopicXMLPath);
        }

        private static bool QuestionIsPassed(XElement qap)
        {
            foreach (XElement grade in qap.Descendants("grade")) return (grade.Value == "1");
            return false;
        }

        private void SetSubTopicByPath(string xmlPath)
        {
            if ((string.IsNullOrEmpty(currentSubTopicXMLPath)) || !(currentSubTopicXMLPath == xmlPath))
            {
                subTopicDoc = XDocument.Load(xmlPath);
                questionAnswerGroups = subTopicDoc.Descendants("qaPair");
                currentSubTopicXMLPath = xmlPath;
            }
        }

    }
}