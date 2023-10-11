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

namespace FootccerClient.Footccer.Component
{
    public partial class PartyIndicator : UserControl
    {
        public PartyIndicator()
        {
            InitializeComponent();
        }

        public void InitializeValues(PartyDTO party)
        {
            label_Date.Text = party.date;
            label_Activity.Text = GetActivityNameText(party.Actname);
            label_PartyName.Text = party.Parname;
            label_PartyLeaderName.Text = party.UserWithTag;
            label_HeadCount.Text = $"{party.count}/{party.max}";
        }

        private string GetActivityNameText(string actname)
        {
            string[] strArr = actname.Split('_');
            switch (strArr[0])
            {
                case "축구":
                    return $"{actname}({11}:{11})";
                case "풋살":
                    return $"{actname}({5}:{5})";
                default:
                    return actname;
            }
        }

        public PartyIndicator(int height, Control parent, PartyDTO party = null , bool isSessionUserLeader = false)
        {
            InitializeComponent();

            if (party != null)
            {
                InitializeValues(party);
            }

            pictureBox_PartyLeader.Visible = isSessionUserLeader;


            this.Dock = DockStyle.Top;
            this.Height = height;

            this.Parent = parent;
            parent.Controls.Add(this);
            this.BringToFront();


            


        }

        
    }
}
