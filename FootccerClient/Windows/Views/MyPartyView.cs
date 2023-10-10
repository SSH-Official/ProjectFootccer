using FootccerClient.Footccer;
using FootccerClient.Footccer.Component;
using FootccerClient.Footccer.DTO;
using FootccerClient.Windows.Pops;
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

namespace FootccerClient.Windows.Views
{
    public partial class MyPartyView : MasterView
    {
        List<PartyDTO> MyPartyList;

        public MyPartyView()
        {
            InitializeComponent();
            this.Visible = true;
            MyPartyList = App.Instance.DB.MyParty.ReadPartyListAsSession();

            var indicator = new PartyIndicator(
                40, panel_MyPartyList,
                new Footccer.DTO.PartyDTO(1,"첫번째","3","4","5","6","7","8",10,9,11));

            indicator = new PartyIndicator(
                40, panel_MyPartyList,
                new Footccer.DTO.PartyDTO(2, "두번째", "3", "4", "5", "6", "7", "8", 10, 9, 11));
        }

        private void btn_Record_Click(object sender, EventArgs e)
        {
            ViewPop<RecordView> pop = new ViewPop<RecordView>();
            pop.ShowDialog();
        }

    }

    partial class MyPageView
    {
    }
}
