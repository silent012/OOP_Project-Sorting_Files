using System.IO;

namespace FileSorter
{
    public sealed class FileManager
    {
        /// <summary>
        /// Singleton class, main class for managing files.
        /// </summary>
        private static readonly FileManager instance = new FileManager();

        public static FileManager GetInstance ()
        {
            return instance;
        }

        private FileManager()
        {

        }
        /// <summary>
        /// Checks if the directory exists, if not - creates it. Then moves the file to the directory keeping file`s original name.
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="pathOfDirectory"></param>
        /// <param name="fileName"></param>
        public void ManageFiles(string folderName, string pathOfDirectory, string fileName)
        {
            Directory.CreateDirectory(pathOfDirectory + "\\" + folderName);
            File.Move(fileName, $"{pathOfDirectory + "\\" + folderName + "\\"}{ Path.GetFileName(fileName)}");
        }
    }
}