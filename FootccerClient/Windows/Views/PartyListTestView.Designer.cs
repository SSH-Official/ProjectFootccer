namespace FootccerClient.Windows.Views
{
    partial class PartyListTestView
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
            this.panel_MyPartyList = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_MyPartyList
            // 
            this.panel_MyPartyList.Location = new System.Drawing.Point(90, 54);
            this.panel_MyPartyList.Name = "panel_MyPartyList";
            this.panel_MyPartyList.Size = new System.Drawing.Size(523, 465);
            this.panel_MyPartyList.TabIndex = 0;
            // 
            // PartyListTestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 719);
            this.Controls.Add(this.panel_MyPartyList);
            this.Name = "PartyListTestView";
            this.Text = "PartyListTestView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_MyPartyList;
    }
}