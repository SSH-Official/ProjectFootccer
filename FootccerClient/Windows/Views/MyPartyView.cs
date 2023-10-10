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
        private List<(PartyDTO, bool)> MyPartyList { get; set; }

        private int _CurrentPageNum;
        private int TotalPages;
        private int PageViewCount;

        private int CurrentPageNum
        {
            get
            {
                return _CurrentPageNum;
            }
            set
            {
                _CurrentPageNum = value;
                label_CurrentPage.Text = $"{_CurrentPageNum}/{TotalPages}";
                ShowPage(_CurrentPageNum);
            }

        }


        public MyPartyView(int pageCount = 5)
        {
            PageViewCount = pageCount;
            InitializeComponent();
        }

        public override void Refresh_View()
        {
            if (App.Instance.Session.Offline) return;

            MyPartyList = App.Instance.DB.MyParty.ReadPartyListAsSession();
            TotalPages = 1 + (MyPartyList.Count - 1) / PageViewCount;

            CurrentPageNum = 1;
        }
        


        private void btn_Record_Click(object sender, EventArgs e)
        {
            ViewPop<RecordView> pop = new ViewPop<RecordView>();
            pop.ShowDialog();
        }

        private void label_Previous_Click(object sender, EventArgs e)
        {
            CurrentPageNum--;
        }

        private void label_Next_Click(object sender, EventArgs e)
        {
            CurrentPageNum++;
        }
    }

    partial class MyPartyView
    {
        private void ShowPage(int pageNum)
        {
            ValidatePageNum_InBoundary(pageNum);

            int startIndex = (pageNum - 1) * PageViewCount;
            int endIndex = Math.Min(MyPartyList.Count, startIndex + PageViewCount);

            panel_MyPartyList.Controls.Clear();
            new PartyIndicator(20, panel_MyPartyList);

            for (int i = startIndex; i < endIndex; i++)
            {
                var item = MyPartyList[i];
                new PartyIndicator(40, panel_MyPartyList, item.Item1, item.Item2);
            }

            label_Previous.Enabled = (pageNum != 1);
            label_Next.Enabled = (pageNum != TotalPages);
        }
        private void ValidatePageNum_InBoundary(int pageNum)
        {
            if (pageNum < 1 || TotalPages < pageNum) throw new Exception($"pageNum out of bound : pageNum was {pageNum} not between (1, {TotalPages})");
        }

    }
}
