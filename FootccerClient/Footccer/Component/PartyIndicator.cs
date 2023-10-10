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
            label_Activity.Text = party.Actname;
            label_PartyName.Text = party.Parname;
            label_PartyLeaderName.Text = party.UserWithTag;
            label_HeadCount.Text = $"{party.count}/{party.max}";
        }

        public PartyIndicator(int height, Control parent, PartyDTO party , bool isSessionUserLeader = false)
        {
            InitializeComponent();
            
            InitializeValues(party);
            pictureBox_PartyLeader.Visible = isSessionUserLeader;

            this.Parent = parent;
            parent.Controls.Add(this);
            this.BringToFront();

            this.Dock = DockStyle.Top;
            this.Height = height;

            


        }

        
    }
}
