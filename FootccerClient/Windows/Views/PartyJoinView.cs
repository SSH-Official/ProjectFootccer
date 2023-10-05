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
        public PartyJoinView()
        {
            InitializeComponent();
            initializeAllObject();
        }

        public void List_team()
        {
            List<TeamDTO> _dtA = Footccer.App.Instance.DB.team.Readmember("'A'");
            Team_A.DataSource = _dtA;
            a_count.Text = _dtA.Count.ToString();

            List<TeamDTO> _dtB = Footccer.App.Instance.DB.team.Readmember("'B'");
            Team_B.DataSource = _dtB;
            b_count.Text = _dtB.Count.ToString();
        }
        
        public void initializeAllObject()
        {
            PartyDTO pd = Footccer.App.Instance.DB.team.readPartyInfo();
            party_name.Text = pd.Parname;
            leader_name.Text = pd.UserWithTag;
            leader_phone.Text = pd.getphone();
            match_kind.Text = pd.Actname;
            match_time.Text = pd.date;
            match_place.Text = pd.PLname;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

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

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PartyJoinView_Load(object sender, EventArgs e)
        {
            List_team();
        }

        private void Team_A_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Hi");
        }
    }
}
