using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BankAccountClient.Globals;
using BankAccountClient.Model.Login;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankAccountClient.ViewModel
{
    class LoginViewModel : ViewModelBase
    {

        public RelayCommand LoginCmd { get; set; }
        public LoginModel LoginModel { get; set; } = new LoginModel();

        public LoginViewModel()
        {
            LoginCmd = new RelayCommand(OnLoginClick);
            GV.Session.On("LoginRes", OnLoginRes);

        }

        private void OnLoginClick()
        {

            GV.Session.Emit("LoginRequest", JsonConvert.SerializeObject(LoginModel));
        }

        private void OnLoginRes(object obj)
        {
            JObject data = JObject.Parse(obj.ToString());
            bool status = (bool)data["status"];
            if (status)
            {

                GV.IsLoggedIn = true;
                //Move to main dashboard
            }
            else
            {

                string err = data["err"].ToString();
                MessageBox.Show(err, "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                GV.IsLoggedIn = false;

            }
            Debug.WriteLine(GV.IsLoggedIn);
        }
    }
}
