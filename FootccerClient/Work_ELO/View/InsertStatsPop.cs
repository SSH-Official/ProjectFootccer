using FootccerClient.Footccer;
using FootccerClient.Work_ELO.DB;
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

namespace FootccerClient.Work_ELO.View
{
    public partial class InsertStatsPop : MasterPop
    {
        private int List_idx;
        private bool isNew = true;
        public InsertStatsPop(int List_idx)
        {
            InitializeComponent();
            this.List_idx = List_idx;
            getStat();
        }
        private void getStat()
        {
            StatDTO dto = App.Instance.DB.LHJDB.getStat(List_idx);
            if(dto != null)
            {
                isNew = false;
                tBox_score.Text = dto.score.ToString();
                tBox_assist.Text = dto.assist.ToString();
                tBox_distance.Text = dto.distance.ToString();
                tBox_heartRate.Text = dto.heartRate.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int score = int.Parse(tBox_score.Text);
            int assist = int.Parse(tBox_assist.Text);
            int distance = int.Parse(tBox_distance.Text);
            int heartRate = int.Parse(tBox_heartRate.Text);
            int result = 0;
            StatDTO stat = new StatDTO(List_idx, score, assist, distance, heartRate);
            if (isNew)
            {
                result = App.Instance.DB.LHJDB.insertStat(stat);
            }
            else
            {
                result = App.Instance.DB.LHJDB.updateStat(stat);
            }

            if (result > 0)
            {
                MessageBox.Show("성공");
                this.Close();
            }
            else
            {
                MessageBox.Show("실패");
            }
        }

        
    }
}
