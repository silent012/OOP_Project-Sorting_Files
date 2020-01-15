using System;
using System.IO;
using System.Windows.Forms;

namespace FileSorter
{
    class SortFiles
    {
        public void Sort ()
        {
            DateTime currentDate = DateTime.Now;
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "Choose a path where you want your files to be sorted."
            };
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string directoryPath = fbd.SelectedPath;
                var filesInDirectory = Directory.EnumerateFiles(fbd.SelectedPath);
                
                foreach (string file in filesInDirectory)
                {
                    DateTime lastAccess = Directory.GetLastAccessTime(file);
                    if (lastAccess >= currentDate.AddDays(-7))
                    {
                        CreateAndMoveFiles("Commonly Used", directoryPath, file);
                    }
                    else if (lastAccess < currentDate.AddDays(-7) && lastAccess >= currentDate.AddMonths(-1))
                    {
                        CreateAndMoveFiles("Rarely Used", directoryPath, file);
                    }
                    else if (lastAccess < currentDate.AddMonths(-1) && lastAccess >= currentDate.AddMonths(-2))
                    {
                        CreateAndMoveFiles("Barely Used", directoryPath, file);
                    }
                    else if (lastAccess < currentDate.AddMonths(-2))
                    {
                        CreateAndMoveFiles("Almost Never Used", directoryPath, file);
                    }
                }
            }
        }

        public void CreateAndMoveFiles(string folderName, string pathOfDirectory, string fileName)
        {
            Directory.CreateDirectory(pathOfDirectory + "\\" + folderName);
            File.Move(fileName, $"{pathOfDirectory + "\\" + folderName + "\\"}{ Path.GetFileName(fileName)}");
        }        
    }
}