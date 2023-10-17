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
    public partial class ConfigView : MasterView
    {
        public ConfigView()
        {
            InitializeComponent();
        }

        public override void Refresh_View()
        {
            var settings = App.Instance.ProgramSettings;
            numericUpDown_X.Value = settings.PartyIndicator.Count.X;
            numericUpDown_Y.Value = settings.PartyIndicator.Count.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var settings = App.Instance.ProgramSettings;
            var counts = new Point((int)numericUpDown_X.Value, (int)numericUpDown_Y.Value);
            settings.PartyIndicator.Count = counts;

            MessageBox.Show("저장되었습니다.");
            Refresh_View();
        }
    }
}
