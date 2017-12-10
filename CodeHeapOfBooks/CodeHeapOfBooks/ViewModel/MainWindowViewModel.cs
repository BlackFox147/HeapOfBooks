using CodeHeapOfBooks.View;
using System;
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


            _ListViewModel = new CollectionViewModel();
            //CurrentViewModel = new ListDocumentsViewModel();

        }
        //private CustomerListViewModel custListViewModel = new CustomerListViewModel();
        //private OrderViewModel orderViewModelModel = new OrderViewModel();

        private BindableBase _CurrentViewModel;

        //public BindableBase CurrentViewModel
        //{
        //    get
        //    {
        //        //((CollectionViewModel)_ListViewModel).ListDocumentsViewModel;
        //        CollectionViewModel temp = _ListViewModel as CollectionViewModel;
        //        return temp.DocumentsViewModelQ;
        //    }
        //    set { SetProperty(ref _CurrentViewModel, value); }
        //}

        private BindableBase _ListViewModel;
       
        public BindableBase ListViewModel
        {
            get { return _ListViewModel; }
            set { SetProperty(ref _ListViewModel, value); }
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
