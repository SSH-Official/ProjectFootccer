namespace FootccerClient.Windows.Views.FootccerView
{
    partial class MainScreenView
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
            this.flowLayoutPanel_MenuButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.button_MyParty = new System.Windows.Forms.Button();
            this.button_FindParty = new System.Windows.Forms.Button();
            this.button_MyPage = new System.Windows.Forms.Button();
            this.button_Config = new System.Windows.Forms.Button();
            this.pictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.panel_Base.SuspendLayout();
            this.flowLayoutPanel_MenuButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.BackColor = System.Drawing.Color.Transparent;
            this.panel_Base.BackgroundImage = global::FootccerClient.Properties.Resources.MainScreen;
            this.panel_Base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Base.Controls.Add(this.pictureBox_Logo);
            this.panel_Base.Controls.Add(this.flowLayoutPanel_MenuButtons);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(1127, 719);
            this.panel_Base.TabIndex = 3;
            // 
            // flowLayoutPanel_MenuButtons
            // 
            this.flowLayoutPanel_MenuButtons.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel_MenuButtons.Controls.Add(this.button_MyParty);
            this.flowLayoutPanel_MenuButtons.Controls.Add(this.button_FindParty);
            this.flowLayoutPanel_MenuButtons.Controls.Add(this.button_MyPage);
            this.flowLayoutPanel_MenuButtons.Controls.Add(this.button_Config);
            this.flowLayoutPanel_MenuButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_MenuButtons.Location = new System.Drawing.Point(459, 386);
            this.flowLayoutPanel_MenuButtons.Name = "flowLayoutPanel_MenuButtons";
            this.flowLayoutPanel_MenuButtons.Size = new System.Drawing.Size(229, 333);
            this.flowLayoutPanel_MenuButtons.TabIndex = 1;
            // 
            // button_MyParty
            // 
            this.button_MyParty.BackColor = System.Drawing.Color.Transparent;
            this.button_MyParty.FlatAppearance.BorderSize = 0;
            this.button_MyParty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MyParty.Font = new System.Drawing.Font("굴림", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_MyParty.ForeColor = System.Drawing.Color.Orange;
            this.button_MyParty.Location = new System.Drawing.Point(3, 3);
            this.button_MyParty.Name = "button_MyParty";
            this.button_MyParty.Size = new System.Drawing.Size(215, 53);
            this.button_MyParty.TabIndex = 0;
            this.button_MyParty.Text = "내 파티";
            this.button_MyParty.UseVisualStyleBackColor = false;
            this.button_MyParty.Click += new System.EventHandler(this.button_MyParty_Click);
            // 
            // button_FindParty
            // 
            this.button_FindParty.BackColor = System.Drawing.Color.Transparent;
            this.button_FindParty.FlatAppearance.BorderSize = 0;
            this.button_FindParty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_FindParty.Font = new System.Drawing.Font("굴림", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_FindParty.ForeColor = System.Drawing.Color.Orange;
            this.button_FindParty.Location = new System.Drawing.Point(3, 62);
            this.button_FindParty.Name = "button_FindParty";
            this.button_FindParty.Size = new System.Drawing.Size(215, 53);
            this.button_FindParty.TabIndex = 1;
            this.button_FindParty.Text = "파티 찾기";
            this.button_FindParty.UseVisualStyleBackColor = false;
            this.button_FindParty.Click += new System.EventHandler(this.button_FindParty_Click);
            // 
            // button_MyPage
            // 
            this.button_MyPage.BackColor = System.Drawing.Color.Transparent;
            this.button_MyPage.FlatAppearance.BorderSize = 0;
            this.button_MyPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MyPage.Font = new System.Drawing.Font("굴림", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_MyPage.ForeColor = System.Drawing.Color.Orange;
            this.button_MyPage.Location = new System.Drawing.Point(3, 121);
            this.button_MyPage.Name = "button_MyPage";
            this.button_MyPage.Size = new System.Drawing.Size(215, 53);
            this.button_MyPage.TabIndex = 2;
            this.button_MyPage.Text = "마이페이지";
            this.button_MyPage.UseVisualStyleBackColor = false;
            this.button_MyPage.Click += new System.EventHandler(this.button_MyPage_Click);
            // 
            // button_Config
            // 
            this.button_Config.BackColor = System.Drawing.Color.Transparent;
            this.button_Config.FlatAppearance.BorderSize = 0;
            this.button_Config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Config.Font = new System.Drawing.Font("굴림", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Config.ForeColor = System.Drawing.Color.Orange;
            this.button_Config.Location = new System.Drawing.Point(3, 180);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(215, 53);
            this.button_Config.TabIndex = 3;
            this.button_Config.Text = "환경 설정";
            this.button_Config.UseVisualStyleBackColor = false;
            this.button_Config.Click += new System.EventHandler(this.button_Config_Click);
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Logo.BackgroundImage = global::FootccerClient.Properties.Resources.FootccerLogo;
            this.pictureBox_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Logo.Location = new System.Drawing.Point(324, 134);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.Size = new System.Drawing.Size(479, 164);
            this.pictureBox_Logo.TabIndex = 2;
            this.pictureBox_Logo.TabStop = false;
            // 
            // MainScreenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 719);
            this.Controls.Add(this.panel_Base);
            this.Name = "MainScreenView";
            this.Text = "MainScreenView";
            this.SizeChanged += new System.EventHandler(this.MainScreenView_SizeChanged);
            this.panel_Base.ResumeLayout(false);
            this.flowLayoutPanel_MenuButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_MenuButtons;
        private System.Windows.Forms.Button button_MyParty;
        private System.Windows.Forms.Button button_FindParty;
        private System.Windows.Forms.Button button_MyPage;
        private System.Windows.Forms.Button button_Config;
        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.PictureBox pictureBox_Logo;
    }
}