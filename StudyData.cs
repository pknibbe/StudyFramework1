using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudyFramework1
{
    internal class StudyData
    {
        public enum DataSource
        {
            FileSystem,
            LocalDatabase,
            RemoteDatabase
        }

        readonly DataProvider? dataProvider;

        public StudyData(DataSource dataSource)
        {
            switch(dataSource)
            {
                case DataSource.FileSystem:
                    dataProvider = new FileStorageContent();
                    break;
                case DataSource.LocalDatabase: 
                    dataProvider = new LocalDBContent(); 
                    break;
                    case DataSource.RemoteDatabase:
                    dataProvider = new RemoteDBContent();
                    break;
            }
        }


        // Getters //
        public  List<string> GetStudySubjects() 
        { 
            if (dataProvider == null) { return []; }
            return dataProvider.GetStudySubjects(); 
        }
        public  List<string> GetSubjectTopics(string subjectName)
        {
            if (dataProvider == null) { return []; }
            return dataProvider.GetSubjectTopics(subjectName); 
        }
        public  List<string> GetSubTopics(string subjectName, string topicName)
        {
            if (dataProvider == null) { return []; }
            return dataProvider.GetSubTopics(subjectName, topicName);  
        }

        public List<string> GetSubTopicQuestions(string subjectName, string topicName, string subTopicName)
        {
            if (dataProvider == null) { return []; }
            return dataProvider.GetSubTopicQuestions(subjectName, topicName, subTopicName);
        }

        public  string GetCurrentQuestion(string subjectName, string topicName, string subTopicName, bool skipPassed)
        {
            if (dataProvider == null) { return string.Empty; }
            return dataProvider.GetCurrentQuestion(subjectName, topicName, subTopicName, skipPassed);
        }
        public  string GetCurrentAnswer(string subjectName, string topicName, string subTopicName, string questionText)
        {
            if (dataProvider == null) { return string.Empty; }
            return dataProvider.GetCurrentAnswer(subjectName, topicName, subTopicName, questionText);
        }

        // Creators //
        public  void AddSubject(string subjectName)
        {
            if (dataProvider == null) { return ; }
            dataProvider.AddSubject(subjectName); 
        }

        public  void AddTopic(string subjectName, string topicName)
        {
            if (dataProvider == null) { return; }
            dataProvider.AddTopic(subjectName, topicName);
        }

        /// <summary>
        /// Add a SubTopic to the data store by the appropriate means
        /// </summary>
        /// <param name="subjectName"></param>
        /// <param name="topicName"></param>
        /// <param name="subTopicName"></param>
        public  void AddSubTopic(string subjectName, string topicName, string subTopicName)
        {
            if (dataProvider == null) { return; }
            dataProvider.AddSubTopic(subjectName, topicName, subTopicName);
        }

        public  void AddQAG(string subjectName, string topicName, string subTopicName, string question, string answer)
        {
            if (dataProvider == null) { return; }
            dataProvider.AddQAG(subjectName, topicName, subTopicName, question, answer);
        }

        // Deleters //
        public  void RemoveSubject(string subjectName)
        {
            if (dataProvider == null) { return; }
            dataProvider.RemoveSubject(subjectName);
        }

        public  void RemoveTopic(string subjectName, string topicName)
        {
            if (dataProvider == null) { return; }
            dataProvider.RemoveTopic(subjectName, topicName);
        }
        public  void RemoveSubTopic(string subjectName, string topicName, string subTopicName)
        {
            if (dataProvider == null) { return; }
            dataProvider.RemoveSubTopic(subjectName, topicName, subTopicName);
        }
        public  void RemoveQAG(string subjectName, string topicName, string subTopicName, string questionText)
        {
            if (dataProvider == null) { return; }
            dataProvider.RemoveQAG(subjectName, topicName, subTopicName, questionText);
        }

        // Updaters //
        public  void MarkAnswerCorrect(string subjectName, string topicName, string subTopicName, string questionText)
        {
            if (dataProvider == null) { return; }
            dataProvider.MarkAnswerCorrect(subjectName, topicName, subTopicName, questionText);
        }
        public  void MarkAnswerIncorrect(string subjectName, string topicName, string subTopicName, string questionText)
        {
            if (dataProvider == null) { return; }
            dataProvider.MarkAnswerIncorrect(subjectName, topicName, subTopicName, questionText);
        }
        public  void ResetQuestionIndex()
        {
            if (dataProvider == null) { return; }
            dataProvider.ResetQuestionIndex();
        }
        public  void ClearAllMarks(string subjectName, string topicName, string subTopicName)
        {
            if (dataProvider == null) { return; }
            dataProvider.ClearAllMarks(subjectName, topicName, subTopicName);
        }
        public  void UpdateQuestionText(string subjectName, string topicName, string subTopicName, string originalQuestionText, string newQuestionText)
        {
            if (dataProvider == null) { return; }
            dataProvider.UpdateQuestionText(subjectName, topicName, subTopicName, originalQuestionText, newQuestionText);
        }
        public  void UpdateAnswerText(string subjectName, string topicName, string subTopicName, string questionText, string answerText)
        {
            if (dataProvider == null) { return; }
            dataProvider.UpdateAnswerText(subjectName, topicName, subTopicName, questionText, answerText);
        }

        public void IncrementQuestionIndex()
        {
            if (dataProvider == null) { return; }
            dataProvider.IncrementQuestionIndex();
        }

    }
}
