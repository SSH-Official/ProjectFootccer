using FootccerClient.Footccer;
using FootccerClient.Footccer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient
{
    partial class LoginForm
    {
        private void Login()
        {
            // DB 에서 ID 비밀번호를 입력한대로 DB에서 가져온다
            // DB저장된 비밀번호와 입력 비밀번호가 맞는지 체크한다
            // 전부 통과라면 로그인 패스시킨다. 실패시 에러 메시지

            UserCredentialDTO info = GetCredential_FromTextBox();
            bool isSuccess = App.Instance.DB.Login.CheckLoginSuccess(info);
            if (isSuccess)
            {
                UserDTO user = App.Instance.DB.Login.GetUser(info);
                App.Instance.Session.Login(user);
            }
            else
            {
                MessageBox.Show("다시 확인해주세요.?");
            }
        }
        UserCredentialDTO GetCredential_FromTextBox()
        {
            string id = tbox_id.Text;
            string password = tbox_pwd.Text;
            return new UserCredentialDTO(id, password);
        }
    }
}
