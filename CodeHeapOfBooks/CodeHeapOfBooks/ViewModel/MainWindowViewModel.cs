﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHeapOfBooks.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = new CollectionViewModel();
        }
        //private CustomerListViewModel custListViewModel = new CustomerListViewModel();
        //private OrderViewModel orderViewModelModel = new OrderViewModel();

        private BindableBase _CurrentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }
        public MyICommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                //case "orders":
                //    CurrentViewModel = new OrderViewModel();
                //    break;
                //case "edit":
                //    CurrentViewModel = new AddEditCustomerViewModel();
                //    break;
                //case "customers":
                //default:
                //    CurrentViewModel = new CustomerListViewModel();
                //    break;
            }
        }

    }
}
