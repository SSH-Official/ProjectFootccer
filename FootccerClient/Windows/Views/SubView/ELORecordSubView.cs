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
        DataTable dt = null;
        public List<char> list = new List<char>();
        public int currentELO { get; set; }
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
            /*ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 4;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 25;*/
            
            dt = App.Instance.DB.LHJDB.getELORecordTable();
            if (dt.Rows == null)
            {
                chart1.Titles.Add("미등록 상태");
            }
            else
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
        }

        public void setValue()
        {
            chart1.DataSource = dt;
            chart1.Series[0].XValueMember = "date";
            chart1.Series[0].YValueMembers = "elo";
            currentELO = Int32.Parse(dt.Rows[0][1].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                char result = Convert.ToChar(dr["result"]);
                char side = Convert.ToChar(dr["side"]);
                char currentResult = ((side == result) ? 'W' : 'L');
                list.Add(currentResult);
            }
        }
    }
}
