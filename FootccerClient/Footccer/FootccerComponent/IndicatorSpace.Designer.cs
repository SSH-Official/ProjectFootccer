namespace FootccerClient.Footccer.FootccerComponent
{
    partial class IndicatorSpace
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel_Base = new System.Windows.Forms.FlowLayoutPanel();
            this.timer_Resize = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // flowLayoutPanel_Base
            // 
            this.flowLayoutPanel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_Base.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_Base.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel_Base.Name = "flowLayoutPanel_Base";
            this.flowLayoutPanel_Base.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel_Base.Size = new System.Drawing.Size(793, 248);
            this.flowLayoutPanel_Base.TabIndex = 0;
            // 
            // timer_Resize
            // 
            this.timer_Resize.Interval = 10;
            this.timer_Resize.Tick += new System.EventHandler(this.timer_Resize_Tick);
            // 
            // IncidatorSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel_Base);
            this.Name = "IncidatorSpace";
            this.Size = new System.Drawing.Size(793, 248);
            this.SizeChanged += new System.EventHandler(this.IncidatorSpace_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Base;
        private System.Windows.Forms.Timer timer_Resize;
    }
}
