namespace FootccerClient.Footccer.FootccerComponent
{
    partial class PartyIndicatorItem
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Base = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Information = new System.Windows.Forms.Label();
            this.panel_DataImage = new System.Windows.Forms.Panel();
            this.pictureBox_Frame = new System.Windows.Forms.PictureBox();
            this.panel_Base.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_DataImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Frame)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.BackColor = System.Drawing.Color.Transparent;
            this.panel_Base.Controls.Add(this.tableLayoutPanel1);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Padding = new System.Windows.Forms.Padding(3);
            this.panel_Base.Size = new System.Drawing.Size(663, 627);
            this.panel_Base.TabIndex = 0;
            this.panel_Base.Resize += new System.EventHandler(this.panel_Base_Resize);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label_Information, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_DataImage, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.19444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.80556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(657, 621);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_Information
            // 
            this.label_Information.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_Information.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Information.Location = new System.Drawing.Point(8, 400);
            this.label_Information.Margin = new System.Windows.Forms.Padding(8);
            this.label_Information.Name = "label_Information";
            this.label_Information.Size = new System.Drawing.Size(641, 213);
            this.label_Information.TabIndex = 0;
            this.label_Information.Text = "표시내용";
            this.label_Information.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_DataImage
            // 
            this.panel_DataImage.BackColor = System.Drawing.Color.Transparent;
            this.panel_DataImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_DataImage.Controls.Add(this.pictureBox_Frame);
            this.panel_DataImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DataImage.Location = new System.Drawing.Point(0, 0);
            this.panel_DataImage.Margin = new System.Windows.Forms.Padding(0);
            this.panel_DataImage.Name = "panel_DataImage";
            this.panel_DataImage.Size = new System.Drawing.Size(657, 392);
            this.panel_DataImage.TabIndex = 0;
            // 
            // pictureBox_Frame
            // 
            this.pictureBox_Frame.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Frame.BackgroundImage = global::FootccerClient.Properties.Resources.Gradation01;
            this.pictureBox_Frame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Frame.Image = global::FootccerClient.Properties.Resources.FootccerLogo;
            this.pictureBox_Frame.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Frame.Name = "pictureBox_Frame";
            this.pictureBox_Frame.Size = new System.Drawing.Size(657, 392);
            this.pictureBox_Frame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Frame.TabIndex = 23;
            this.pictureBox_Frame.TabStop = false;
            // 
            // PartyIndicatorItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Base);
            this.Name = "PartyIndicatorItem";
            this.Size = new System.Drawing.Size(663, 627);
            this.panel_Base.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_DataImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Frame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_Information;
        private System.Windows.Forms.Panel panel_DataImage;
        private System.Windows.Forms.PictureBox pictureBox_Frame;
    }
}
