using FootccerClient.Footccer.DTO;
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

namespace FootccerClient.Windows.Views
{
    public partial class PartyInfoView : MasterView
    {
        public PartyInfoDTO partyInfoDTO { get; set; }

        public PartyInfoView()
        {
            InitializeComponent();
            initializeCBox_city();
        }

        public void objectAllClear()
        {
            tBox_partyName.Text = string.Empty;
            dateTimePicker.Value = DateTime.Now;
            cBox_city.Text = string.Empty;
            cBox_placeName.Items.Clear();
            cBox_placeName.Text = string.Empty;
            cBox_activity.Text = string.Empty;
            tBox_max.Text = string.Empty;
            label_placeAddress.Text = string.Empty;
        }

        public void createPartyInfoDTO()
        {
            int SamepleIndex = App.Instance.Session.User.Index;
            if (cBox_activity.SelectedIndex != 2)
            {
                partyInfoDTO = new PartyInfoDTO(cBox_activity.SelectedIndex + 1, SamepleIndex, tBox_partyName.Text, Int32.Parse(label_placeAddress.Tag.ToString()), dateTimePicker.Value);
            }
            else if (cBox_activity.SelectedIndex == 2)
            {
                partyInfoDTO = new PartyInfoDTO(cBox_activity.SelectedIndex + 1, SamepleIndex, tBox_partyName.Text, Int32.Parse(label_placeAddress.Tag.ToString()), dateTimePicker.Value, Int32.Parse(tBox_max.Text));
            }
        }


        private void addComboBoxItems(List<string> list, ComboBox cBox)
        {
            for (int i = 0; i < list.Count; i++)
            {
                cBox.Items.Add(list[i]);
            }
        }

        private void initializeCBox_city()
        {
            List<string> list = App.Instance.DB.CreateParty.getCityName();
            addComboBoxItems(list, cBox_city);
        }

        private void cBox_city_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBox_placeName.Items.Clear();
            cBox_placeName.Text = string.Empty;
            label_placeAddress.Text = string.Empty;
            int cityIndex = cBox_city.SelectedIndex + 1;
            List<string> list = App.Instance.DB.CreateParty.getPlaceName(cityIndex);
            addComboBoxItems(list, cBox_placeName);
        }

        private void cBox_placeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_placeAddress.Text = string.Empty;
            int cityIndex = cBox_city.SelectedIndex + 1;
            string name = cBox_placeName.SelectedItem.ToString();
            (string Address, int Idx) tuple = App.Instance.DB.CreateParty.getPlaceAddress(cityIndex, name);
            label_placeAddress.Text = tuple.Item1;
            label_placeAddress.Tag = tuple.Item2;
        }

        private void cBox_activity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBox_activity.SelectedIndex == 2)
            {
                tBox_max.Visible = true;
                panel_max.Visible = true;
            }
            else
            {
                tBox_max.Visible = false;
                panel_max.Visible = false;
            }
        }
    }
}
