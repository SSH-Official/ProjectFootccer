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
            this.panel_ViewSpace = new System.Windows.Forms.Panel();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_PositionPoptest = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_PartyJoin = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_PartyCreate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_PartySearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_MyPage = new System.Windows.Forms.Button();
            this.panel_Button1 = new System.Windows.Forms.Panel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.panel_Base.SuspendLayout();
            this.panel_Menu.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Button1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Controls.Add(this.panel_ViewSpace);
            this.panel_Base.Controls.Add(this.panel_Menu);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(800, 450);
            this.panel_Base.TabIndex = 0;
            // 
            // panel_ViewSpace
            // 
            this.panel_ViewSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ViewSpace.Location = new System.Drawing.Point(128, 0);
            this.panel_ViewSpace.Name = "panel_ViewSpace";
            this.panel_ViewSpace.Size = new System.Drawing.Size(672, 450);
            this.panel_ViewSpace.TabIndex = 1;
            // 
            // panel_Menu
            // 
            this.panel_Menu.Controls.Add(this.panel5);
            this.panel_Menu.Controls.Add(this.panel4);
            this.panel_Menu.Controls.Add(this.panel3);
            this.panel_Menu.Controls.Add(this.panel2);
            this.panel_Menu.Controls.Add(this.panel1);
            this.panel_Menu.Controls.Add(this.panel_Button1);
            this.panel_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Menu.Location = new System.Drawing.Point(0, 0);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(128, 450);
            this.panel_Menu.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_PositionPoptest);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 335);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(7);
            this.panel5.Size = new System.Drawing.Size(128, 67);
            this.panel5.TabIndex = 5;
            // 
            // btn_PositionPoptest
            // 
            this.btn_PositionPoptest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PositionPoptest.Location = new System.Drawing.Point(7, 7);
            this.btn_PositionPoptest.Name = "btn_PositionPoptest";
            this.btn_PositionPoptest.Size = new System.Drawing.Size(114, 53);
            this.btn_PositionPoptest.TabIndex = 1;
            this.btn_PositionPoptest.Text = "테스트 포지션 팝";
            this.btn_PositionPoptest.UseVisualStyleBackColor = true;
            this.btn_PositionPoptest.Click += new System.EventHandler(this.btn_PositionPoptest_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_PartyJoin);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 268);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(7);
            this.panel4.Size = new System.Drawing.Size(128, 67);
            this.panel4.TabIndex = 4;
            // 
            // btn_PartyJoin
            // 
            this.btn_PartyJoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PartyJoin.Location = new System.Drawing.Point(7, 7);
            this.btn_PartyJoin.Name = "btn_PartyJoin";
            this.btn_PartyJoin.Size = new System.Drawing.Size(114, 53);
            this.btn_PartyJoin.TabIndex = 1;
            this.btn_PartyJoin.Text = "파티 참가";
            this.btn_PartyJoin.UseVisualStyleBackColor = true;
            this.btn_PartyJoin.Click += new System.EventHandler(this.btn_PartyJoin_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_PartyCreate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 201);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(7);
            this.panel3.Size = new System.Drawing.Size(128, 67);
            this.panel3.TabIndex = 3;
            // 
            // btn_PartyCreate
            // 
            this.btn_PartyCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PartyCreate.Location = new System.Drawing.Point(7, 7);
            this.btn_PartyCreate.Name = "btn_PartyCreate";
            this.btn_PartyCreate.Size = new System.Drawing.Size(114, 53);
            this.btn_PartyCreate.TabIndex = 1;
            this.btn_PartyCreate.Text = "파티 생성";
            this.btn_PartyCreate.UseVisualStyleBackColor = true;
            this.btn_PartyCreate.Click += new System.EventHandler(this.btn_PartyCreate_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_PartySearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 134);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(7);
            this.panel2.Size = new System.Drawing.Size(128, 67);
            this.panel2.TabIndex = 2;
            // 
            // btn_PartySearch
            // 
            this.btn_PartySearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PartySearch.Location = new System.Drawing.Point(7, 7);
            this.btn_PartySearch.Name = "btn_PartySearch";
            this.btn_PartySearch.Size = new System.Drawing.Size(114, 53);
            this.btn_PartySearch.TabIndex = 1;
            this.btn_PartySearch.Text = "파티 검색";
            this.btn_PartySearch.UseVisualStyleBackColor = true;
            this.btn_PartySearch.Click += new System.EventHandler(this.btn_PartySearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_MyPage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(7);
            this.panel1.Size = new System.Drawing.Size(128, 67);
            this.panel1.TabIndex = 1;
            // 
            // btn_MyPage
            // 
            this.btn_MyPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_MyPage.Location = new System.Drawing.Point(7, 7);
            this.btn_MyPage.Name = "btn_MyPage";
            this.btn_MyPage.Size = new System.Drawing.Size(114, 53);
            this.btn_MyPage.TabIndex = 1;
            this.btn_MyPage.Text = "마이페이지";
            this.btn_MyPage.UseVisualStyleBackColor = true;
            this.btn_MyPage.Click += new System.EventHandler(this.btn_MyPage_Click);
            // 
            // panel_Button1
            // 
            this.panel_Button1.Controls.Add(this.btn_Login);
            this.panel_Button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Button1.Location = new System.Drawing.Point(0, 0);
            this.panel_Button1.Name = "panel_Button1";
            this.panel_Button1.Padding = new System.Windows.Forms.Padding(7);
            this.panel_Button1.Size = new System.Drawing.Size(128, 67);
            this.panel_Button1.TabIndex = 0;
            // 
            // btn_Login
            // 
            this.btn_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Login.Location = new System.Drawing.Point(7, 7);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(114, 53);
            this.btn_Login.TabIndex = 1;
            this.btn_Login.Text = "로그인";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_Base);
            this.Name = "MainForm";
            this.Text = "Footccer";
            this.panel_Base.ResumeLayout(false);
            this.panel_Menu.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_Button1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.Panel panel_ViewSpace;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Panel panel_Button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_PartyJoin;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_PartyCreate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_PartySearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_MyPage;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_PositionPoptest;
    }
}

