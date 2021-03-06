﻿using System;
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
using CodeHeapOfBooks.ViewModel;

namespace CodeHeapOfBooks.View
{
    /// <summary>
    /// Interaction logic for ConfirmMessageView.xaml
    /// </summary>
    public partial class ConfirmMessageView : Window
    {
        public ConfirmMessageView(string messageShow)
        {
            InitializeComponent();
            DataContext = new ConfirmMessageViewModel(messageShow);
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
