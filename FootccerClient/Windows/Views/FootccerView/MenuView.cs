using Lib.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Windows.Views.FootccerView
{
    public partial class MenuView : MasterView
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void button_BackToMainMenu_Click(object sender, EventArgs e)
        {
            GoBackToMainMenu();
        }

        private void MenuView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                GoBackToMainMenu();
            }
        }

        protected void GoBackToMainMenu()
        {
            throw new NotImplementedException();
        }
    }
}
