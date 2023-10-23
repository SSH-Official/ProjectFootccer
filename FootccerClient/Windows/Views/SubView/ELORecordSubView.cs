using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FootccerClient.Footccer;
using Lib.Frame;

namespace FootccerClient.Windows.Views
{
    public partial class ELORecordSubView : MasterView
    {
        public DataTable dt = null;
        public ELORecordSubView()
        {
            InitializeComponent();
            initializeChart();
            setValue();
        }

        public void initializeChart()
        {
            chart1.Titles.Add("ELO 변경");
            chart1.Series[0].Name = "ELO";
            chart1.ChartAreas[0].AxisY.Minimum = 2150;
            chart1.ChartAreas[0].AxisY.Maximum = 2300;
/*
            var validRows = dt.AsEnumerable().Where(row => row.Field<DateTime?>("date") != null);


            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
*/

            dt = App.Instance.DB.LHJDB.getELORecordTable();
            
            if (dt.Rows.Count != 0)
            {
                DataRow dr = dt.Rows[0];
                int currentELO = Int32.Parse(dr["elo"].ToString());
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    char side = Convert.ToChar(dr["side"]);
                    char result = Convert.ToChar(dr["result"]);
                    int alterELO = Int32.Parse(dr["alter_elo"].ToString());
                    alterELO = ((side == result) ? 1 : -1) * alterELO;
                    dt.Rows[i][1] = currentELO - alterELO;
                }
            }
            else
            {
                chart1.Visible = false;
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
