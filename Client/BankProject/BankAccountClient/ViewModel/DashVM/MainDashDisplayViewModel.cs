using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountClient.Globals;
using BankAccountClient.Model.UserRelated;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BankAccountClient.ViewModel.DashVM
{
    class MainDashDisplayViewModel : ViewModelBase
    {
        public CurrentAccount CA { get; set; } = GV.CA;

        public RelayCommand ChangeName { get; set; }

        public MainDashDisplayViewModel()
        {
            ChangeName = new RelayCommand(() =>
            {
                CA.ChangeProperty("FirstName","Mico","GetFullName");
            });
        }
    }
}
