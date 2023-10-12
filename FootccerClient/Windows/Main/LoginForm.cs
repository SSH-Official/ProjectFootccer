using FootccerClient.Footccer;
using FootccerClient.Footccer.DTO;
using FootccerClient.Windows.Views;
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

namespace FootccerClient
{
    public partial class LoginForm : MasterPop
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            MessageBox.Show("미구현기능입니다....");
            // TODO
        }

        private void btn_Join_Click(object sender, EventArgs e)
        {
            JoinmemberPop _pop = new JoinmemberPop();
            _pop.ShowDialog(this);
        }

        private void tbox_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbox_pwd.Focus();
            }
        }

        private void tbox_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
    }
    
}

