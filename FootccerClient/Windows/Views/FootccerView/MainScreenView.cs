using FootccerClient.Footccer;
using FootccerClient.Windows.Views.SubMenu;
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
    public partial class MainScreenView : MasterView
    {
        public MainScreenView()
        {
            InitializeComponent();
        }

        private void MainScreenView_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button_MyParty_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<MyPartyMenuView>();
        }

        private void button_FindParty_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<MenuView>();
        }

        private void button_MyPage_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<MenuView>();
        }

        private void button_Config_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<MenuView>();
        }
    }
}
