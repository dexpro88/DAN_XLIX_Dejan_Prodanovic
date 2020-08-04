using DAN_XLIX_Dejan_Prodanovic.Commands;
using DAN_XLIX_Dejan_Prodanovic.Model;
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
    class AddManagerViewModel:ViewModelBase
    {
        AddManager view;
        IHotelService service;

        List<string> qualificationLevels = new List<string>() {"I","II","III","IV",
        "V","VI","VII" };
        List<string> floors = new List<string>() { "I", "II", "III", "IV", "V" };



        public AddManagerViewModel(AddManager employeeOpen)
        {
            view = employeeOpen;
            service = new HotelService();
            FloorsList = floors;
            LevelList = qualificationLevels;
        }


        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

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

        private List<string> levelList;
        public List<string> LevelList
        {
            get
            {
                return levelList;
            }
            set
            {
                levelList = value;
                OnPropertyChanged("LevelList");
            }
        }

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

    }
}
