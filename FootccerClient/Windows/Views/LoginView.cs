using FootccerClient.Footccer;
using FootccerClient.Footccer.LoginFeature;
using FootccerClient.Footccer.Manager;
using Lib.Frame;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Windows.Views
{
    public partial class LoginView : MasterView
    {
       private DBManager DB 
        { 
            get 
            {
                return App.Instance.DB;
            }
        }

        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            loginclick();
        }

        
        UserCredential GetCredential_FromTextBox()
        {
            string id = tbox_id.Text;
            string password = tbox_pwd.Text;
            return new UserCredential(id, password);
        }

        /// <summary>
        /// // DB 에서 ID 비밀번호를 입력한대로 DB에서 가져온다
        /// DB저장된 비밀번호와 입력 비밀번호가 맞는지 체크한다
        /// 전부 통과라면 로그인 패스시킨다. 실패시 에러 메시지
        /// </summary>
        private void loginclick()
        {
            // DB 에서 ID 비밀번호를 입력한대로 DB에서 가져온다
            // DB저장된 비밀번호와 입력 비밀번호가 맞는지 체크한다
            // 전부 통과라면 로그인 패스시킨다. 실패시 에러 메시지
            
            UserCredential info = GetCredential_FromTextBox();
            bool isSuccess = DB.Login.CheckLoginSuccess(info);
            if (isSuccess)
            {
               MessageBox.Show("성공");
            }
            else
            {
                MessageBox.Show("다시 확인해주세요.?");
            }
        }

        private void btn_join_Click(object sender, EventArgs e)
        {   
            //회원가입 폼 만들기
            //Form2 showform2 = new Form2();
            //showform2.ShowDialog();
        }
    }
}
