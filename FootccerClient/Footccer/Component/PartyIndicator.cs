using FootccerClient.Footccer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.Component
{
    public partial class PartyIndicator : UserControl
    {
        public PartyIndicator()
        {
            InitializeComponent();
        }

        public void InitializeValues(PartyDTO party, bool indicateYear)
        {
            if (party == null)
            {
                return;
            }

            label_Date.Text = ParseDateString(party.date, indicateYear);
            label_Activity.Text = GetActivityNameText(party.Actname);
            label_PartyName.Text = party.Parname;
            label_PartyLeaderName.Text = party.UserWithTag;
            label_HeadCount.Text = $"{party.count}/{party.max}";
        }
        private string ParseDateString(object date, bool indicateYear)
        {
            if (date.GetType() == typeof(string))
            {
                return ParseToString_FromDateString(date as string, indicateYear);
            }

            if (date.GetType() == typeof(DateTime))
            {   
                DateTime dt = (DateTime) date;
                return ParseToString_FromDateTime(dt, indicateYear);                
            }

            throw new Exception(
                $"정의되지 않은 타입의 date 변수입니다.\r\n" +
                $"입력된 date 변수의 타입 : {date.GetType()}");
        }
        private string ParseToString_FromDateString(string dateStr, bool indicateYear)
        {
            //"2023-09-09 오후 9:50:30"; 형태로 받아온다고 가정합니다.
            string[] splits = dateStr.Split(' ');
            
            string strYYYYMMDD = splits[0];            
            string[] dateParts =  strYYYYMMDD.Split('-');
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
                (indicateYear? $"{Year}년 " : string.Empty) + 
                $"{Month}월 {Day}일 {AMPM} {Hour}시 {Minute}분";
            return result;
        }
        private string ParseToString_FromDateTime(DateTime dt, bool indicateYear)
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
        private string GetActivityNameText(string actname)
        {
            string[] strArr = actname.Split('_');
            switch (strArr[0])
            {
                case "축구":
                    return $"{actname}({11}:{11})";
                case "풋살":
                    return $"{actname}({5}:{5})";
                default:
                    return actname;
            }
        }

        public PartyIndicator(int height, Control parent, PartyDTO party = null, bool isSessionUserLeader = false, bool indicateYear = false)
        {
            InitializeComponent();
            InitializeValues(party, indicateYear);

            pictureBox_PartyLeader.Visible = isSessionUserLeader;

            this.Dock = DockStyle.Top;
            this.Height = height;

            this.Parent = parent;
            parent.Controls.Add(this);
            this.BringToFront();
        }

        
    }
}
