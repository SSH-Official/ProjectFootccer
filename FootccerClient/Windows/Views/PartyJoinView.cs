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
using FootccerClient.Footccer.DAO;

namespace FootccerClient.Windows.Views
{
    public partial class PartyJoinView : MasterView
    {
        FormationSubView formationViewA;
        FormationSubView formationViewB;
        List<TeamDTO> TeamListA;
        List<TeamDTO> TeamListB;

        public static int Pidx { get; set; }

        public PartyJoinView()
        {
            InitializeComponent();
        }
        public override void Refresh_View()
        {
            if (formationViewA != null&&formationViewB != null)
            {
                formationViewA.Close();
                formationViewB.Close();
            }
            ReadSQL();
            PartyInfoRead();
            FormationCreate();
            List_team();
        }


        public void ReadSQL()
        {
            TeamListA = Footccer.App.Instance.DB.Team.ReadMember(Pidx, 'A');
            TeamListB = Footccer.App.Instance.DB.Team.ReadMember(Pidx, 'B');
        }

        public void FormationCreate()
        {
            char team = rbtn_A.Checked ? 'A' : 'B';

            FormationDTO ATeamformationDTO = App.Instance.DB.PartyJoin.ReadFormationInfo(Pidx, 'A');
            FormationDTO BTeamformationDTO = App.Instance.DB.PartyJoin.ReadFormationInfo(Pidx, 'B');

            List<int> positionList = new List<int>();
            List<int> positionList2 = new List<int>();

            foreach (var Team in TeamListA)
            {
                int formation = Team.formation;
                positionList.Add(formation);
            }

            if (ATeamformationDTO == null)
            {
                ATeamformationDTO = new FormationDTO(Pidx, 'A', 3, 3, 4, 1);
            }
            if (BTeamformationDTO == null)
            {
                BTeamformationDTO = new FormationDTO(Pidx, 'A', 3, 3, 4, 1);
            }

            this.formationViewA = new FormationSubView(ATeamformationDTO, positionList);
            PositionView.Controls.Add(this.formationViewA);

            foreach (var Team in TeamListB)
            {
                int formation = Team.formation;
                positionList2.Add(formation);
            }

            this.formationViewB = new FormationSubView(BTeamformationDTO, positionList2);
            PositionView.Controls.Add(this.formationViewB);
            if (team.Equals('A'))
            {
                formationViewA.Visible = true;
                formationViewB.Visible = false;
            }
            else
            {
                formationViewA.Visible = false;
                formationViewB.Visible = true;
            }
        }

        public void List_team()
        {
            var list = rbtn_A.Checked? TeamListA : TeamListB;
            Team.DataSource = list.Select(item => new
            {
                유저 = item.UserWithTag,
                팀 = item.side,
                ELO = item.elo
            })
                .ToList();
        }

        public void PartyInfoRead()
        {
            PartyDTO pd = Footccer.App.Instance.DB.Team.readPartyInfo(Pidx);
            party_name.Text = pd.Parname;
            leader_name.Text = pd.UserWithTag;
            leader_phone.Text = pd.getphone();
            match_kind.Text = pd.Actname;
            match_time.Text = pd.date;
            match_place.Text = pd.PLname;
        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            char team = rbtn_A.Checked ? 'A' : 'B';
            int position=-1;
            if (team.Equals('A'))
            {
                position = formationViewA.selectedPositionIndex;
            }
            else
            {
                position = formationViewB.selectedPositionIndex;
            }
            ListDTO joinParty = new ListDTO(App.Instance.Session.User.Index, Pidx, team, position);
            int result=Footccer.App.Instance.DB.PartyJoin.JoinParty(joinParty);
            if (result > 0)
            {
                MessageBox.Show("성공");
                App.Instance.MainForm.ShowView<MyPartyView>();
            }
            else
            {
                MessageBox.Show("실패");
            }
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
            if (rbtn_A.Checked)
            {
                formationViewB.Visible = false;
                formationViewA.Visible = true;
                initSelecedPositionIndex(formationViewB, formationViewA);
            }
            else
            {
                formationViewB.Visible = true;
                formationViewA.Visible = false;
                initSelecedPositionIndex(formationViewA, formationViewB);
            }
            List_team();
        }
        private void initSelecedPositionIndex(FormationSubView dto1, FormationSubView dto2)
        {
            if (dto1.selectedPositionIndex != -1)
            {
                dto2.initSelectedPositionIndex();
                dto2.selectedPositionIndex = -1;
            }
        }
    }
}
