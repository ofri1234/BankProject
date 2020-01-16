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


        public static Window MainWindow;
        public static Canvas MCanvas;

        public static Grid MGrid { get; set; }

        public static bool IsLoggedIn = false;
    }
}
