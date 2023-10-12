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
using Lib.Frame;

namespace FootccerClient.Windows.Views
{
    public partial class ELORecordView : MasterView
    {
        DataTable dt = null;
        public ELORecordView()
        {
            InitializeComponent();
            initializeChart();
            setValue();
        }

        public void initializeChart()
        {
            dt = App.Instance.DB.LHJDB.getELORecordTable();
            DataRow dr = dt.Rows[0];
            int currentELO = Int32.Parse(dr["elo"].ToString());
            for(int i = 1; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                char side = Convert.ToChar(dr["side"]);
                char result = Convert.ToChar(dr["result"]);
                int alterELO = Int32.Parse(dr["alter_elo"].ToString());
                alterELO = ((side == result) ? 1 : -1) * alterELO;
                dt.Rows[i][1] = currentELO - alterELO;
            }
        }

        public void setValue()
        {
            chart1.DataSource = dt;
            chart1.Series[0].XValueMember = "date";
            chart1.Series[0].YValueMembers = "elo";
        }
    }
}
