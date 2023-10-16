using FootccerClient.Footccer;
using FootccerClient.Footccer.DTO;
using FootccerClient.Footccer.Util;
using Lib.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FootccerClient.Windows.Views
{
    public partial class PartySearchView : MasterView
    {
        public PartySearchView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Search_kind.SelectedIndex = 0;
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
            dataGridView1.DataSource = _dt
                .Select(item => new {
                    Idx = item.idx,
                    Name = item.Parname
                })
                .ToList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<PartyCreateView>();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Ridx = e.RowIndex;
            if (Ridx >= 0)
            {
                int pidx = Convert.ToInt32(dataGridView1.Rows[Ridx].Cells[0].Value.ToString());
                PartyJoinView.Pidx = pidx;

                App.Instance.MainForm.ShowView<PartyJoinView>();
            }
        }
    }
}
