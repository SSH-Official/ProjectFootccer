namespace FootccerClient
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Base = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel_ViewSpace = new System.Windows.Forms.Panel();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label_MyPage = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_Club = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_Config = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_FindParty = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_MyParty = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Base.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel_Menu.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Controls.Add(this.panel6);
            this.panel_Base.Controls.Add(this.panel5);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(971, 506);
            this.panel_Base.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel_ViewSpace);
            this.panel6.Controls.Add(this.panel_Menu);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 39);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(971, 467);
            this.panel6.TabIndex = 3;
            // 
            // panel_ViewSpace
            // 
            this.panel_ViewSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ViewSpace.Location = new System.Drawing.Point(121, 0);
            this.panel_ViewSpace.Name = "panel_ViewSpace";
            this.panel_ViewSpace.Size = new System.Drawing.Size(850, 467);
            this.panel_ViewSpace.TabIndex = 1;
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_Menu.Controls.Add(this.panel7);
            this.panel_Menu.Controls.Add(this.panel4);
            this.panel_Menu.Controls.Add(this.panel3);
            this.panel_Menu.Controls.Add(this.panel1);
            this.panel_Menu.Controls.Add(this.panel2);
            this.panel_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Menu.Location = new System.Drawing.Point(0, 0);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(121, 467);
            this.panel_Menu.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.label_MyPage);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 333);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(121, 67);
            this.panel7.TabIndex = 6;
            // 
            // label_MyPage
            // 
            this.label_MyPage.BackColor = System.Drawing.Color.Transparent;
            this.label_MyPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MyPage.Location = new System.Drawing.Point(0, 0);
            this.label_MyPage.Name = "label_MyPage";
            this.label_MyPage.Size = new System.Drawing.Size(121, 67);
            this.label_MyPage.TabIndex = 6;
            this.label_MyPage.Text = "마이페이지";
            this.label_MyPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_MyPage.Click += new System.EventHandler(this.label_MyPage_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.label_Club);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 134);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(121, 67);
            this.panel4.TabIndex = 5;
            // 
            // label_Club
            // 
            this.label_Club.BackColor = System.Drawing.Color.Transparent;
            this.label_Club.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Club.Location = new System.Drawing.Point(0, 0);
            this.label_Club.Name = "label_Club";
            this.label_Club.Size = new System.Drawing.Size(121, 67);
            this.label_Club.TabIndex = 6;
            this.label_Club.Text = "동아리";
            this.label_Club.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Club.Click += new System.EventHandler(this.label_Club_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.label_Config);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 400);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(121, 67);
            this.panel3.TabIndex = 4;
            // 
            // label_Config
            // 
            this.label_Config.BackColor = System.Drawing.Color.Transparent;
            this.label_Config.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Config.Location = new System.Drawing.Point(0, 0);
            this.label_Config.Name = "label_Config";
            this.label_Config.Size = new System.Drawing.Size(121, 67);
            this.label_Config.TabIndex = 6;
            this.label_Config.Text = "환경설정";
            this.label_Config.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Config.Click += new System.EventHandler(this.label_Config_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label_FindParty);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 67);
            this.panel1.TabIndex = 3;
            // 
            // label_FindParty
            // 
            this.label_FindParty.BackColor = System.Drawing.Color.Transparent;
            this.label_FindParty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_FindParty.Location = new System.Drawing.Point(0, 0);
            this.label_FindParty.Name = "label_FindParty";
            this.label_FindParty.Size = new System.Drawing.Size(121, 67);
            this.label_FindParty.TabIndex = 6;
            this.label_FindParty.Text = "파티찾기";
            this.label_FindParty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_FindParty.Click += new System.EventHandler(this.label_FindParty_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label_MyParty);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 67);
            this.panel2.TabIndex = 2;
            // 
            // label_MyParty
            // 
            this.label_MyParty.BackColor = System.Drawing.SystemColors.Control;
            this.label_MyParty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MyParty.Location = new System.Drawing.Point(0, 0);
            this.label_MyParty.Name = "label_MyParty";
            this.label_MyParty.Size = new System.Drawing.Size(121, 67);
            this.label_MyParty.TabIndex = 6;
            this.label_MyParty.Text = "내 파티";
            this.label_MyParty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_MyParty.Click += new System.EventHandler(this.label_MyParty_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_Logout);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(971, 39);
            this.panel5.TabIndex = 2;
            // 
            // btn_Logout
            // 
            this.btn_Logout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Logout.Location = new System.Drawing.Point(866, 0);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(105, 39);
            this.btn_Logout.TabIndex = 2;
            this.btn_Logout.Text = "로갓";
            this.btn_Logout.UseVisualStyleBackColor = true;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(971, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "메뉴스트립 자리(필요하면...)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 506);
            this.Controls.Add(this.panel_Base);
            this.Font = new System.Drawing.Font("HY견고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Footccer";
            this.panel_Base.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel_Menu.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel_ViewSpace;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label_MyPage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_Club;
        private System.Windows.Forms.Label label_Config;
        private System.Windows.Forms.Label label_FindParty;
        private System.Windows.Forms.Label label_MyParty;
    }
}

