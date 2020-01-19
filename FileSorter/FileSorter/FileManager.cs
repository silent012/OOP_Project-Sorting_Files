using System.IO;

namespace FileSorter
{
    class FileManager
    {
        private static readonly FileManager instance = new FileManager();

        public static FileManager GetInstance ()
        {
            return instance;
        }

        private FileManager()
        {

        }
        public void ManageFiles(string folderName, string pathOfDirectory, string fileName)
        {
            Directory.CreateDirectory(pathOfDirectory + "\\" + folderName);
            File.Move(fileName, $"{pathOfDirectory + "\\" + folderName + "\\"}{ Path.GetFileName(fileName)}");
        }
    }
}