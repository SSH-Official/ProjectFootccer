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

        private void button_MyParty_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<MyPartyView>("내 파티");
        }

        private void button_FindParty_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<PartySearchView>("파티 검색");
        }

        private void button_MyPage_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<MyPageView>("마이페이지");
        }

        private void button_Config_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<ConfigView>();
        }

        private void MainScreenView_SizeChanged(object sender, EventArgs e)
        {
            Size size = panel_Base.Size;
            Size flpSize = flowLayoutPanel_MenuButtons.Size;
            Size logoSize = pictureBox_Logo.Size;

            int X = (size.Width - flpSize.Width) / 2;
            int Y = size.Height * 6 / 9;
            flowLayoutPanel_MenuButtons.Location = new Point(X, Y);
            int logoX = (size.Width - logoSize.Width) / 2;
            int logoY = size.Height * 5 / 24;
            pictureBox_Logo.Location = new Point(logoX, logoY);
        }
    }
}
