namespace FootccerClient.Windows.Views.FootccerView
{
    partial class MenuView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            this.panel_Base = new System.Windows.Forms.Panel();
            this.panel_ViewSpace = new System.Windows.Forms.Panel();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.label_Title = new System.Windows.Forms.Label();
            this.panel_Profile = new System.Windows.Forms.Panel();
            this.button_MyPage = new System.Windows.Forms.Button();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.button_BackToMainMenu = new System.Windows.Forms.Button();
            this.panel_Base.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.panel_Profile.SuspendLayout();
            this.panel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Base.Controls.Add(this.panel_ViewSpace);
            this.panel_Base.Controls.Add(this.panel_Top);
            this.panel_Base.Controls.Add(this.panel_Bottom);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(1115, 712);
            this.panel_Base.TabIndex = 0;
            // 
            // panel_ViewSpace
            // 
            this.panel_ViewSpace.BackColor = System.Drawing.Color.Transparent;
            this.panel_ViewSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ViewSpace.Location = new System.Drawing.Point(0, 100);
            this.panel_ViewSpace.Name = "panel_ViewSpace";
            this.panel_ViewSpace.Size = new System.Drawing.Size(1115, 580);
            this.panel_ViewSpace.TabIndex = 2;
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.Cyan;
            this.panel_Top.Controls.Add(this.label_Title);
            this.panel_Top.Controls.Add(this.panel_Profile);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(1115, 100);
            this.panel_Top.TabIndex = 1;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("배달의민족 도현", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Title.Location = new System.Drawing.Point(3, 5);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(90, 29);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "메뉴 명";
            // 
            // panel_Profile
            // 
            this.panel_Profile.Controls.Add(this.button_MyPage);
            this.panel_Profile.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Profile.Location = new System.Drawing.Point(915, 0);
            this.panel_Profile.Name = "panel_Profile";
            this.panel_Profile.Padding = new System.Windows.Forms.Padding(5);
            this.panel_Profile.Size = new System.Drawing.Size(200, 100);
            this.panel_Profile.TabIndex = 0;
            // 
            // button_MyPage
            // 
            this.button_MyPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_MyPage.BackgroundImage")));
            this.button_MyPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_MyPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_MyPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MyPage.Location = new System.Drawing.Point(5, 5);
            this.button_MyPage.Name = "button_MyPage";
            this.button_MyPage.Size = new System.Drawing.Size(190, 90);
            this.button_MyPage.TabIndex = 1;
            this.button_MyPage.Text = "일론 머스크";
            this.button_MyPage.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button_MyPage.UseVisualStyleBackColor = true;
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.BackColor = System.Drawing.Color.Transparent;
            this.panel_Bottom.Controls.Add(this.button_BackToMainMenu);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 680);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Padding = new System.Windows.Forms.Padding(3);
            this.panel_Bottom.Size = new System.Drawing.Size(1115, 32);
            this.panel_Bottom.TabIndex = 0;
            // 
            // button_BackToMainMenu
            // 
            this.button_BackToMainMenu.BackColor = System.Drawing.Color.Silver;
            this.button_BackToMainMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_BackToMainMenu.FlatAppearance.BorderSize = 0;
            this.button_BackToMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_BackToMainMenu.Location = new System.Drawing.Point(1009, 3);
            this.button_BackToMainMenu.Name = "button_BackToMainMenu";
            this.button_BackToMainMenu.Size = new System.Drawing.Size(103, 26);
            this.button_BackToMainMenu.TabIndex = 0;
            this.button_BackToMainMenu.Text = "메인메뉴 (ESC)";
            this.button_BackToMainMenu.UseVisualStyleBackColor = false;
            this.button_BackToMainMenu.Click += new System.EventHandler(this.button_BackToMainMenu_Click);
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 712);
            this.Controls.Add(this.panel_Base);
            this.KeyPreview = true;
            this.Name = "MenuView";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuView_KeyDown);
            this.panel_Base.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            this.panel_Profile.ResumeLayout(false);
            this.panel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.Panel panel_ViewSpace;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.Button button_BackToMainMenu;
        private System.Windows.Forms.Panel panel_Profile;
        private System.Windows.Forms.Button button_MyPage;
        private System.Windows.Forms.Label label_Title;
    }
}