namespace FootccerClient.Windows.Views
{
    partial class MyPageView
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
            this.panel_Base = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel_MyPageBase = new System.Windows.Forms.Panel();
            this.btn_MyPage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Base.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel_MyPageBase.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Controls.Add(this.groupBox1);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Padding = new System.Windows.Forms.Padding(5);
            this.panel_Base.Size = new System.Drawing.Size(1249, 719);
            this.panel_Base.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel_MyPageBase);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1239, 709);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "마이페이지";
            // 
            // panel_MyPageBase
            // 
            this.panel_MyPageBase.Controls.Add(this.panel1);
            this.panel_MyPageBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_MyPageBase.Location = new System.Drawing.Point(5, 19);
            this.panel_MyPageBase.Name = "panel_MyPageBase";
            this.panel_MyPageBase.Size = new System.Drawing.Size(1229, 685);
            this.panel_MyPageBase.TabIndex = 0;
            // 
            // btn_MyPage
            // 
            this.btn_MyPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_MyPage.Location = new System.Drawing.Point(1112, 0);
            this.btn_MyPage.Name = "btn_MyPage";
            this.btn_MyPage.Size = new System.Drawing.Size(117, 301);
            this.btn_MyPage.TabIndex = 0;
            this.btn_MyPage.Text = "내 정보 수정";
            this.btn_MyPage.UseVisualStyleBackColor = true;
            this.btn_MyPage.Click += new System.EventHandler(this.btn_MyPage_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_MyPage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1229, 301);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 301);
            this.label1.TabIndex = 0;
            this.label1.Text = "대충 내 정보 표시";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyPageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 719);
            this.Controls.Add(this.panel_Base);
            this.Name = "MyPageView";
            this.Text = "MyPageView";
            this.panel_Base.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel_MyPageBase.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel_MyPageBase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_MyPage;
    }
}