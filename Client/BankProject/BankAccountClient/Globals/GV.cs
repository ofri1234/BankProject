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
    public class GV
    {
        public static TextBlock Invoker = new TextBlock();


        public const string IPAddress = "http://127.0.0.1:104";
        public static Socket Session = Session ?? IO.Socket(IPAddress);


        public static Window MainWindow;
        public static Canvas MCanvas;

        public static bool IsLoggedIn = false;
    }
}
