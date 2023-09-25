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

namespace FootccerClient.Windows.Views
{
    public partial class PartyCreateView : MasterView
    {
        public PartyCreateView()
        {
            InitializeComponent();
            initializeObject();
        }

        private void initializeAllObject() 
        {
            tBox_partyName.Text = string.Empty;
            dateTimePicker.Value = DateTime.Now;
            cBox_City.Text = string.Empty;
            cBox_placeName.Items.Clear();
            cBox_placeName.Text = string.Empty;
            cBox_activity.Text = string.Empty;
            tBox_max.Text = string.Empty;
            label_placeAddress.Text = string.Empty;
        }

        private void addComboBoxItems(List<string> list, ComboBox cBox)
        {
            for (int i = 0; i < list.Count; i++)
            {
                cBox.Items.Add(list[i]);
            }
        }

        private void initializeObject()
        {
            List<string> list = App.Instance.DB.CreateParty.getCityName();
            addComboBoxItems(list, cBox_City);
        }

        private void cBox_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBox_placeName.Items.Clear();
            cBox_placeName.Text = string.Empty;
            label_placeAddress.Text = string.Empty;
            int cityIndex = cBox_City.SelectedIndex + 1;
            List<string> list = App.Instance.DB.CreateParty.getPlaceName(cityIndex);
            addComboBoxItems(list, cBox_placeName);
        }

        private void cBox_placeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_placeAddress.Text = string.Empty;
            int cityIndex = cBox_City.SelectedIndex + 1;
            string name = cBox_placeName.SelectedItem.ToString();            
            (string Address, int Idx) tuple = App.Instance.DB.CreateParty.getPlaceAddress(cityIndex, name);            
            label_placeAddress.Text = tuple.Item1;
            label_placeAddress.Tag = tuple.Item2;
        }

        //(수정)생성할때 세션아이디로 글쓴이 넣어줘야함
        //지금은 그냥 임의로 넣음
        private void btn_register_Click(object sender, EventArgs e)
        {
            CreatePartyDTO dto = null;
            if(cBox_activity.SelectedIndex != 2)
            {
                dto = new CreatePartyDTO(cBox_activity.SelectedIndex + 1, 2, tBox_partyName.Text, Int32.Parse(label_placeAddress.Tag.ToString()), dateTimePicker.Value);
            }
            else if(cBox_activity.SelectedIndex == 2)
            {
                dto = new CreatePartyDTO(cBox_activity.SelectedIndex + 1, 2, tBox_partyName.Text, Int32.Parse(label_placeAddress.Tag.ToString()), dateTimePicker.Value, Int32.Parse(tBox_max.Text));
            }
            int partyIdx = App.Instance.DB.CreateParty.setPartyDTO(dto);
            if (partyIdx != 0){
                ListDTO listDTO = new ListDTO(2, partyIdx, Char.Parse(cBox_side.SelectedItem.ToString()), cBox_position.SelectedIndex);
                App.Instance.DB.CreateParty.setListDTO(listDTO);
                MessageBox.Show("성공");
            }
            else
            {
                MessageBox.Show("오류");                
            }
        }

        private void cBox_activity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBox_activity.SelectedIndex == 2)
            {
                tBox_max.Visible = true;
            }
            else
            {
                tBox_max.Visible = false;
            }
        }

        private void btn_lnit_Click(object sender, EventArgs e)
        {
            initializeAllObject();
        }
    }
}
