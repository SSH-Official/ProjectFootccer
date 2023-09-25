using FootccerClient.Footccer.DTO;
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

namespace FootccerClient.Windows.Pops
{
    public partial class MyPage_ChangePasswordPop : MasterPop
    {
        public MyPage_ChangePasswordPop()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO(1, "ssh");
            string oldPwd = tbox_OldPwd.Text;
            string newPwd = tbox_NewPwd.Text;
            bool isClear = isCorrectPassword(oldPwd) && isVailidPassword(newPwd);
            if (isClear)
            {
                ChangeUserPassword(user, newPwd);
            }
        }

        private void ChangeUserPassword(object user, string newPwd)
        {
            throw new NotImplementedException();
        }

        private bool isVailidPassword(string newPwd)
        {
            return false;
        }

        private bool isCorrectPassword(string oldPwd)
        {
            return oldPwd.Length > 0;
        }
    }
}
