using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BankAccountClient.UserControls.DashBoardUC;

namespace BankAccountClient.Globals
{
    class GuiHelper
    {
        public static MainDashDisplay StartNewMainDashDisplay()
        {
            var MDS = new MainDashDisplay();
            MDS.Width = GV.MWindow.Width / 2;
            MDS.Height = GV.MWindow.Height;
            Grid.SetColumn(MDS, 1);
            return MDS;
        }
    }
}
