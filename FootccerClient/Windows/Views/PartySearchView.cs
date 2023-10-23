using FootccerClient.Footccer;
using FootccerClient.Footccer.DTO;
using FootccerClient.Footccer.FootccerComponent;
using FootccerClient.Footccer.Util;
using Lib.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Windows.Views
{
    public partial class PartySearchView : MasterView
    {
        private IndicatorSpace IndicatorComponent { get; set; }

        private Point PageCount { get => App.Instance.ProgramSettings.PartyIndicator.Count; }
        private int TotalPages { get =>  
                PartyList.Count == 0? 0 :
                ( 1 + ((PartyList.Count - 1) / PageViewCount) ); }
        private int PageViewCount { get => PageCount.X * PageCount.Y; }

        private List<PartyDTO> _PartyList { get; set; }
        private List<PartyDTO> PartyList
        {
            get => _PartyList;
            set
            {
                if (value == null) value = new List<PartyDTO>();

                _PartyList = value;
                IndicatorComponent.PartyListData = value;

                CurrentPageNum = 1;
            }
        }
        private void NullPage()
        {
            _CurrentPageNum = 1;
            //PartyList = null;
            label_CurrentPage.Text = $"검색결과 없음";
            label_Previous.Enabled = false;
            label_Next.Enabled = false;
        }

        private int _CurrentPageNum { get; set; }
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
            if (TotalPages == 0) { NullPage(); return; }
            else { ValidatePageNum_InBoundary(pageNum); }

            IndicatorComponent.PageCursor = pageNum;

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
        private bool IsFirstPage(int pageNum) => (pageNum == 1);
        private bool IsLastPage(int pageNum) => (pageNum == TotalPages);


        public PartySearchView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Search_kind.SelectedIndex = 0;
        }


        public override void Refresh_View()
        {
            if (App.Instance.Session.Offline) return;

            panel_PartyList.Controls.Clear();
            IndicatorComponent = new IndicatorSpace(PageCount.X, PageCount.Y, panel_PartyList, 5, null, null, PartyIndicatorContext.PartySearch);

            PartyList = null;
        }


        private void Search_kind_SelectedIndexChanged(object sender, EventArgs e)
        {

            string kind = Search_kind.Text;

            if (kind == "지역" || kind == "종류")
            {
                S_Combo_P.Visible = true;
                S_Text_P.Visible = false;
                S_Date_P.Visible = false;
                if (kind == "지역")
                {
                    List<CityDTO> city = Footccer.App.Instance.DB.PartySearch.ReadAllCity();
                    SearchCombo.Items.Clear();
                    foreach (var item in city)
                    {
                        SearchCombo.Items.Add(new ComboItem(item.Name, item.Index));
                    }
                    SearchCombo.SelectedIndex = 0;
                }
                else
                {
                    List<ActivityDTO> activities = Footccer.App.Instance.DB.PartySearch.ReadAllActivities();
                    SearchCombo.Items.Clear();
                    foreach (var item in activities)
                    {
                        SearchCombo.Items.Add(new ComboItem(item.Name, item.Index));
                    }
                    SearchCombo.SelectedIndex = 0;
                }
            }
            else if (kind == "날짜")
            {
                S_Date_P.Visible = true;
                S_Text_P.Visible = false;
                S_Combo_P.Visible = false;
            }
            else
            {
                S_Text_P.Visible = true;
                S_Combo_P.Visible = false;
                S_Date_P.Visible = false;
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string kind = Search_kind.Text;
            string seed;
            if (kind == "지역" || kind == "종류")
            {
                ComboItem _item = SearchCombo.SelectedItem as ComboItem;
                seed = _item.Value.ToString();
            }
            else if (kind == "날짜")
            {
                string originalDateString = SearchDate.Text;
                CultureInfo cultureInfo = new CultureInfo("ko-KR");
                DateTime originalDate = DateTime.ParseExact(originalDateString, "yyyy'년' M'월' d'일' dddd", cultureInfo);
                seed = originalDate.ToString("yyyy-M-d");
            }
            else
            {
                seed = SearchText.Text;
            }
            List<PartyDTO> _dt = Footccer.App.Instance.DB.PartySearch.ReadParty(kind, seed);
            PartyList = _dt;
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<PartyCreateView>();
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
}
