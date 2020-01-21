using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BankAccountClient.Model.UserRelated;
using Quobject.SocketIoClientDotNet.Client;

namespace BankAccountClient.Globals
{
    public static class GV
    {
        public static TextBlock Invoker = new TextBlock();


        //public const string IpAddress = "http://127.0.0.1:115";
        public const string IpAddress = "http://91.205.172.45:100";
        public static Socket Session = Session;


        public static CurrentAccount CA;

        public static void InitServer()
        {
            if (Session == null)
                Session = IO.Socket(IpAddress);
        }

        public static Window MWindow
        {
            get { return MainWindow.Instnace.window == null ? null : MainWindow.Instnace.window; }
        }
        public static Canvas MCanvas
        {
            get { return MainWindow.Instnace.mainCanvas == null ? null : MainWindow.Instnace.mainCanvas; }
        }

        public static Grid MGrid
        {
            get { return MainWindow.Instnace.MainGrid == null ? null : MainWindow.Instnace.MainGrid; }
        }

        public static bool IsLoggedIn = false;
    }
}
