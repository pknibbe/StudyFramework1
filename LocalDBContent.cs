using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace StudyFramework1
{
    internal class LocalDBContent : DataProvider
    {
        static async Task Main()
        {
            var builder = new SqlConnectionStringBuilder
            {
                //              DataSource = "<desktop-mjb265a.database.windows.net>",
                //              DataSource = "<desktop-mjb265a.database>",
                DataSource = "<desktop-mjb265a>",
                UserID = "Piet",
                Password = "GoldieIsAGoodGirl",
                InitialCatalog = "flashcards"
            };

            var connectionString = builder.ConnectionString;

            try
            {
                await using var connection = new SqlConnection(connectionString);
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                await connection.OpenAsync();

                var sql = "SELECT name, collation_name FROM sys.databases";
                await using var command = new SqlCommand(sql, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                }
            }
            catch (SqlException e) when (e.Number == 5)
            {
                Console.WriteLine($"SQL Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }


        public LocalDBContent() 
        {
             Main();
        }
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

        public override bool? GetCurrentGrade(string subjectName, string topicName, string subTopicName, string questionText)
        {
            throw new NotImplementedException();
        }

        public override bool QuestionExists(string subjectName, string topicName, string subTopicName, string questionText)
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

        public override List<string> GetSubTopicQuestions(string subjectName, string topicName, string subTopicName, bool skipPassed)
            { throw new NotImplementedException(); }


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

        public override void UpdateAnswerText(string subjectName, string topicName, string subTopicName, string questionText, string answerText)
        {
            throw new NotImplementedException();
        }

        public override void UpdateQuestionText(string subjectName, string topicName, string subTopicName, string originalQuestionText, string newQuestionText)
        {
            throw new NotImplementedException();
        }
    }
}
