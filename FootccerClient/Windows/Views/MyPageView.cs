using FootccerClient.Footccer;
using FootccerClient.Windows.MyPage;
using FootccerClient.Work_MyPage.DTO;
using Lib.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Windows.Views
{
    public partial class MyPageView : MasterView
    {
        public MyPageView()
        {
            InitializeComponent();
        }

        // 사실 UserCredentialDTO 에서 Index, Name은 테스트 중에 검증하지 않고 있음....
        // -> 아이디만 세션에 저장하고 DB에서 Index 등 필요한 구현을 알아서 진행하게 해도 좋을듯

        private void btn_Testssh_Click(object sender, EventArgs e)
        {
            UserCredentialDTO User = new UserCredentialDTO(1, "ssh", "성승현");
            App.Instance.Session.TestSetup(User);
            App.Instance.MainForm.ShowPop<MyPagePop>();
        }

        private void btn_TestNotExist_Click(object sender, EventArgs e)
        {
            UserCredentialDTO User = new UserCredentialDTO(-999, "!@#@#$", "테스트");
            App.Instance.Session.TestSetup(User);
            App.Instance.MainForm.ShowPop<MyPagePop>();
        }

        private void btn_TestInputID_Click(object sender, EventArgs e)
        {
            UserCredentialDTO User = new UserCredentialDTO(-999, $"{tbox_TestID.Text}", "테스트");
            App.Instance.Session.TestSetup(User);
            App.Instance.MainForm.ShowPop<MyPagePop>();
        }
    }
}
