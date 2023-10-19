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
                SetFrameImage();
                SetDataImage();
                label_Information.Text = GetInfoText();
            }
        }

        PictureBox _PBox_DataImage { get; set; }
        PictureBox _PBox_Frame { get; set; }

        PictureBox PBox_DataImage 
        { 
            get => _PBox_DataImage; 
            set 
            {
                value.BackgroundImageLayout = ImageLayout.Center;
                value.SizeMode = PictureBoxSizeMode.StretchImage;
                value.Size = panel_Frame.Size;
                value.Location = new Point(0, 0);
                value.Visible = true;

                _PBox_DataImage = value;
                
                panel_Frame.Controls.Add(value);
            }
        }        
        PictureBox PBox_Frame 
        {
            get => _PBox_Frame;
            set
            {
                value.BackgroundImageLayout = ImageLayout.Center;
                value.SizeMode = PictureBoxSizeMode.StretchImage;
                value.Size = panel_Frame.Size;
                value.Location = new Point(0, 0);
                value.Visible = true;

                _PBox_Frame = value;
                panel_Frame.Controls.Add(value);
            }
        }

        public PartyIndicatorItem()
        {
            InitializeComponent();
            UpdateInfo(null);
            PBox_DataImage = new PictureBox();
            PBox_Frame = new PictureBox();
        }

        public void UpdateInfo(PartyDTO partyDTO) => Value = partyDTO;

        private string GetInfoText() => $"{Value.Actname.Substring(0, 2)}\r\n"
                                        + $"{Value.date.ParseToString_FromDateString(false)}\r\n"
                                        + $"{Value.PLname}\r\n"
                                        + $"{Value.Parname} ({Value.UserWithTag})";                
        

        private void SetFrameImage()
        {
            PBox_DataImage.Image = Resources.FootccerLogo;
            return;
            switch (Value.Actname.Substring(0,2))
            {
                case "축구":
                    PBox_Frame.Image = Resources.FootccerLogo;
                    PBox_Frame.Invalidate(); break;
                case "풋살":
                    PBox_Frame.Image = Resources.FootccerLogo;
                    PBox_Frame.Invalidate(); break;
                default:
                    PBox_Frame.Image = null; PBox_Frame.Invalidate(); break;
            }
        }

        private void SetDataImage()
        {
            PBox_DataImage.BackgroundImage = GetPadImage(Resources.Gradation01, PBox_DataImage.Size, 5);
            PBox_DataImage.Invalidate();
        }

        private Image GetPadImage(Bitmap originalImage, Size size, int pad) => GetPadImage(originalImage, size, new Padding(pad));
        private Image GetPadImage(Bitmap originalImage, Size size, Padding padding)
        {
            Bitmap resizedImage = new Bitmap(size.Width - padding.Horizontal, size.Height - padding.Vertical);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                // 그래픽스 개체를 사용하여 이미지를 리사이즈합니다.
                g.DrawImage(originalImage, 0, 0, resizedImage.Width, resizedImage.Height);
            }
            return resizedImage;
        }

        private void panel_Base_Resize(object sender, EventArgs e)
        {
            Padding padding = new Padding(5);
            PBox_DataImage.Parent = panel_Frame;
            PBox_DataImage.Size = new Size(panel_Frame.Width - padding.Horizontal, panel_Frame.Height - padding.Vertical);
            PBox_DataImage.Location = new Point(padding.Left, padding.Top);
            PBox_DataImage.ResizeImages();

            PBox_Frame.Parent = panel_Frame;
            PBox_Frame.Size = panel_Frame.Size;
            PBox_Frame.Location = new Point(0, 0);
            PBox_Frame.ResizeImages();
        }

        private void panel_Frame_SizeChanged(object sender, EventArgs e)
        {
            var con = (Control)sender;
            con.SetPaddingForFramed();
            con.DrawFramedImage(pictureBox_DataImage);
        }
    }

    public static class PictureBoxExtensions
    {
        public static void ResizeImages(this PictureBox pbox)
        {
            pbox.Image = pbox.GetPadImage(3, true);
            pbox.BackgroundImage = pbox.GetPadImage(3, false);
        }

        public static Image GetPadImage(this PictureBox pbox, int pad, bool isFront) => pbox.GetPadImage((isFront? pbox.Image : pbox.BackgroundImage), new Padding(pad));
        public static Image GetPadImage(this PictureBox pbox, Image originalImage, Padding padding)
        {
            if (originalImage == null) { return null; }
            var size = pbox.Size;
            Bitmap resizedImage = new Bitmap(size.Width - padding.Horizontal, size.Height - padding.Vertical);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                // 그래픽스 개체를 사용하여 이미지를 리사이즈합니다.
                g.DrawImage(originalImage, 0, 0, resizedImage.Width, resizedImage.Height);
            }
            return resizedImage;
        }
    }
}
