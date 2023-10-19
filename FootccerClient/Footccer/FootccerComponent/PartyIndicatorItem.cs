using FootccerClient.Footccer.DTO;
using FootccerClient.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.FootccerComponent
{
    public partial class PartyIndicatorItem : UserControl
    {
        private PartyDTO _value { get; set; }
        public PartyDTO Value 
        { 
            get=>_value; 
            set 
            { 
                _value = value;

                if (value == null) { this.Visible = false; return; }

                this.Visible = true;
                FrameImage = value.FrameImage();
                DataImage = value.DataImage();
                RedrawFramedImage();
                label_Information.Text = GetInfoText();
            }
        }

        Image FrameImage
        {
            get => panel_Frame.BackgroundImage;
            set => panel_Frame.BackgroundImage = value;
        }
        Image DataImage
        {
            get => pictureBox_DataImage.BackgroundImage;
            set
            {
                pictureBox_DataImage.BackgroundImage = value;
            }
        }

        public PartyIndicatorItem()
        {
            InitializeComponent();
            UpdateInfo(null);            
        }

        public void UpdateInfo(PartyDTO partyDTO) => Value = partyDTO;

        private string GetInfoText() => $"{Value.Actname.Substring(0, 2)}\r\n"
                                        + $"{Value.date.ParseToString_FromDateString(false)}\r\n"
                                        + $"{Value.PLname}\r\n"
                                        + $"{Value.Parname} ({Value.UserWithTag})";                
        
        private void RedrawFramedImage() => RedrawFramedImage(panel_Frame);
        private void RedrawFramedImage(Control con)
        {
            con.SetPaddingForFramed();
            con.DrawFramedImage(pictureBox_DataImage);
        }


        private void PartyIndicatorItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("!!!");
        }

        private void PartyIndicatorItem_SizeChanged(object sender, EventArgs e)
        {
            //RedrawFramedImage();
        }
    }

    static class PartyIndicatorItemExtensions
    {
        public static Image FrameImage(this PartyDTO party)
        {
            //TODO
            return Resources.Frame_Blue;
        }

        public static Image DataImage(this PartyDTO party)
        {
            //TODO
            return Resources.Gradation01;
        }

        public static void SetPaddingForFramed(this Control control)
        {
            int padbottom = 3;
            Point padUnit = new Point(70, 40);
            Size size = control.Size;
            int horPad = Math.Max(2, padbottom + (size.Width / padUnit.X));
            int verPad = Math.Max(2, padbottom + (size.Height / padUnit.Y));
            control.Padding = new Padding(horPad, verPad, (int)(horPad), (int)(verPad));
        }

        public static void DrawFramedImage(this Control control, Control child)
        {
            if (child == null
                || control == null
                || child.Parent != control
                || control.BackgroundImage == null
                || child.BackgroundImage == null) { return; }

            Image cldimg = child.BackgroundImage;
            Image conimg = control.BackgroundImage;
            Bitmap image = new Bitmap(control.Width, control.Height);

            using (Graphics g = Graphics.FromImage(image))
            {
                Padding pad = control.Padding;
                Point cldpoint = new Point(pad.Left, pad.Top);
                Size cldSize = new Size(control.Width - pad.Horizontal, control.Height - pad.Vertical);
                Point conPoint = control.Location;
                Size conSize = control.Size;

                g.DrawImage(cldimg, cldpoint.X, cldpoint.Y, cldSize.Width, cldSize.Height);
                g.DrawImage(conimg, 0, 0, conSize.Width, conSize.Height);
            }

            control.BackgroundImage = image;
            //return (Image)image.Clone();
        }
    }
}
