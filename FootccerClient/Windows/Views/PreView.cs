using FootccerClient.Footccer.DAO;
using FootccerClient.Footccer.FootccerComponent;
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
    public partial class PreView : MasterView
    {
        IncidatorSpace TestObject { get; set; }
        public PreView()
        {
            InitializeComponent();
            

            
            panel_Base.Click += (sender, e) =>
            {
                MessageBox.Show(panel_Base.Size.ToString());
            };
        }

        public override void Refresh_View()
        {
            panel_Base.Controls.Clear();
            TestObject = new IncidatorSpace(5, 3, panel_Base, 5);
            TestObject.PartyList = new TemporaryDAO().ReadAllPartyList();
            TestObject.PageCursor = 1;
        }

        private void PreView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                TestObject.ShowDebugLog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
