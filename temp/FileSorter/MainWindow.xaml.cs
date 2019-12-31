using System;
using System.Windows;
using System.IO;
using System.Windows.Forms;

namespace FileSorter
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void selectBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentDate = DateTime.Now;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose a path where you want your files to be sorted.";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string directoryPath = fbd.SelectedPath;                
                var filesInDirectory = Directory.EnumerateFiles(fbd.SelectedPath);
                foreach (string file in filesInDirectory)
                {
                    if (Directory.GetLastAccessTime(file) >= currentDate.AddDays(-7))
                    {
                        Directory.CreateDirectory(directoryPath + @"\Commonly Used");
                        File.Move(file, $"{directoryPath + @"\Commonly Used\"}{ System.IO.Path.GetFileName(file)}");
                    }
                    else if (Directory.GetLastAccessTime(file) < currentDate.AddDays(-7) && Directory.GetLastAccessTime(file) >= currentDate.AddMonths(-1))
                    {
                        Directory.CreateDirectory(directoryPath + @"\Rarely Used");
                        File.Move(file, $"{directoryPath + @"\Rarely Used\"}{ System.IO.Path.GetFileName(file)}");
                    }
                    else if (Directory.GetLastAccessTime(file) < currentDate.AddMonths(-1) && Directory.GetLastAccessTime(file) >= currentDate.AddMonths(-2))
                    {
                        Directory.CreateDirectory(directoryPath + @"\Barely Used");
                        File.Move(file, $"{directoryPath + @"\Barely Used\"}{ System.IO.Path.GetFileName(file)}");
                    }
                    else if (Directory.GetLastAccessTime(file) < currentDate.AddMonths(-2))
                    {
                        Directory.CreateDirectory(directoryPath + @"\Almost Never Used");                       
                        File.Move(file, $"{directoryPath + @"\Almost Never Used\"}{ System.IO.Path.GetFileName(file)}");
                    }
                }
            }
        }
    }
}