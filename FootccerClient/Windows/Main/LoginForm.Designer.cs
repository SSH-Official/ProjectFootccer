namespace FootccerClient 
{ 
    partial class LoginForm
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
            this.btn_Join = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_Find = new System.Windows.Forms.Button();
            this.btn_Login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbox_pwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_Base.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.BackColor = System.Drawing.Color.White;
            this.panel_Base.Controls.Add(this.btn_Join);
            this.panel_Base.Controls.Add(this.checkBox1);
            this.panel_Base.Controls.Add(this.btn_Find);
            this.panel_Base.Controls.Add(this.btn_Login);
            this.panel_Base.Controls.Add(this.label3);
            this.panel_Base.Controls.Add(this.label2);
            this.panel_Base.Controls.Add(this.tbox_pwd);
            this.panel_Base.Controls.Add(this.label1);
            this.panel_Base.Controls.Add(this.tbox_id);
            this.panel_Base.Controls.Add(this.label4);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(384, 461);
            this.panel_Base.TabIndex = 0;
            // 
            // btn_Join
            // 
            this.btn_Join.BackColor = System.Drawing.Color.White;
            this.btn_Join.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Join.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Join.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btn_Join.Location = new System.Drawing.Point(48, 390);
            this.btn_Join.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Join.Name = "btn_Join";
            this.btn_Join.Size = new System.Drawing.Size(285, 34);
            this.btn_Join.TabIndex = 24;
            this.btn_Join.Text = "Sign in";
            this.btn_Join.UseVisualStyleBackColor = false;
            this.btn_Join.Click += new System.EventHandler(this.btn_Join_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(48, 298);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 19);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Remember me";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_Find
            // 
            this.btn_Find.BackColor = System.Drawing.Color.White;
            this.btn_Find.FlatAppearance.BorderSize = 0;
            this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Find.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Find.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btn_Find.Location = new System.Drawing.Point(194, 298);
            this.btn_Find.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(139, 33);
            this.btn_Find.TabIndex = 22;
            this.btn_Find.Text = "Forgot Password?";
            this.btn_Find.UseVisualStyleBackColor = false;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btn_Login.FlatAppearance.BorderSize = 0;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Login.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Login.Location = new System.Drawing.Point(48, 344);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(285, 34);
            this.btn_Login.TabIndex = 21;
            this.btn_Login.Text = "Log in";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(46, 240);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(46, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "UserName";
            // 
            // tbox_pwd
            // 
            this.tbox_pwd.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbox_pwd.Location = new System.Drawing.Point(48, 262);
            this.tbox_pwd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbox_pwd.Name = "tbox_pwd";
            this.tbox_pwd.PasswordChar = '*';
            this.tbox_pwd.Size = new System.Drawing.Size(285, 30);
            this.tbox_pwd.TabIndex = 18;
            this.tbox_pwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_pwd_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("한컴 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(48, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 35);
            this.label1.TabIndex = 17;
            this.label1.Text = "Login to Your Account";
            // 
            // tbox_id
            // 
            this.tbox_id.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbox_id.Location = new System.Drawing.Point(48, 205);
            this.tbox_id.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbox_id.Name = "tbox_id";
            this.tbox_id.Size = new System.Drawing.Size(285, 30);
            this.tbox_id.TabIndex = 16;
            this.tbox_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_id_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Typewriter", 39.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 60);
            this.label4.TabIndex = 15;
            this.label4.Text = "FootCcer";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.panel_Base);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.panel_Base.ResumeLayout(false);
            this.panel_Base.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.Button btn_Join;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbox_pwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_id;
        private System.Windows.Forms.Label label4;
    }
}