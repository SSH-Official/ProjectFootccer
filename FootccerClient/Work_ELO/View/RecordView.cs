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
using FootccerClient.Work_ELO.DB;
using Lib.Frame;

namespace FootccerClient.Work_ELO.View
{
    public partial class RecordView : MasterView
    {        
        private List<Button> buttons = new List<Button>();
        private Label[,] labels = new Label[5, 4];
        private List<Panel> panels = new List<Panel>();
        private DataTable dt;
        private int currentPage = 1;
        private int pageSize;
        List<Control> CreatedControls { get; set; } = new List<Control>();

        void setRecordTable()
        {
            dt = App.Instance.DB.LHJDB.getRecordTable();
            if (dt != null)
            {
                this.pageSize = Convert.ToInt32(Math.Ceiling(dt.Rows.Count / 5.0));
            }
        }
        public void updateRecord(int currentPage)
        { 
            ClearCreatedConrols();
            for (int row = 0; row < 5; row++)
            {
                DataRow dr = null;
                if (dt.Rows.Count > row * currentPage)
                {
                    dr = dt.Rows[row * currentPage];
                }
                for (int col = 0; col < 4; col++)
                {
                    setLabelText(dr, row, col, labels);
                }
                buttons[row].Visible = (dr != null);
            }
        }
        private void setLabelText(DataRow dr, int row, int col, Label[,] labels)
        {
            if (dr != null)
            {
                labels[row, col].Visible = true;
                labels[row, col].Text = dr[col].ToString();
                if (col == 3 &&  String.IsNullOrEmpty(dr["result"].ToString()))
                {                                        
                    if (Convert.ToInt32(dr["Leader_idx"].ToString()) != 2)//App.Instance.Session.User.Index)//(수정)
                    {
                        labels[row, col].Text = "입력대기중";
                    }
                    else
                    {
                        labels[row, col].Visible = false;
                        createButton(row, col);
                    }                    
                }
            }
            else
            {
                labels[row, col].Text = string.Empty;
            }
        }


        public RecordView()
        {
            InitializeComponent();
            initializeLabel_ForRecord();
            initializeButton_InputDetail();
            initializePanel();
            setRecordTable();
            updateRecord(1);
            initializePage();
        }        
        void initializePage()
        {
            label_page.Text = "1 page";
            label_previous.Text = 1.ToString();
            label_next.Text = pageSize.ToString();
        }
        void initializeButton_InputDetail()
        {
            for(int i = 1; i <= 5; i++)
            {
                string buttonName = "button" + i;
                Button button = this.Controls.Find(buttonName, true).FirstOrDefault() as Button;
                if( button != null )
                {
                    button.Visible = true;
                    buttons.Add(button);
                }
            }
        }
        void initializeLabel_ForRecord()
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
        void initializePanel()
        {
            panels.Add(panel12);
            panels.Add(panel20);
            panels.Add(panel28);
            panels.Add(panel30);
            panels.Add(panel32);
        }
        


        //팀원인데 결과 없으면 label text 변경
        //팀장인데 결과 없으면 버튼생성
        //결과가 있으면 label text 승패(+-)
        private void createButton(int row, int col)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            Button btn = new Button();
            panels[row].Controls.Add(tableLayoutPanel);
            tableLayoutPanel.Name = "tableLayoutPanle" + row;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60f));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60f));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            tableLayoutPanel.Controls.Add(btn, 1, 1);
            btn.Name = "dynamicButton" + row;
            btn.Text = "결과입력";
            btn.Dock = DockStyle.Fill;
            CreatedControls.Add(tableLayoutPanel);
            CreatedControls.Add(btn);

            //btn.Click += new EventHandler(btn_Click);
            btn.Click += (sender, e) => { btn_Click(sender, e, row, col); }; //클로저
        }
        private void btn_Click(object sender, EventArgs e, int row, int col)
        {
            DataRow dr = dt.Rows[row * currentPage];
            int Party_idx = Convert.ToInt32(dr["idx"]);
            CalculateEloDTO dto = App.Instance.DB.LHJDB.getPartyAverageELO(Party_idx);
            int alterElo = dto.calculator();

            InsertResultPop pop = new InsertResultPop(Party_idx, alterElo);
            if (pop.ShowDialog() == DialogResult.OK) {
                this.setRecordTable();
                this.updateRecord(this.currentPage);
            }
        }
        private void ClearCreatedConrols()
        {
            foreach (var con in CreatedControls)
            {
                con.Dispose();
            }
            CreatedControls.Clear();
        }
        private void label_previous_Click(object sender, EventArgs e)
        {
            if(this.currentPage > 1)
            {
                this.currentPage -= 1;
                updateRecord(this.currentPage);
                label_page.Text = currentPage.ToString() + " page";
            }            
        }
        private void label_next_Click(object sender, EventArgs e)
        {
            if(this.currentPage < pageSize)
            {
                this.currentPage += 1;
                updateRecord(this.currentPage);
                label_page.Text = currentPage.ToString() + " page";
            }
        }

        private void label_page_Click(object sender, EventArgs e)
        {
            updateRecord(this.currentPage);
        }
    }
}
