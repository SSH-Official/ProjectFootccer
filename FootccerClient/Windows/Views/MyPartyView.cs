using FootccerClient.Footccer;
using FootccerClient.Footccer.FootccerComponent;
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
        private List<(PartyDTO, bool)> _MyPartyList { get; set; }
        private List<(PartyDTO, bool)> MyPartyList
        {
            get => _MyPartyList;
            set
            {
                _MyPartyList = value;
                IndicatorComponent.PartyListData = value;
            }
        }

        private int _CurrentPageNum { get; set; }
        private Point PageCount { get; set; }

        private int TotalPages { get => 1 + ((MyPartyList.Count - 1) / PageViewCount); }
        private int PageViewCount { get => PageCount.X * PageCount.Y; }
        
        private int CurrentPageNum
        {
            get => _CurrentPageNum;
            set
            {
                _CurrentPageNum = value;
                label_CurrentPage.Text = $"{_CurrentPageNum}/{TotalPages}";
                ShowPage(_CurrentPageNum);
            }
        }
        private void ShowPage(int pageNum)
        {
            ValidatePageNum_InBoundary(pageNum);

            IndicatorComponent.PageCursor = pageNum;

            label_Previous.Enabled = IsFirstPage(pageNum) ? false : true;
            label_Next.Enabled = IsLastPage(pageNum) ? false : true;
        }


        public MyPartyView()
        {
            InitializeComponent();
            Refresh_View();
        }

        public override void Refresh_View()
        {
            if (App.Instance.Session.Offline) return;

            PageCount = App.Instance.ProgramSettings.PartyIndicator.Count;
            panel_MyPartyList.Controls.Clear();
            IndicatorComponent = new IndicatorSpace(PageCount.X, PageCount.Y, panel_MyPartyList, 5, null, null, PartyIndicatorContext.MyParty);

            MyPartyList = App.Instance.DB.MyParty.ReadPartyListAsSession();

            CurrentPageNum = 1;
        }

        private IndicatorSpace IndicatorComponent { get; set; }
        
        private void ValidatePageNum_InBoundary(int pageNum)
        {
            if (IsPageOutOfBoundary(pageNum))
            {
                throw new Exception($"pageNum out of bound : pageNum was {pageNum} not between (1, {TotalPages})");
            }
        }
        private bool IsPageOutOfBoundary(int pageNum) => (pageNum < 1) || (TotalPages < pageNum);
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
