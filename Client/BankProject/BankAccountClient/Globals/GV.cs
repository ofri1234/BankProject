using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Quobject.SocketIoClientDotNet.Client;

namespace BankAccountClient.Globals
{
    public static class GV
    {
        public static TextBlock Invoker = new TextBlock();
        

        public const string IpAddress = "http://127.0.0.1:104";
        public static Socket Session = Session ?? IO.Socket(IpAddress);


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
            get { return MainWindow.Instnace.MainGrid == null? null : MainWindow.Instnace.MainGrid; }
        }

        public static bool IsLoggedIn = false;
    }
}
