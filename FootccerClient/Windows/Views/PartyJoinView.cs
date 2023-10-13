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
        //FormationView formationViewA;

        public static int Pidx { get; set; }

        public PartyJoinView()
        {
            InitializeComponent();
        }
        public override void Refresh_View()
        {
            initializeAllObject();
        }

        public void List_team()
        {
            char team = rbtn_A.Checked ? 'A' : 'B';
            List<TeamDTO> _dtA = Footccer.App.Instance.DB.Team.ReadMember(Pidx, team);
            Team_A.DataSource = _dtA.Select(item => new {
                유저 = item.UserWithTag,
                팀 = item.side,
                ELO = item.elo
            })
                .ToList();
            /*this.formationViewA = new FormationView('A');
            formationSpace.Controls.Add(this.formationViewA);
            this.formationViewA.Visible = true;
            this.formationViewB = new FormationView('B');
            formationSpace.Controls.Add(this.formationViewB);
            this.formationViewB.Visible = false;*/
            //a_count.Text = _dtA.Count.ToString(); 현재 인원수 가져오기인데 필요한가?
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
            rbtn_A.Select();
        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            MessageBox.Show("참가하는 코드 작성");
        }

        public void ShowMemberInfo(int idx, int Pidx)
        {
            var DataRead = App.Instance.DB.PartyJoin.ReadUserInfo(idx, Pidx);
        }//파티원 정보 읽어오는 코드

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowView<PartySearchView>();
        }

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            List_team();
        }
    }
}
