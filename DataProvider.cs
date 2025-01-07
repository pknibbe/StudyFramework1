using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyFramework1
{
    internal abstract class DataProvider
    {
        // The data may contain many Study Subjects, each with a unique name
        // Each study subject may contain many topics, each with a unique name
        // Each subject topic may contain many subtopics, each with a unique name
        // Each subtopic may contain many questions, each with a unique name, an answer, and a grade
        // Each question is associated with an answer and a grade
        // Getters //
        public abstract List<string> GetStudySubjects();
        public abstract List<string> GetSubjectTopics(string subjectName);
        public abstract List<string> GetSubTopics(string subjectName, string topicName);
        public abstract List<string> GetSubTopicQuestions(string subjectName, string topicName, string subTopicName, bool skipPassed);
        public abstract string GetCurrentAnswer(string subjectName, string topicName, string subTopicName, string questionText);
        public abstract bool? GetCurrentGrade(string subjectName, string topicName, string subTopicName, string questionText);
        public abstract bool QuestionExists(string subjectName, string topicName, string subTopicName, string questionText);

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
        public abstract void ClearAllMarks(string subjectName, string topicName, string subTopicName);
        public abstract void UpdateQuestionText(string subjectName, string topicName, string subTopicName, string originalQuestionText, string newQuestionText);
        public abstract void UpdateAnswerText(string subjectName, string topicName, string subTopicName, string questionText, string answerText);
    }
}
