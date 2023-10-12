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
using FootccerClient.Footccer.DTO;

namespace FootccerClient.Windows.Views
{
    public partial class PartyJoinView : MasterView
    {
        public static int Pidx { get; set; }

        public PartyJoinView()
        {
            InitializeComponent();
        }
        public override void Refresh_View()
        {
            clearMember();
            initializeAllObject();
            List_team();
        }

        public void List_team()
        {
            List<TeamDTO> _dtA = Footccer.App.Instance.DB.Team.Readmember("'A'",Pidx);
            Team_A.DataSource = _dtA;
            a_count.Text = _dtA.Count.ToString();

            List<TeamDTO> _dtB = Footccer.App.Instance.DB.Team.Readmember("'B'",Pidx);
            Team_B.DataSource = _dtB;
            b_count.Text = _dtB.Count.ToString();
        }
        
        public void initializeAllObject()
        {
            PartyDTO pd = Footccer.App.Instance.DB.Team.readPartyInfo(Pidx);
            party_name.Text = pd.Parname;
            leader_name.Text = pd.UserWithTag;
            leader_phone.Text = pd.getphone();
            match_kind.Text = pd.Actname;
            match_time.Text = pd.date;
            match_place.Text = pd.PLname;

        }

        private void addComboBoxItems(List<string> list, ComboBox cBox)
        {
            for (int i = 0; i < list.Count; i++)
            {
                cBox.Items.Add(list[i]);
            }
        }

        /*private void cbox_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbox_position.Items.Clear();
            cbox_position.Text = string.Empty;
            int positionIndex = cbox_position.SelectedIndex + 1;
            List<string> list = App.Instance.DB.CreateParty.getPlaceName(positionIndex);
            addComboBoxItems(list, cbox_position);
        }*/

        private void btn_join_Click(object sender, EventArgs e)
        {
            //팝업창 띄워서 팀,포지션 정하게 하기
            //팀은 radiobox이용
            //포지션은popup창 이용
        }

        public void clearMember()
        {
            mbr_name.Text = "";
            mbr_gender.Text = "";
            mbr_email.Text = "";
            mbr_phone.Text = "";
            mbr_position.Text = "";
            mbr_residence.Text = "";
        }
        private void Team_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearMember();
            if (e.RowIndex >= 0)
            {
                TeamDTO selectedPersonnel = ((sender as DataGridView).DataSource as List<TeamDTO>)[e.RowIndex];
                ShowMemberInfo(selectedPersonnel.getidx(),Pidx);                
            }            
        }

        public void ShowMemberInfo(int idx,int Pidx)
        {
            var DataRead = App.Instance.DB.PartyJoin.ReadUserInfo(idx, Pidx);
            mbr_name.Text=DataRead.UserWithTag.ToString();
            mbr_gender.Text = DataRead.gender.ToString();
            mbr_phone.Text = DataRead.contact.ToString();
            mbr_email.Text = DataRead.email.ToString();
            mbr_position.Text = DataRead.position.ToString();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<PartySearchView>();
        }

        private void btn_join_Click_1(object sender, EventArgs e)
        {

        }
    }
}
