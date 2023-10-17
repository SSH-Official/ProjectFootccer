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
            App.Instance.MainForm.ShowView<PartySearchView>();
        }
    }
}
