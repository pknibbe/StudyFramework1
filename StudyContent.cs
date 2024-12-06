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

        // Getters //
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
        public string GetCurrentAnswer(string subjectName, string topicName, string subTopicName, string questionText)
        {
            return functions.GetCurrentAnswer(dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName), questionText); 
        }

        // Creators //
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
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.AddQAG(xmlPath, question, answer);
        }

        // Deleters //
        public void RemoveSubject(string subjectName) 
        { dataSource.RemoveSubject(subjectName); }

        public void RemoveTopic(string subjectName, string topicName)
        { dataSource.RemoveTopic(subjectName, topicName); }
        public void RemoveSubTopic(string subjectName, string topicName, string subTopicName)
        {
            dataSource.RemoveSubTopic(subjectName, topicName, subTopicName);
            functions.RemoveSubTopic();
        }
        public void RemoveQAG(string subjectName, string topicName, string subTopicName, string questionText)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.RemoveQAG(xmlPath, questionText);
        }

        // Updaters //
        public void MarkAnswerCorrect(string subjectName, string topicName, string subTopicName, string questionText) 
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.MarkAnswerCorrect(xmlPath, questionText);
        }
        public void MarkAnswerIncorrect(string subjectName, string topicName, string subTopicName, string questionText)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.MarkAnswerIncorrect(xmlPath, questionText);
        }
        public void ResetQuestionIndex()
        {
            functions.ResetQuestionIndex();
        }
        public void ClearAllMarks(string subjectName, string topicName, string subTopicName)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.ClearAllMarks(xmlPath);
        }
        public void UpdateQuestionText(string subjectName, string topicName, string subTopicName, string questionText, string answerText)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.UpdateQuestionText(xmlPath, questionText, answerText);
        }
        public void UpdateAnswerText(string subjectName, string topicName, string subTopicName, string questionText, string answerText)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.UpdateAnswerText(xmlPath, questionText, answerText);
        }

    }
}
