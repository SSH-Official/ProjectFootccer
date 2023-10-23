using FootccerClient.Footccer;
using FootccerClient.Windows.MyPage;
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
using FootccerClient.Footccer.DTO;

namespace FootccerClient.Windows.Views
{
    public partial class MyPageView : MasterView
    {
        List<MasterView> m_Views = new List<MasterView>();
        UserInfoDTO userinfo;        
        public MyPageView()
        {
            userinfo = App.Instance.DB.MyPage.GetUserInfoAsSession();
            if (userinfo == null)
            {
                throw new Exception(
                    "UserInfo를 읽어오는 데에 실패했습니다.\r\n" +
                    "자세한 내용은 콘솔 로그를 확인해주세요.");
            }
            InitializeComponent();
            Createview();
            Createview1();
            InitializeGetMyinfo();
        }

        private void InitializeGetMyinfo()
        {
            PersonalStatDTO dto = Createview().psDTO;

            lb_game.Text = dto?.Game.ToString()?? "없음";
            lb_victory.Text = dto?.Victory.ToString()?? "없음";
            my_pic.BackgroundImage = userinfo.Image;
            my_pic.BackgroundImageLayout = ImageLayout.Stretch;
            my_pic.Tag = userinfo.Image?.Tag;
        }

        private MyPage_activitySubView _mpav;
        private MyPage_activitySubView Createview()
        {
            MyPage_activitySubView mpav = _mpav == null? new MyPage_activitySubView() : _mpav;
            _mpav = mpav;

            panel10.Controls.Add(mpav);
            mpav.Visible = true;
            mpav.Dock = DockStyle.Fill;
            return mpav;
        }

        private void Createview1()
        {
            ELORecordSubView erv = new ELORecordSubView();
            panel8.Controls.Add(erv);
            erv.Dock = DockStyle.Fill;
            erv.Visible = true;
            
        }

        private void btn_MyPage_Click_1(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowPop<MyPagePop>();
        }
    }
}
