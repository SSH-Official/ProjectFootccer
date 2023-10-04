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

        public void initializeAllObject()
        {
            mbr_name.Text = string.Empty;
            mbr_age.Text = string.Empty;
            mbr_phone.Text = string.Empty;
            mbr_pic.Text = string.Empty;
            mbr_pic.Image = null;
            mbr_residence.Text = string.Empty;
            mbr_position.Text = string.Empty;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void cbox_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbox_position.Items.Clear();
            cbox_position.Text = string.Empty;
            int positionIndex = cbox_position.SelectedIndex + 1;
            List<string> list = App.Instance.DB.CreateParty.getPlaceName(positionIndex);
            addComboBoxItems(list, cbox_position);
        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            //팝업창 띄워서 팀,포지션 정하게 하기
            //팀은 radiobox이용
            //포지션은popup창 이용
        }
    }
}
