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

namespace FootccerClient.Work_ELO.View
{
    public partial class RecordView : MasterView
    {        
        private List<Button> buttons = new List<Button>();
        private Label[,] labels = new Label[5, 4];
        private DataTable dt;
        private int currentPage = 1;
        private int pageSize;
        public RecordView()
        {
            InitializeComponent();
            initializeLabel();
            initializeButton();
            setRecordTable();
            updateRecord(1);
            initializePage();
        }
        public void setRecordTable()
        {
            dt = App.Instance.DB.LHJDB.getRecordTable();
            if(dt != null )
            {
                this.pageSize = Convert.ToInt32(Math.Ceiling(dt.Rows.Count / 5.0));
            }
        }
        public void initializePage()
        {
            label_previous.Text = 1.ToString();
            label_next.Text = pageSize.ToString();
        }
        public void initializeButton()
        {
            for(int i = 1; i <= 5; i++)
            {
                string buttonName = "button" + i;

                Control[] controls = this.Controls.Find(buttonName, true);

                if( controls != null && controls[0] is Button)
                {
                    Button btn = (Button)controls[0];
                    btn.Visible = false;
                    buttons.Add(btn);
                }
            }
        }
        public void initializeLabel()
        {
            for(int row = 0; row < 5; row++)
            {
                for(int col = 0; col < 4; col++)
                {
                    string labelName = "label" + (row * 4 + col + 1);
                    Label label = this.Controls.Find(labelName, true).FirstOrDefault() as Label;
                    if(label != null)
                    {
                        labels[row, col] = label;
                        label.Text = string.Empty;
                    }
                }
            }
        }
        public void updateRecord(int currentPage)
        {            
            for(int row = 0; row < 5; row++)
            {
                DataRow dr = null;
                if(dt.Rows.Count > row * currentPage)
                {
                    dr = dt.Rows[row * currentPage];
                }                
                for(int col = 0; col < 4; col++)
                {
                    if(dr != null)
                    {
                        labels[row, col].Text = dr[col].ToString();
                    }
                    else
                    {
                        labels[row, col].Text = string.Empty;
                    }
                }
            }
        }

        private void label_previous_Click(object sender, EventArgs e)
        {
            if(this.currentPage > 1)
            {
                this.currentPage -= 1;
                updateRecord(this.currentPage);
            }            
        }

        private void label_next_Click(object sender, EventArgs e)
        {
            if(this.currentPage < pageSize)
            {
                this.currentPage += 1;
                updateRecord(this.currentPage);
            }
        }
    }
}
