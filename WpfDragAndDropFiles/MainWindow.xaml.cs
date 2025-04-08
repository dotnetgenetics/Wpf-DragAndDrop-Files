using Microsoft.Win32;
using System.Windows;

namespace WpfDragAndDropFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog;

            openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
                FilePathTextBox.Text = openFileDialog.FileName;
        }

        private void FilePathTextBox_PreviewDrop(object sender, DragEventArgs e)
        {
            string[]? data;

            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                data = e.Data.GetData(DataFormats.FileDrop) as string[];
                e.Handled = true;

                if (data != null && data.Length > 0)
                    FilePathTextBox.Text = data[0].ToString();
            }
        }

        private void FilePathTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
                e.Handled = true;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
    }
}