using CodeHeapOfBooks.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CodeHeapOfBooks.View
{
    /// <summary>
    /// Interaction logic for AddDocumentView.xaml
    /// </summary>
    public partial class AddDocumentView : Window
    {
        public AddDocumentView()
        {
            InitializeComponent();
            DataContext = new AddDocumentViewModel();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
