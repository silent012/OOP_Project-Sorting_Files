using System.Windows;

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