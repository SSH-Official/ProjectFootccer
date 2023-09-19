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
using FootccerClient.Footccer.Manager.CreateParty;
using FootccerClient.Footccer;
using System.Web;

namespace FootccerClient.Windows.Views
{
    public partial class PartyCreateView : MasterView
    {
        public PartyCreateView()
        {
            InitializeComponent();
            initializeObject();
        }

        private void initializeObject()
        {
            List<string> list = App.Instance.DB.Lhj.getCityName();
            addComboBox(list, cBox_City);
        }

        private void cBox_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBox_placeName.Items.Clear();
            cBox_placeName.Text = string.Empty;
            label_placeAddress.Text = string.Empty;
            int cityIndex = cBox_City.SelectedIndex + 1;
            List<string> list = App.Instance.DB.Lhj.getPlaceName(cityIndex);
            addComboBox(list, cBox_placeName);
        }

        private void cBox_placeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_placeAddress.Text = string.Empty;
            int cityIndex = cBox_City.SelectedIndex + 1;
            string name = cBox_placeName.SelectedItem.ToString();            
            (string Address, int Idx) tuple = App.Instance.DB.Lhj.getPlaceAddress(cityIndex, name);            
            label_placeAddress.Text = tuple.Item1;
            label_placeAddress.Tag = tuple.Item2;
        }

        private void btn_register_Click(object sender, EventArgs e)
        {            
            CreatePartyDTO dto = new CreatePartyDTO(cBox_activity.SelectedIndex + 1, 2, tBox_partyName.Text, Int32.Parse(label_placeAddress.Tag.ToString()), dateTimePicker.Value);            
            int result = App.Instance.DB.Lhj.setPartyDTO(dto);
            if (result < 0){
                MessageBox.Show("오류");
            }
            else
            {
                MessageBox.Show("성공");
            }
        }


        private void addComboBox(List<string> list, ComboBox cBox)
        {
            for (int i = 0; i < list.Count; i++)
            {
                cBox.Items.Add(list[i]);
            }
        }
    }
}
