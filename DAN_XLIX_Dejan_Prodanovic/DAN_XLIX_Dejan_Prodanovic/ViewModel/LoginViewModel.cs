using DAN_XLIX_Dejan_Prodanovic.Commands;
using DAN_XLIX_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLIX_Dejan_Prodanovic.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        LoginView view;
        Dictionary<string, string> ownerData = new Dictionary<string, string>();

        public LoginViewModel(LoginView loginView)
        {
            view = loginView;
            ReadOwnerUsernameAndPass();
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {

                return string.Empty;
            }
        }



        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new RelayCommand(Submit);
                    return submitCommand;
                }
                return submitCommand;
            }
        }

        void Submit(object obj)
        {

            string password = (obj as PasswordBox).Password;

            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wrong user name or password");
                return;
            }
            if (UserName.Equals(ownerData["username"]) &&
                password.Equals(ownerData["password"]))
            {
                OwnerView ownerView = new OwnerView();
                view.Close();
                ownerView.Show();
            }
            //else if (UserName.Equals(UserConstants.STOREKEEPER_USER_NAME) &&
            //    password.Equals(UserConstants.STOREKEEPER_PASSWORD))
            //{
            //    StorekeeperMainView storekeeperView = new StorekeeperMainView();
            //    view.Close();
            //    storekeeperView.Show();

            //}
            else
            {
                MessageBox.Show("Wrong username or password");

            }


        }

        private void ReadOwnerUsernameAndPass()
        {
            try
            {
                
                using (StreamReader sr = new StreamReader(@"..\..\OwnerAccess.txt"))
                {
                    string line;
                     
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fileData = line.Split(':');
                       
                        ownerData.Add(fileData[0],fileData[1]);
                      
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
