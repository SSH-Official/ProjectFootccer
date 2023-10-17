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
using FootccerClient.Footccer;
using System.Web;
using FootccerClient.Footccer.DTO;
using System.Runtime.CompilerServices;

namespace FootccerClient.Windows.Views
{
    public partial class PartyCreateView : MasterView
    {
        PartyInfoSubView partyInfoView;
        FormationSubView formationViewA;
        FormationSubView formationViewB;

        public PartyCreateView()
        {
            InitializeComponent();
            createView();
            connectEvent();
        }
       
        private void createView()
        {
            this.partyInfoView = new PartyInfoSubView();
            partyInfoSpace.Controls.Add(this.partyInfoView);
            this.partyInfoView.Visible = true;
            this.formationViewA = new FormationSubView('A');
            formationSpace.Controls.Add(this.formationViewA);
            this.formationViewA.Visible = true;
            this.formationViewB = new FormationSubView('B');
            formationSpace.Controls.Add(this.formationViewB);
            this.formationViewB.Visible = false;
        }
        private void connectEvent()
        {
            btn_init.Click += (sender, e) => {
                partyInfoView.objectAllClear();
            };
            btn_regist.Click += (sender, e) =>
            {
                partyInfoView.createPartyInfoDTO(); 
                registParty();
            };            
        }        
        private void registParty()
        {
            //(수정)
            PartyInfoDTO partyInfoDTO = partyInfoView.partyInfoDTO;
            partyInfoDTO.idx = App.Instance.DB.CreateParty.setPartyDTO(partyInfoDTO);
            if (partyInfoDTO.idx != 0)
            {
                ListDTO listDTO = new ListDTO(App.Instance.Session.User.Index, partyInfoDTO.idx, judgeSide(), formationViewA.selectedPositionIndex);
                App.Instance.DB.CreateParty.setListDTO(listDTO);
                RecordDTO recordDTO = new RecordDTO(partyInfoDTO.idx);
                App.Instance.DB.CreateParty.setRecordDTO(recordDTO);
                FormationDTO teamAFormationDTO = formationViewA.formationDTO;
                FormationDTO teamBFormationDTO = formationViewB.formationDTO;                
                teamAFormationDTO.Party_idx = partyInfoDTO.idx;
                teamBFormationDTO.Party_idx = partyInfoDTO.idx;
                App.Instance.DB.CreateParty.setFormationDTO(teamAFormationDTO);
                App.Instance.DB.CreateParty.setFormationDTO(teamBFormationDTO);
                MessageBox.Show("성공");
                App.Instance.MainForm.ShowView<MyPartyView>();
            }
            else
            {
                MessageBox.Show("오류");
            }
        }
        private char judgeSide()
        {
            if(rBtn_teamA.Checked)
            {
                return 'A';
            }
            else
            {
                return 'B';
            }
        }
        private void rBtn_teamA_Click(object sender, EventArgs e)
        {
            this.formationViewA.Visible = true;
            this.formationViewB.Visible = false;
            initSelecedPositionIndex(formationViewB, formationViewA);
        }
        private void rBtn_teamB_Click(object sender, EventArgs e)
        {
            this.formationViewA.Visible = false;
            this.formationViewB.Visible = true;
            initSelecedPositionIndex(formationViewA, formationViewB);
        }
        private void initSelecedPositionIndex(FormationSubView dto1, FormationSubView dto2)
        {
            if(dto1.selectedPositionIndex != -1)
            {
                dto2.initSelectedPositionIndex();
                dto2.selectedPositionIndex = -1;
            }
        }

        private void btn_regist_Click(object sender, EventArgs e)
        {

        }
    }
}
