using FootccerClient.Footccer;
using FootccerClient.Windows.MyPage;
using Lib.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FootccerClient.Footccer.DTO;

namespace FootccerClient.Windows.Views
{
    
    public partial class MyPageView : MasterView
    {
        StatDTO Mypagestat;
        public MyPageView()
        {
            InitializeComponent();
            InitializeMyPageView_info();
        }

        private void InitializeMyPageView_info()
        {
            tbox_mygoal.Text = Convert.ToString(Mypagestat.score);
            tbox_myassi.Text = Convert.ToString(Mypagestat.assist);
            
        }

        private void btn_MyPage_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowPop<MyPagePop>();
        }
        
        private void panel_Base_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.DarkOliveGreen);
        }
        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.DarkOliveGreen);
        }
        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.Olive);
        }
        private void groupBox5_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.Olive);
        }

        private void groupBox6_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.Olive);
        }
        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                //g.Clear(this.BackColor);

                // Draw text
                //g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);
                box.Font = new Font("D2Coding", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                /*groupBox5.Font = new Font("D2Coding", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                groupBox6.Font = new Font("D2Coding", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));*/

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
                
            }
        }

        
    }
}
