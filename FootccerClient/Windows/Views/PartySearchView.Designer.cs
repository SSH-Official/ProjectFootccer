namespace FootccerClient.Windows.Views
{
    partial class PartySearchView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.S_Date_P = new System.Windows.Forms.Panel();
            this.SearchDate = new System.Windows.Forms.DateTimePicker();
            this.S_Combo_P = new System.Windows.Forms.Panel();
            this.SearchCombo = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.S_Text_P = new System.Windows.Forms.Panel();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Search_kind = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.S_Date_P.SuspendLayout();
            this.S_Combo_P.SuspendLayout();
            this.panel4.SuspendLayout();
            this.S_Text_P.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1343, 690);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "파티검색";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 55);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1337, 632);
            this.panel5.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1337, 632);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.S_Date_P);
            this.panel1.Controls.Add(this.S_Combo_P);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.S_Text_P);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1337, 38);
            this.panel1.TabIndex = 0;
            // 
            // S_Date_P
            // 
            this.S_Date_P.Controls.Add(this.SearchDate);
            this.S_Date_P.Dock = System.Windows.Forms.DockStyle.Left;
            this.S_Date_P.Location = new System.Drawing.Point(716, 0);
            this.S_Date_P.Name = "S_Date_P";
            this.S_Date_P.Padding = new System.Windows.Forms.Padding(3);
            this.S_Date_P.Size = new System.Drawing.Size(303, 38);
            this.S_Date_P.TabIndex = 4;
            // 
            // SearchDate
            // 
            this.SearchDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchDate.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SearchDate.Location = new System.Drawing.Point(3, 3);
            this.SearchDate.Name = "SearchDate";
            this.SearchDate.Size = new System.Drawing.Size(297, 32);
            this.SearchDate.TabIndex = 0;
            // 
            // S_Combo_P
            // 
            this.S_Combo_P.Controls.Add(this.SearchCombo);
            this.S_Combo_P.Dock = System.Windows.Forms.DockStyle.Left;
            this.S_Combo_P.Location = new System.Drawing.Point(413, 0);
            this.S_Combo_P.Name = "S_Combo_P";
            this.S_Combo_P.Padding = new System.Windows.Forms.Padding(3);
            this.S_Combo_P.Size = new System.Drawing.Size(303, 38);
            this.S_Combo_P.TabIndex = 3;
            // 
            // SearchCombo
            // 
            this.SearchCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchCombo.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SearchCombo.FormattingEnabled = true;
            this.SearchCombo.Items.AddRange(new object[] {
            "제목",
            "작성자",
            "지역",
            "종류",
            "날짜"});
            this.SearchCombo.Location = new System.Drawing.Point(3, 3);
            this.SearchCombo.Name = "SearchCombo";
            this.SearchCombo.Size = new System.Drawing.Size(297, 29);
            this.SearchCombo.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SearchBtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1230, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(107, 38);
            this.panel4.TabIndex = 2;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(12, 5);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(82, 27);
            this.SearchBtn.TabIndex = 0;
            this.SearchBtn.Text = "검색";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // S_Text_P
            // 
            this.S_Text_P.Controls.Add(this.SearchText);
            this.S_Text_P.Dock = System.Windows.Forms.DockStyle.Left;
            this.S_Text_P.Location = new System.Drawing.Point(110, 0);
            this.S_Text_P.Name = "S_Text_P";
            this.S_Text_P.Padding = new System.Windows.Forms.Padding(3);
            this.S_Text_P.Size = new System.Drawing.Size(303, 38);
            this.S_Text_P.TabIndex = 1;
            this.S_Text_P.Visible = false;
            // 
            // SearchText
            // 
            this.SearchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchText.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SearchText.Location = new System.Drawing.Point(3, 3);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(297, 32);
            this.SearchText.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Search_kind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(110, 38);
            this.panel2.TabIndex = 0;
            // 
            // Search_kind
            // 
            this.Search_kind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Search_kind.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_kind.FormattingEnabled = true;
            this.Search_kind.Items.AddRange(new object[] {
            "제목",
            "작성자",
            "지역",
            "종류",
            "날짜"});
            this.Search_kind.Location = new System.Drawing.Point(5, 5);
            this.Search_kind.Name = "Search_kind";
            this.Search_kind.Size = new System.Drawing.Size(100, 29);
            this.Search_kind.TabIndex = 0;
            this.Search_kind.SelectedIndexChanged += new System.EventHandler(this.Search_kind_SelectedIndexChanged);
            // 
            // PartySearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 700);
            this.Controls.Add(this.groupBox1);
            this.Name = "PartySearchView";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "PartySearchView";
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.S_Date_P.ResumeLayout(false);
            this.S_Combo_P.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.S_Text_P.ResumeLayout(false);
            this.S_Text_P.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel S_Text_P;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox Search_kind;
        private System.Windows.Forms.Panel S_Combo_P;
        private System.Windows.Forms.ComboBox SearchCombo;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Panel S_Date_P;
        private System.Windows.Forms.DateTimePicker SearchDate;
        private System.Windows.Forms.Button SearchBtn;
    }
}