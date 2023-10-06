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
            List<TeamDTO> _dtA = Footccer.App.Instance.DB.Team.Readmember("'A'");
            Team_A.DataSource = _dtA;
            a_count.Text = _dtA.Count.ToString();

            List<TeamDTO> _dtB = Footccer.App.Instance.DB.Team.Readmember("'B'");
            Team_B.DataSource = _dtB;
            b_count.Text = _dtB.Count.ToString();
        }
        
        public void initializeAllObject()
        {
            PartyDTO pd = Footccer.App.Instance.DB.Team.readPartyInfo();
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
        public void clearMember()
        {
            mbr_name.Text = "";
            mbr_gender.Text = "";
            mbr_email.Text = "";
            mbr_phone.Text = "";
            mbr_position.Text = "";
            mbr_residence.Text = "";
        }
        private void Team_A_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearMember();
            if (e.RowIndex >= 0)
            {
                TeamDTO selectedPersonnel = (Team_A.DataSource as List<TeamDTO>)[e.RowIndex];
                ShowMemberInfo(selectedPersonnel.getidx());                
            }            
        }

        public void ShowMemberInfo(int idx)
        {
            var DataRead = App.Instance.DB.PartyJoin.ReadUserInfo(idx);

            //DataRead.Item1
            //mbr_name.Text = DataRead.Name;

            // 1. 여기서 쓸 전용 DTO를 만든다...
            //      1.1 PJDTO -> Name Gender ... 가지게. > 1.1
            //          PJDTO.Name;
            //      1.2 PJDTO -> UserInfo, Position
            //          PJDTO.UserInfo.Name;

            // 2. 튜플로 가져온다
            //  (UserInfoDTO userinfo, PositionDTO position)



            // 이름 성별 거주지 연락처 이메일 -> UserInfo DTO에서 읽을 수 있음
            // 포지션-> 파티에 내가 할당된 포지션.. 다른 DTO(DB테이블)에서..

            // 각각 TextBox에 뿌려야함....
            //mbr_name.Text = DataRead.Name;
            // ...
        }


    }
}
