using FootccerClient.Footccer;
using FootccerClient.Footccer.DTO;
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

namespace FootccerClient.Windows.Pops
{
    public partial class InsertResultPop : MasterPop
    {
        private int Party_idx;
        private int alter_elo;
        public InsertResultPop(int Party_idx, int alter_elo)
        {
            InitializeComponent();
            this.Party_idx = Party_idx;
            this.alter_elo = alter_elo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string score = textBoxScore.Text;
            char result;
            if(radioButtonA.Checked)
            {
                result = 'A';
            }
            else
            {
                result = 'B';
            }
            RecordDTO dto = new RecordDTO(this.Party_idx, result, score, this.alter_elo);
            int updateResult = App.Instance.DB.LHJDB.updateRecord(dto);
            if(updateResult > 0) 
            {
                int alter_elo_ForA = ((result == 'A')? 1 : -1) * alter_elo;

                App.Instance.DB.LHJDB.updateElo(Party_idx, alter_elo_ForA, 'A');
                App.Instance.DB.LHJDB.updateElo(Party_idx, -alter_elo_ForA, 'B');
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("DB연결에 문제가 발생했습니다.");
                this.DialogResult =DialogResult.Cancel;
                this.Close();
            }           
        }
    }
}
