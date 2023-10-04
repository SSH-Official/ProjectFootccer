namespace FootccerClient.Windows.Pops
{
    partial class ViewPop<T>
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
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(830, 486);
            this.panel_Base.TabIndex = 0;
            // 
            // ViewPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 486);
            this.Controls.Add(this.panel_Base);
            this.Name = "ViewPop";
            this.Text = "ViewPop";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
    }
}