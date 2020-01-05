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
            SortFiles sf = new SortFiles();
            sf.Sort();
        }
    }
}