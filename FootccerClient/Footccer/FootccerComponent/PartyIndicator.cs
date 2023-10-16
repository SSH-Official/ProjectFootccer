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



namespace FootccerClient.Footccer.FootccerComponent
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
                return (date as string).ParseToString_FromDateString(indicateYear);
            }

            if (date.GetType() == typeof(DateTime))
            {   
                DateTime dt = (DateTime) date;
                return dt.ParseToString_FromDateTime(indicateYear);                
            }

            throw new Exception(
                $"정의되지 않은 타입의 date 변수입니다.\r\n" +
                $"입력된 date 변수의 타입 : {date.GetType()}");
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
