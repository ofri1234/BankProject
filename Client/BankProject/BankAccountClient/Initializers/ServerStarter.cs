using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using BankAccountClient.Globals;
using BankAccountClient.UserControls;

namespace BankAccountClient.Initializers
{
    public class ServerStarter
    {
        private bool connectionSucesss = false;
        public ServerStarter()
        {

            var session = GV.Session;
            session.On("disconnect", () => { OnClose(); });
            GV.MWindow.Hide();
            GV.MWindow.Width = 0;
            GV.MWindow.Height = 0;
            if (session != null)
            {
                session.On("connectSucess", (d) => { connectionSucesss = true; });
                Thread checker = new Thread(() =>
                {
                    //Got 3 Secons to check if connection was a sucess or not
                    Thread.Sleep(3000);
                    if (!connectionSucesss)
                    {
                        //Server is not running
                        OnClose();
                    }
                    else
                    {
                        //Server Does Run
                        // - Init Login View
                        this.UiChange(() =>
                        {
                            this.ChangeScreen(new LoginControl(), "Login Screen");
                        });
                        this.UiChange(() => { GV.MWindow.Show(); });
                    }
                });
                checker.Start();
            }
        }

        private static void OnClose()
        {
            MessageBox.Show("Server is not open! try again later", "Server Error", MessageBoxButton.OK,
                MessageBoxImage.Error);
            Environment.Exit(0);
        }
    }
}
