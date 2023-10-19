using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class FootccerExtensions
{
    /// <summary>
    /// "2023-09-09 오후 9:50:30"; 형태로 받아온다고 가정합니다.
    /// </summary>
    /// <param name="dateStr"></param>
    /// <param name="indicateYear"></param>
    /// <returns></returns>
    public static string ParseToString_FromDateString(this string dateStr, bool indicateYear)
    {
        string[] splits = dateStr.Split(' ');

        string strYYYYMMDD = splits[0];
        string[] dateParts = strYYYYMMDD.Split('-');
        int Year = int.Parse(dateParts[0]);
        int Month = int.Parse(dateParts[1]);
        int Day = int.Parse(dateParts[2]);

        string AMPM = splits[1]; //오전, 오후 두 값 중 하나입니다.

        string strHHMMSS = splits[2];
        string[] timeParts = strHHMMSS.Split(':');
        int Hour = int.Parse(timeParts[0]);
        int Minute = int.Parse(timeParts[1]);
        int Second = int.Parse(timeParts[2]);

        string result =
            (indicateYear ? $"{Year}-" : string.Empty) +
            $"{Month:D2}-{Day:D2} {AMPM} {Hour:D2}:{Minute:D2}";
        return result;
    }
    public static string ParseToString_FromDateTime(this DateTime dt, bool indicateYear)
    {
        string datePart =
            indicateYear ? $"{dt.Year}-" : string.Empty +
            $"{dt.Month}-{dt.Day}";

        string AMPM = (dt.Hour < 12) ? "오전" : "오후";

        int hour = dt.Hour % 12;
        hour += (hour == 0) ? 12 : 0;

        string timePart = $"{hour}:{dt.Minute}";

        string result = datePart + AMPM + timePart;
        return result;
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

        Bitmap cldimg = (Bitmap)child.BackgroundImage;
        Bitmap conimg = (Bitmap)control.BackgroundImage;
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
        control.BackgroundImageLayout = ImageLayout.Stretch;
        //return (Image)image.Clone();
    }
}

