using System;
using System.Windows;
using System.IO;

namespace FileSorter
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            var currentDate = DateTime.Now;

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);            

            var filesOnDesktop = Directory.EnumerateFiles(desktopPath);

            // Moving desktop files to specific folders
            #region
            foreach (string file in filesOnDesktop)
            {
                if (Directory.GetLastAccessTime(file) >= currentDate.AddDays(-7))
                {
                    Directory.CreateDirectory(@"C:\Users\Wojtek\Desktop\Commonly Used");
                    label1.Content += System.IO.Path.GetFileName(file) + "\n";
                    File.Move(file, $"{@"C:\Users\Wojtek\Desktop\Commonly Used\"}{ System.IO.Path.GetFileName(file)}");
                }
                else if (Directory.GetLastAccessTime(file) < currentDate.AddDays(-7) && Directory.GetLastAccessTime(file) >= currentDate.AddMonths(-1))
                {
                    Directory.CreateDirectory(@"C:\Users\Wojtek\Desktop\Rarely Used");
                    label1.Content += System.IO.Path.GetFileName(file) + "\n";
                    File.Move(file, $"{@"C:\Users\Wojtek\Desktop\Rarely Used\"}{ System.IO.Path.GetFileName(file)}");
                }
                else if (Directory.GetLastAccessTime(file) < currentDate.AddMonths(-1) && Directory.GetLastAccessTime(file) >= currentDate.AddMonths(-2))
                {
                    Directory.CreateDirectory(@"C:\Users\Wojtek\Desktop\Barely Used");
                    label1.Content += System.IO.Path.GetFileName(file) + "\n";
                    File.Move(file, $"{@"C:\Users\Wojtek\Desktop\Barely Used\"}{ System.IO.Path.GetFileName(file)}");
                }
                else if (Directory.GetLastAccessTime(file) < currentDate.AddMonths(-2))
                {
                    Directory.CreateDirectory(@"C:\Users\Wojtek\Desktop\Almost Never Used");
                    label1.Content += System.IO.Path.GetFileName(file) + "\n";
                    File.Move(file, $"{@"C:\Users\Wojtek\Desktop\Almost Never Used\"}{ System.IO.Path.GetFileName(file)}");
                } else
                {
                    label1.Content = "Weird error";
                }
            }
            #endregion
        }
    }
}