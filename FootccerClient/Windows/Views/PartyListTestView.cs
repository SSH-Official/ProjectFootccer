using FootccerClient.Footccer.Component;
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
    public partial class PartyListTestView : MasterView
    {
        public PartyListTestView()
        {
            InitializeComponent();
            var indicator = new PartyIndicator(
                40, panel_MyPartyList,
                new Footccer.DTO.PartyDTO(1, "2", "3", "4", "5", "6", "7", "8", 10, 9, 11));            
            panel_MyPartyList.Controls.Add(indicator);
        }
    }
}
