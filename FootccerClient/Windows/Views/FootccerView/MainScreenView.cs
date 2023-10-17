using FootccerClient.Footccer;
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
            if(e.KeyCode == Keys.Escape)
            {
                MessageBox.Show("로그아웃?");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuView menuView = new MenuView();
            
            //mnekro.ckfjfjgkh
        }
    }
}
