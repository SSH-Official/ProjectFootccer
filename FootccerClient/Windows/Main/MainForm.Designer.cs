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
            this.panel_Base.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Base
            // 
            this.panel_Base.Controls.Add(this.panel6);
            this.panel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Base.Location = new System.Drawing.Point(0, 0);
            this.panel_Base.Name = "panel_Base";
            this.panel_Base.Size = new System.Drawing.Size(971, 506);
            this.panel_Base.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel_ViewSpace);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(971, 506);
            this.panel6.TabIndex = 3;
            // 
            // panel_ViewSpace
            // 
            this.panel_ViewSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ViewSpace.Location = new System.Drawing.Point(0, 0);
            this.panel_ViewSpace.Name = "panel_ViewSpace";
            this.panel_ViewSpace.Size = new System.Drawing.Size(971, 506);
            this.panel_ViewSpace.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 506);
            this.Controls.Add(this.panel_Base);
            this.Font = new System.Drawing.Font("HY견고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Footccer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panel_Base.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Base;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel_ViewSpace;
    }
}

