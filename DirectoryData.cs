using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyFramework1
{
    /// <summary>
    /// Class to get information from the directory structure
    /// The design is that the root directory contains a directory for each subject
    /// Each subject directory contains a directory for each major topic
    /// Each Topic directory contains a directory for each subTopic
    /// Each subTopic directory contains subject matter to study for that subTopic
    /// </summary>
    internal class DirectoryData(string rootPath, string fileExtension)
    {
        private readonly string rootPath = rootPath;
        private readonly string fileExtension = fileExtension;
        private readonly string pathSeparator = "/";

        public List<string> GetSubjects()
        {
            return GetFoldersInDirectory(rootPath);

        }

        public List<string> GetSubjectTopics(string subjectName)
        {
            return GetFoldersInDirectory(rootPath + subjectName);
        }

        public List<string> GetSubTopics(string subjectName, string topicName)
        {
            List<string> result = [];
            string directoryPath = Path.Combine(rootPath, subjectName, topicName);
            if (!Directory.Exists(directoryPath)) return result;

            foreach (string filePath in Directory.GetFiles(directoryPath))
                if (!string.IsNullOrEmpty(filePath))
                {
                    string? filenameToAdd = Path.GetFileNameWithoutExtension(filePath);
                    if (filenameToAdd != null) result.Add(filenameToAdd);
                }
            return result;
        }

        public string GetSubTopicFilePath(string subjectName, string topicName, string subTopicName)
        {
            string retVal = Path.Combine(rootPath, subjectName, subTopicName + fileExtension);
            return Path.Combine(rootPath, subjectName, topicName, subTopicName + fileExtension);
        }

        private List<string> GetFoldersInDirectory(string directoryPath)
        {
            List<string> result = [];
            if (!Directory.Exists(directoryPath)) return result;

            foreach (string filePath in Directory.GetDirectories(directoryPath))
                if (!string.IsNullOrEmpty(filePath))
                {
                    string? fileNameToAdd = Path.GetFileName(filePath);
                    if (fileNameToAdd != null) result.Add(fileNameToAdd);
                }
            return result;
        }

        public void AddSubject(string subjectName)
        {
            string directoryPath = Path.Combine(rootPath + subjectName);
            if (!Directory.Exists (directoryPath)) Directory.CreateDirectory(directoryPath);
        }

        public void AddTopic(string subjectName, string topicName)
        {
            string directoryPath = Path.Combine(rootPath, subjectName, topicName);
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }


    }
}
