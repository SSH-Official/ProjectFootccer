using FootccerClient.Footccer.Manager;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FootccerClient.Footccer.LoginFeature
{
    public partial class JoinmemberPop : MasterPop
    {
        private DBManager DB
        {
            get
            {
                return App.Instance.DB;
            }
        }

        public JoinmemberPop()
        {
            InitializeComponent();
        }

        private void Joinmember_Load(object sender, EventArgs e)
        {

        }

        bool beforewrite = false;

        

        private void tbox_birth_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i <= 9; i++)
            {
                if(i==4)
                { }
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                {
                    e.Handled = true;
                }
            }

        }

        private void tbox_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void tbox_birth_Enter(object sender, EventArgs e)
        {
            tbox_birth.Text = string.Empty;
        }

        private void tbox_phone_Enter(object sender, EventArgs e)
        {
            tbox_phone.Text = string.Empty;
        }
        
        //DB에 업데이트 전 생년월일, 휴대폰번호를 확인한다.
        //DB에 정보를 insert 한다.
        // 전부 통과라면 로그인 패스시킨다. 실패시 에러 메시지
        JoinmemberInfo newmemberinfo()
        {
            string name = tbox_name.Text;
            string gender = combo_gender.Text;
            string email = tbox_email.Text;
            string id = tbox_id.Text;
            string password = tbox_pwd.Text;
            string birthday=tbox_birth.Text;
            string nickname=textBox3.Text;
            string phone = tbox_phone.Text;
            return new JoinmemberInfo(name,gender,email,id, password, birthday, nickname, phone);
        }

        private void btn_joinconfirm_Click(object sender, EventArgs e)
        {
            JoinmemberInfo info = newmemberinfo();
            bool isSuccess = DB.Login.Checkjoinmember(info);
            if (isSuccess)
            {
                MessageBox.Show(tbox_id.Text + "님 회원가입 완료, 사용할 아이디는 " + tbox_id.Text + "입니다.");
                Close();
            }
            else
            { 
                MessageBox.Show("다시 확인해주세요.?");
            }
        }
    }
}
