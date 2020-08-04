using DAN_XLIX_Dejan_Prodanovic.Commands;
using DAN_XLIX_Dejan_Prodanovic.Service;
using DAN_XLIX_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIX_Dejan_Prodanovic.ViewModel
{
    class AddEmployeeViewModel:ViewModelBase
    {
        AddEmployee view;
        IHotelService service;

        List<string> qualificationLevels = new List<string>() {"I","II","III","IV",
        "V","VI","VII" };
        List<string> floors = new List<string>() { "I", "II", "III", "IV", "V" };
        

       
        public AddEmployeeViewModel(AddEmployee employeeOpen)
        {
            view = employeeOpen;
            service = new HotelService();
            FloorsList = floors;

        }


        //#region Properties
        //private tblProduct selectetProduct;
        //public tblProduct SelectetProduct
        //{
        //    get
        //    {
        //        return selectetProduct;
        //    }
        //    set
        //    {
        //        selectetProduct = value;
        //        OnPropertyChanged("SelectetProduct");
        //    }
        //}
        private List<string> floorsList;
        public List<string> FloorsList
        {
            get
            {
                return floorsList;
            }
            set
            {
                floorsList = value;
                OnPropertyChanged("FloorsList");
            }
        }
        //#endregion

        //#region Commands
        //private ICommand logout;
        //public ICommand Logout
        //{
        //    get
        //    {
        //        if (logout == null)
        //        {
        //            logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
        //        }
        //        return logout;
        //    }
        //}

        private void LogoutExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
        }



        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }



        //private ICommand addProduct;
        //public ICommand AddProduct
        //{
        //    get
        //    {
        //        if (addProduct == null)
        //        {
        //            addProduct = new RelayCommand(param => AddProductExecute(),
        //                param => CanAddProductExecute());
        //        }
        //        return addProduct;
        //    }
        //}

        //private void AddProductExecute()
        //{
        //    try
        //    {
        //        AddProduct addProduct = new AddProduct();
        //        addProduct.ShowDialog();

        //        if ((addProduct.DataContext as AddProductViewModel).IsUpdateProduct == true)
        //        {
        //            string productName = (addProduct.DataContext as AddProductViewModel).Product.ProductName;
        //            int amount = (int)(addProduct.DataContext as AddProductViewModel).Product.Amount;
        //            string textToWrite = String.Format("You added {0} of product {1}."
        //                  , amount, productName);
        //            eventObject.OnActionPerformed(textToWrite);
        //            ProductList = dataService.GetProducts();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        //private bool CanAddProductExecute()
        //{

        //    return true;
        //}



        //#endregion


    }
}
