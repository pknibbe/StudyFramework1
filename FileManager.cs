using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudyFramework1
{
    internal class FileManager
    {
        string defaultFilePath = "Configuration.xml";
        string fPath = "";
        string xmlContent = "";

        public Collection<string> getSubjects()
        {
            readFile(fPath);
            return subjectsFromXML();
        }

        private Collection<string> subjectsFromXML()
        {
            return new Collection<string>();
        }

        private void writeFile(string filePath, string content)
        { 
            fPath = String.IsNullOrEmpty(filePath) ? defaultFilePath : filePath;
            File.WriteAllText(fPath, content);
        }

        private void readFile(string filePath)
        {
            fPath = String.IsNullOrEmpty(filePath) ? defaultFilePath : filePath;
            if (File.Exists(fPath))
            {
                xmlContent = File.ReadAllText(fPath);
            }
        }
    }
}
