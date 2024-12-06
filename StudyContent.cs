using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyFramework1
{
    /// <summary>
    /// Class to provide study content to the user interface from the current data source
    /// </summary>
    internal class StudyContent
    {
        readonly DirectoryData dataSource = new("D:\\repos/C#/StudyFramework1/XML/", ".xml");
        readonly XMLFunctions functions = new();

        public List<string> GetStudySubjects() { return dataSource.GetSubjects(); }
        public List<string> GetSubjectTopics(string subjectName)
        {
            return dataSource.GetSubjectTopics(subjectName);
        }
        public List<string> GetSubTopics(string subjectName, string topicName)
        {
            return dataSource.GetSubTopics(subjectName, topicName);
        }

        public string GetCurrentQuestion(string subjectName, string topicName, string subTopicName, bool skipPassed)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            return functions.GetCurrentQuestion(xmlPath, skipPassed);
        }

        public void AddSubject(string subjectName)
        { dataSource.AddSubject(subjectName); }

        public void AddTopic(string subjectName, string topicName)
        { dataSource.AddTopic(subjectName, topicName); }

        /// <summary>
        /// Add a SubTopic to the data store by the appropriate means
        /// </summary>
        /// <param name="subjectName"></param>
        /// <param name="topicName"></param>
        /// <param name="subTopicName"></param>
        public void AddSubTopic(string subjectName, string topicName, string subTopicName)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.AddSubTopic(subTopicName, xmlPath);
        }

        public void AddQAG(string question, string answer, string subjectName, string topicName, string subTopicName) 
        { 
        }

        public string GetQuestion(bool skipPassed) { return "Placeholder question"; }

        public void RemoveSubject(string subjectName) { }

        public void RemoveTopic(string subjectName, string topicName) { }
        public void RemoveSubTopic(string subjectName, string topicName, string subTopicName) { }
        public void RemoveQuestion(string subjectName, string topicName, string subTopicName, string questionText) { }

        public string GetAnswer(string questionText) { return "Placeholder answer"; }
        public void MarkAnswerCorrect(string questionText) { }
        public void MarkAnswerIncorrect(string questionText) { }
        public void ResetQuestionIndex() { }
        public void ClearAllMarks() { }
        public void UpdateQuestionText(string questionText) { }
        public void UpdateAnswerText(string answerText) { }

    }
}
