using System;
using System.IO;
using System.Windows.Forms;

namespace FileSorter
{
    class SortFiles
    {      

        public void Sort ()
        {
            var currentDate = DateTime.Now;
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "Choose a path where you want your files to be sorted."
            };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string directoryPath = fbd.SelectedPath;
                var filesInDirectory = Directory.EnumerateFiles(fbd.SelectedPath);
                foreach (string file in filesInDirectory)
                {
                    if (Directory.GetLastAccessTime(file) >= currentDate.AddDays(-7))
                    {
                        Directory.CreateDirectory(directoryPath + @"\Commonly Used");
                        File.Move(file, $"{directoryPath + @"\Commonly Used\"}{ Path.GetFileName(file)}");
                    }
                    else if (Directory.GetLastAccessTime(file) < currentDate.AddDays(-7) && Directory.GetLastAccessTime(file) >= currentDate.AddMonths(-1))
                    {
                        Directory.CreateDirectory(directoryPath + @"\Rarely Used");
                        File.Move(file, $"{directoryPath + @"\Rarely Used\"}{ Path.GetFileName(file)}");
                    }
                    else if (Directory.GetLastAccessTime(file) < currentDate.AddMonths(-1) && Directory.GetLastAccessTime(file) >= currentDate.AddMonths(-2))
                    {
                        Directory.CreateDirectory(directoryPath + @"\Barely Used");
                        File.Move(file, $"{directoryPath + @"\Barely Used\"}{ Path.GetFileName(file)}");
                    }
                    else if (Directory.GetLastAccessTime(file) < currentDate.AddMonths(-2))
                    {
                        Directory.CreateDirectory(directoryPath + @"\Almost Never Used");
                        File.Move(file, $"{directoryPath + @"\Almost Never Used\"}{ Path.GetFileName(file)}");
                    }
                }
                MessageBox.Show("Files successfully sorted :)");
            }
        }
    }
}
