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

        private int TotalPages { get; set; }
        private int PageViewCount { get; set; }
        private int _CurrentPageNum { get; set; }

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
                ShowPage(_CurrentPageNum, 20, 40);
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
            TotalPages = GetTotalPages();

            CurrentPageNum = 1;
        }

        private int GetTotalPages() => 1 + (MyPartyList.Count - 1) / PageViewCount;

        private void ShowPage(int pageNum, int heightCategory, int heightItems)
        {
            ValidatePageNum_InBoundary(pageNum);

            panel_MyPartyList.Controls.Clear();
            new PartyIndicator(heightCategory, panel_MyPartyList);

            for (int i = GetStartIndex(pageNum), end = GetEndIndex(i); i < end; i++)
            {
                var item = MyPartyList[i];
                new PartyIndicator(heightItems, panel_MyPartyList, party : item.Item1, isSessionUserLeader : item.Item2);
            }

            label_Previous.Enabled = IsFirstPage(pageNum) ? false : true;
            label_Next.Enabled = IsLastPage(pageNum) ? false : true;
        }
        private void ValidatePageNum_InBoundary(int pageNum)
        {
            if (IsPageOutOfBoundary(pageNum))
            {
                throw new Exception($"pageNum out of bound : pageNum was {pageNum} not between (1, {TotalPages})");
            }
        }
        private bool IsPageOutOfBoundary(int pageNum) => (pageNum < 1) || (TotalPages < pageNum);
        private int GetStartIndex(int pageNum) => (pageNum - 1) * PageViewCount;
        private int GetEndIndex(int startIndex) => Math.Min(MyPartyList.Count, startIndex + PageViewCount);
        private bool IsFirstPage(int pageNum) => (pageNum == 1);
        private bool IsLastPage(int pageNum) => (pageNum == TotalPages);


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

        private void btn_NewParty_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<PartyCreateView>();
        }
    }

    
}
