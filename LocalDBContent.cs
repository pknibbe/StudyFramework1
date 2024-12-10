using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyFramework1
{
    internal class LocalDBContent : DataProvider
    {
        public override void AddQAG(string subjectName, string topicName, string subTopicName, string question, string answer)
        {
            throw new NotImplementedException();
        }

        public override void AddSubject(string subjectName)
        {
            throw new NotImplementedException();
        }

        public override void AddSubTopic(string subjectName, string topicName, string subTopicName)
        {
            throw new NotImplementedException();
        }

        public override void AddTopic(string subjectName, string topicName)
        {
            throw new NotImplementedException();
        }

        public override void ClearAllMarks(string subjectName, string topicName, string subTopicName)
        {
            throw new NotImplementedException();
        }

        public override string GetCurrentAnswer(string subjectName, string topicName, string subTopicName, string questionText)
        {
            throw new NotImplementedException();
        }

        public override string GetCurrentQuestion(string subjectName, string topicName, string subTopicName, bool skipPassed)
        {
            throw new NotImplementedException();
        }

        public override List<string> GetStudySubjects()
        {
            throw new NotImplementedException();
        }

        public override List<string> GetSubjectTopics(string subjectName)
        {
            throw new NotImplementedException();
        }

        public override List<string> GetSubTopics(string subjectName, string topicName)
        {
            throw new NotImplementedException();
        }

        public override void MarkAnswerCorrect(string subjectName, string topicName, string subTopicName, string questionText)
        {
            throw new NotImplementedException();
        }

        public override void MarkAnswerIncorrect(string subjectName, string topicName, string subTopicName, string questionText)
        {
            throw new NotImplementedException();
        }

        public override void RemoveQAG(string subjectName, string topicName, string subTopicName, string questionText)
        {
            throw new NotImplementedException();
        }

        public override void RemoveSubject(string subjectName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveSubTopic(string subjectName, string topicName, string subTopicName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveTopic(string subjectName, string topicName)
        {
            throw new NotImplementedException();
        }

        public override void ResetQuestionIndex()
        {
            throw new NotImplementedException();
        }

        public override void UpdateAnswerText(string subjectName, string topicName, string subTopicName, string questionText, string answerText)
        {
            throw new NotImplementedException();
        }

        public override void UpdateQuestionText(string subjectName, string topicName, string subTopicName, string originalQuestionText, string newQuestionText)
        {
            throw new NotImplementedException();
        }

        public override void IncrementQuestionIndex()
        {
            throw new NotImplementedException();
        }
    }
}
