using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using BankAccountClient.Globals;
using BankAccountClient.Model.Login;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankAccountClient.ViewModel
{
    class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region PropChange
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        private const int LOGIN_MIN_VALUE = 3;
        private const int LOGIN_MAX_VALUE = 12;


        private bool _loginBtnActiveState = true;
        public bool LoginBtnActiveState
        {
            get { return _loginBtnActiveState; }
            set
            {
                _loginBtnActiveState = value;
                OnPropertyChanged("LoginBtnActiveState");
            }
        }




        public RelayCommand LoginCmd { get; set; }
        public LoginModel LoginModel { get; set; } = new LoginModel();

        public LoginViewModel()
        {
            LoginCmd = new RelayCommand(OnLoginClick);
            GV.Session.On("LoginRes", OnLoginRes);

        }

        private void OnLoginClick()
        {
            if (!CheckLoginValidations())
            {
                MessageBox.Show("Input is not valid!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            GV.Session.Emit("LoginRequest", JsonConvert.SerializeObject(LoginModel));
            LoginBtnActiveState = false;
        }

        private bool CheckLoginValidations()
        {
            return !Validator.IsNullOrEmpty(LoginModel.Username) &&
                   !Validator.IsNullOrEmpty(LoginModel.Password) &&
                   Validator.IsBetween(LoginModel.Username.Length, LOGIN_MIN_VALUE, LOGIN_MAX_VALUE) &&
                   Validator.IsBetween(LoginModel.Password.Length, LOGIN_MIN_VALUE, LOGIN_MAX_VALUE);
        }


        private void OnLoginRes(object obj)
        {
            JObject data = JObject.Parse(obj.ToString());
            bool status = (bool)data["status"];
            if (status)
            {

                GV.IsLoggedIn = true;
                //Move to main dashboard
                TrasitionToDashBoard();
            }
            else
            {

                string err = data["err"].ToString();
                MessageBox.Show(err, "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                GV.IsLoggedIn = false;
                LoginBtnActiveState = true;

            }
        }

        private void TrasitionToDashBoard()
        {
            var mGrid = GV.MGrid;
            int GridColCount = 3;
            #region PhaseOne - Remove Canvas From Grid
            foreach (var child in mGrid.Children)
            {
                if (child is Canvas cns)
                {
                    mGrid.Children.Remove(cns);
                    return;

                }
            }
            #endregion

            #region PhaseTwo - Add ColumnDefenition To Grid

            for (int i = 0; i < GridColCount; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                if (i == 1)
                {
                    cd.Width = new GridLength(80, GridUnitType.Star);
                }
                mGrid.ColumnDefinitions.Add(cd);
            }
            #endregion

            #region PhaseThree - Add DashBoard ViewModels

            for (int i = 0; i < GridColCount; i++)
            {
                Rectangle r = new Rectangle();
                if(i == 1)
                r.Fill = new SolidColorBrush(Colors.Red);
                if (i == 2)
                    r.Fill = new SolidColorBrush(Colors.Blue);
                if (i == 3)
                    r.Fill = new SolidColorBrush(Colors.Black);
            }


            #endregion
        }
    }
}
