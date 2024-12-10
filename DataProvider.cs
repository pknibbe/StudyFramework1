using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyFramework1
{
    internal abstract class DataProvider
    {

        // Getters //
        public abstract List<string> GetStudySubjects();
        public abstract List<string> GetSubjectTopics(string subjectName);
        public abstract List<string> GetSubTopics(string subjectName, string topicName);
        public abstract string GetCurrentQuestion(string subjectName, string topicName, string subTopicName, bool skipPassed);
        public abstract string GetCurrentAnswer(string subjectName, string topicName, string subTopicName, string questionText);

        // Creators //
        public abstract void AddSubject(string subjectName);
        public abstract void AddTopic(string subjectName, string topicName);
        public abstract void AddSubTopic(string subjectName, string topicName, string subTopicName);
        public abstract void AddQAG(string subjectName, string topicName, string subTopicName, string question, string answer);

        // Deleters //
        public abstract void RemoveSubject(string subjectName);

        public abstract void RemoveTopic(string subjectName, string topicName);
        public abstract void RemoveSubTopic(string subjectName, string topicName, string subTopicName);
        public abstract void RemoveQAG(string subjectName, string topicName, string subTopicName, string questionText);

        // Updaters //
        public abstract void MarkAnswerCorrect(string subjectName, string topicName, string subTopicName, string questionText);
        public abstract void MarkAnswerIncorrect(string subjectName, string topicName, string subTopicName, string questionText);
        public abstract void ResetQuestionIndex();
        public abstract void ClearAllMarks(string subjectName, string topicName, string subTopicName);
        public abstract void UpdateQuestionText(string subjectName, string topicName, string subTopicName, string questionText, string answerText);
        public abstract void UpdateAnswerText(string subjectName, string topicName, string subTopicName, string questionText, string answerText);
    }
}
