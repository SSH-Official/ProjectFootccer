using FootccerClient.Footccer;
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
            UserDTO user = new UserDTO(1, "admin");
            string oldPwd = tbox_OldPwd.Text;
            string newPwd = tbox_NewPwd.Text;
            bool isClear = isVailidPassword(oldPwd) && isVailidPassword(newPwd);
            if (isClear == false)
            {
                MessageBox.Show("입력을 다시 확인해주세요...");
                return;
            }

            if(ChangeUserPassword(user, oldPwd, newPwd))
            {
                MessageBox.Show("성공적으로 비밀번호가 변경되었습니다.");
                DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                MessageBox.Show("비밀번호 변경에 실패했습니다...");
                return;
            }
        }

        private bool ChangeUserPassword(UserDTO user,string oldPwd, string newPwd)
        {
            return App.Instance.DB.MyPage.UpdateUserPassword(user, oldPwd, newPwd);
        }

        private bool isVailidPassword(string strPwd)
        {
            return strPwd.Length > 0;
        }

    }
}
