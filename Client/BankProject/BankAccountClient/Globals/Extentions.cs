using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BankAccountClient.Globals
{
    public static class Extentions
    {
        public static void UiChange(this object en, Action action)
        {
            try
            {
                GV.Invoker.Dispatcher.BeginInvoke(action);
            }
            catch (Exception e)
            {
                //Show Error to outside or something
            }
        }

        public static void ChangeScreen(this object en, UserControl window, string title = "")
        {
            UiChange(null, () =>
            {

                GV.MCanvas.Children.Clear();
                GV.MainWindow.Width = window.Width;
                GV.MainWindow.Height = window.Height;
                GV.MCanvas.Children.Add(window);
                if (title != "")
                    GV.MainWindow.Title = title;
            });
        }
    }
}
