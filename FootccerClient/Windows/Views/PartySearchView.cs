using FootccerClient.Footccer;
using FootccerClient.Work_PartySearch;
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
using static FootccerClient.Footccer.Manager.PartySearchDBExecuter;


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
            
            if(kind == "지역" || kind == "종류")
            {
                S_Combo_P.Visible = true;
                S_Text_P.Visible = false;
                S_Date_P.Visible = false;
                if(kind == "지역")
                {
                    List<CityDTO> city = Footccer.App.Instance.DB.PartySearch.ReadAllCity();
                    SearchCombo.Items.Clear();
                    foreach (var item in city)
                    {
                        SearchCombo.Items.Add(new ComboItem(item.Name,item.Index));
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
            }else if (kind=="날짜") {
                S_Date_P.Visible = true;
                S_Text_P.Visible = false;
                S_Combo_P.Visible = false;
            }else {
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
                seed = SearchDate.Text;
            }
            else
            {
                seed=SearchText.Text;
            }
            List _dt = Footccer.App.Instance.DB.PartySearch.ReadParty(_seed);
        }
    }
}
