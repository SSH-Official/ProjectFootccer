using FootccerClient.Footccer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.FootccerComponent
{
    public partial class PartyIndicatorItem : UserControl
    {
        public PartyDTO Value { get; set; }
        public PartyIndicatorItem()
        {
            InitializeComponent();
        }

        public void UpdateInfo(PartyDTO partyDTO)
        {
            Value = partyDTO;

            panel_Base.BackColor = GetBorderColor();
            label_Information.Text = GetInfoText();
        }

        private string GetInfoText()
        {
            return
                $"{Value.Actname.Substring(0, 2)}\r\n" +
                $"{Value.date.ParseToString_FromDateString(false)}\r\n" +
                $"{Value.PLname}\r\n" +
                $"{Value.Parname} ({Value.UserWithTag})";
                ;
        }

        private Color GetBorderColor()
        {
            switch (Value.Actname.Substring(0,2))
            {
                case "축구":
                    return Color.YellowGreen;
                case "풋살":
                    return Color.Cyan;
                default:
                    return Color.Magenta;
            }
        }

    }
}
