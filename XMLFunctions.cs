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
        XDocument? subTopicDoc;
        string? currentSubTopicXMLPath;
        static readonly string questionAnswerGroupElementTag = "qaTrio";
        static readonly string gradeElementTag = "grade";
        static readonly string questionElementTag = "question";
        static readonly string answerElementTag = "answer";
        static readonly string subtopicElementTag = "subtopic";
        static readonly string subtopicNameElementTag = "subTopicName";
        static readonly string passedValue = "1";
        static readonly string failedValue = "0";
        static readonly string uninitializedValue = "-1";

        // Example XML Document contents
        //     XML Document Header
        //     <subtopic>
        //         <subtopicName>Name of subtopic</subtopicName>
        //         <qaPair>
        //            <question>Text of question</question>
        //            <answer>Text of answer</answer>
        //            <grade>"-1" or "0" or "1" represents unset, false, or true</grade>
        //         </qaPair>
        //         Additional qaPair elements
        //     </subtopic>


        // Getters //
        public List<string> GetSubTopicQuestions(string xmlPath, bool skipPassed)
        {
            List<string> retVal = [];
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc != null)
            {
                foreach (XElement qag in subTopicDoc.Descendants(questionAnswerGroupElementTag))
                {
                    if ((!skipPassed) || (!QuestionIsPassed(qag))) // omit elements if passed and flag set to omit passed questions
                    {
                        foreach (XElement question in qag.Descendants(questionElementTag))
                        {
                            retVal.Add(question.Value);
                        }
                    }
                }
            }
            return retVal;
        }

        public string GetCurrentAnswer(string xmlPath, string questionText)
        {
            string retVal = "Unable to find the current answer.";
            string? currentAnswer = String.Empty;
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return retVal;
            IEnumerable<XElement>? questionAnswerGroups = subTopicDoc.Descendants(questionAnswerGroupElementTag);

            if ((questionAnswerGroups == null) || (!questionAnswerGroups.Any())) return retVal;
            
            foreach (XElement qap in questionAnswerGroups)
                foreach (XElement question in qap.Descendants(questionElementTag))
                    if (question.Value == questionText)
                        foreach (XElement answer in qap.Descendants(answerElementTag)) currentAnswer = answer.Value;

            if (string.IsNullOrEmpty(currentAnswer)) return retVal;
            return currentAnswer;
        }

        public bool? GetCurrentGrade(string xmlPath, string questionText)
        {
            bool? retVal = null;
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return retVal;
            IEnumerable<XElement>? questionAnswerGroups = subTopicDoc.Descendants(questionAnswerGroupElementTag);

            if ((questionAnswerGroups == null) || (!questionAnswerGroups.Any())) return retVal;

            foreach (XElement qap in questionAnswerGroups)
                foreach (XElement question in qap.Descendants(questionElementTag))
                    if (question.Value == questionText)
                        return GetQuestionGrade(qap);

            return retVal;
        }


        // Adders //
        public void AddSubTopic(string subTopicName, string subTopicDirectoryPath)
        {
            subTopicDoc = new XDocument(new XElement(subtopicElementTag, new XElement(subtopicNameElementTag, subTopicName)));
            currentSubTopicXMLPath = subTopicDirectoryPath;
            subTopicDoc.Save(subTopicDirectoryPath);
        }

        public void AddQAG(string xmlPath, string question, string answer)
        {
            SetSubTopicByPath(xmlPath);

            if (subTopicDoc == null) return;

            foreach (XElement stElement in subTopicDoc.Descendants(subtopicElementTag))
                stElement.Add(new XElement(questionAnswerGroupElementTag, new XElement(questionElementTag, question), new XElement(answerElementTag, answer), new XElement(gradeElementTag, uninitializedValue)));

            if (!string.IsNullOrEmpty(xmlPath)) subTopicDoc.Save(xmlPath);

            return;
        }

        // Deleters //
        public void RemoveSubTopic()
        {
            currentSubTopicXMLPath = string.Empty;
            subTopicDoc = null;
        }
        public void RemoveQAG(string xmlPath, string questionText)
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;
            
            foreach (XElement qag in subTopicDoc.Descendants(questionAnswerGroupElementTag))
                foreach (XElement question in subTopicDoc.Descendants(questionElementTag))
                    if (question.Value == questionText) qag.Remove();

            if (!string.IsNullOrEmpty(xmlPath)) subTopicDoc.Save(xmlPath);
        }

        // Updaters //
        public void MarkAnswerCorrect(string xmlPath, string questionText) 
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;

            foreach (XElement qag in subTopicDoc.Descendants(questionAnswerGroupElementTag))
                foreach (XElement question in qag.Descendants(questionElementTag))
                    if (question.Value == questionText)
                        foreach (XElement grade in qag.Descendants(gradeElementTag)) grade.Value = passedValue;
            if (!string.IsNullOrEmpty(xmlPath)) subTopicDoc.Save(xmlPath);
        }

        public void MarkAnswerIncorrect(string xmlPath, string questionText) 
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;

            foreach (XElement qag in subTopicDoc.Descendants(questionAnswerGroupElementTag))
                foreach (XElement question in qag.Descendants(questionElementTag))
                    if (question.Value == questionText)
                        foreach (XElement grade in qag.Descendants(gradeElementTag)) grade.Value = failedValue;
            if (!string.IsNullOrEmpty(xmlPath)) subTopicDoc.Save(xmlPath);
        }
        public void ClearAllMarks(string xmlPath) 
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;
            foreach (XElement grade in subTopicDoc.Descendants(gradeElementTag)) grade.Value = uninitializedValue;
            if (!string.IsNullOrEmpty(xmlPath)) subTopicDoc.Save(xmlPath);
        }
        public void UpdateQuestionText(string xmlPath, string originalQuestionText, string newQuestionText) 
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;

            foreach (XElement qag in subTopicDoc.Descendants(questionAnswerGroupElementTag))
                foreach (XElement question in qag.Descendants(questionElementTag))
                    if (question.Value == originalQuestionText) question.Value = newQuestionText;
            if (!string.IsNullOrEmpty(xmlPath)) subTopicDoc.Save(xmlPath);
        }
        public void UpdateAnswerText(string xmlPath, string questionText, string answerText) 
        {
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return;

            foreach (XElement qag in subTopicDoc.Descendants(questionAnswerGroupElementTag))
                foreach (XElement question in qag.Descendants(questionElementTag))
                    if (question.Value == questionText)
                        foreach (XElement answer in qag.Descendants(answerElementTag)) answer.Value = answerText;
            if (!string.IsNullOrEmpty(xmlPath)) subTopicDoc.Save(xmlPath);
        }

        public bool QuestionExists(string xmlPath, string questionText)
        {
            bool retVal = true;
            SetSubTopicByPath(xmlPath);
            if (subTopicDoc == null) return retVal;

            foreach (XElement qag in subTopicDoc.Descendants(questionAnswerGroupElementTag))
                foreach (XElement question in qag.Descendants(questionElementTag))
                    if (question.Value == questionText) return retVal;

            return false;
        }

        private static bool QuestionIsPassed(XElement qap)
        {
            foreach (XElement grade in qap.Descendants(gradeElementTag)) return (grade.Value == passedValue);
            return false;
        }

        private static bool? GetQuestionGrade(XElement qap)
        {
            foreach (XElement grade in qap.Descendants(gradeElementTag))
            {
                if (grade.Value == passedValue) return true;
                if (grade.Value == failedValue) return false;
            }
            return null;
        }

        private void SetSubTopicByPath(string xmlPath)
        {
            if ((string.IsNullOrEmpty(currentSubTopicXMLPath)) || !(currentSubTopicXMLPath == xmlPath))
            {
                subTopicDoc = XDocument.Load(xmlPath);
                currentSubTopicXMLPath = xmlPath;
            }
        }

    }
}