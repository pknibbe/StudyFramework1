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
    internal class FileStorageContent: DataProvider
    {
        readonly DirectoryData dataSource = new("D:\\repos/C#/StudyFramework1/XML/", ".xml");
        readonly XMLFunctions functions = new();

        // Getters //
        public override List<string> GetStudySubjects() { return dataSource.GetSubjects(); }
        public override List<string> GetSubjectTopics(string subjectName)
        {
            return dataSource.GetSubjectTopics(subjectName);
        }
        public override List<string> GetSubTopics(string subjectName, string topicName)
        {
            return dataSource.GetSubTopics(subjectName, topicName);
        }

        public override string GetCurrentQuestion(string subjectName, string topicName, string subTopicName, bool skipPassed)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            return functions.GetCurrentQuestion(xmlPath, skipPassed);
        }
        public override string GetCurrentAnswer(string subjectName, string topicName, string subTopicName, string questionText)
        {
            return functions.GetCurrentAnswer(dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName), questionText); 
        }

        // Creators //
        public override void AddSubject(string subjectName)
        { dataSource.AddSubject(subjectName); }

        public override void AddTopic(string subjectName, string topicName)
        { dataSource.AddTopic(subjectName, topicName); }

        /// <summary>
        /// Add a SubTopic to the data store by the appropriate means
        /// </summary>
        /// <param name="subjectName"></param>
        /// <param name="topicName"></param>
        /// <param name="subTopicName"></param>
        public override void AddSubTopic(string subjectName, string topicName, string subTopicName)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.AddSubTopic(subTopicName, xmlPath);
        }

        public override void AddQAG(string subjectName, string topicName, string subTopicName, string question, string answer) 
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.AddQAG(xmlPath, question, answer);
        }

        // Deleters //
        public override void RemoveSubject(string subjectName) 
        { dataSource.RemoveSubject(subjectName); }

        public override void RemoveTopic(string subjectName, string topicName)
        { dataSource.RemoveTopic(subjectName, topicName); }
        public override void RemoveSubTopic(string subjectName, string topicName, string subTopicName)
        {
            dataSource.RemoveSubTopic(subjectName, topicName, subTopicName);
            functions.RemoveSubTopic();
        }
        public override void RemoveQAG(string subjectName, string topicName, string subTopicName, string questionText)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.RemoveQAG(xmlPath, questionText);
        }

        // Updaters //
        public override void MarkAnswerCorrect(string subjectName, string topicName, string subTopicName, string questionText) 
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.MarkAnswerCorrect(xmlPath, questionText);
        }
        public override void MarkAnswerIncorrect(string subjectName, string topicName, string subTopicName, string questionText)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.MarkAnswerIncorrect(xmlPath, questionText);
        }
        public override void ResetQuestionIndex()
        {
            functions.ResetQuestionIndex();
        }
        public override void ClearAllMarks(string subjectName, string topicName, string subTopicName)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.ClearAllMarks(xmlPath);
        }
        public override void UpdateQuestionText(string subjectName, string topicName, string subTopicName, string originalQuestionText, string newQuestionText)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.UpdateQuestionText(xmlPath, originalQuestionText, newQuestionText);
        }
        public override void UpdateAnswerText(string subjectName, string topicName, string subTopicName, string questionText, string answerText)
        {
            string xmlPath = dataSource.GetSubTopicFilePath(subjectName, topicName, subTopicName);
            functions.UpdateAnswerText(xmlPath, questionText, answerText);
        }

        public override void IncrementQuestionIndex()
        {
            functions.IncrementQuestionIndex();
        }

    }
}
