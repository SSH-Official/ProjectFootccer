using FootccerClient.Footccer;
using FootccerClient.Footccer.DTO;
using Lib.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Windows.Views
{
    public partial class MyPage_activitySubView : MasterView
    {
        private bool isNew = true;
        public PersonalStatDTO psDTO { get; set; }
        public MyPage_activitySubView()
        {
            InitializeComponent();
            InitializeStatic();
            Getactstat();
        }
        private void Getactstat()
        {
            int useridx = App.Instance.Session.User.Index;
            psDTO = App.Instance.DB.personalstat.Getactstat(useridx);
            if (psDTO != null)
            {
                isNew = false;
                lb_avgdis.Text = psDTO.Avgdis.ToString();
                lb_maxdis.Text = psDTO.Maxdis.ToString();
                lb_avgpoint.Text = psDTO.Getavgpoint().ToString();
                lb_maxpoint.Text = psDTO.Getmaxpoint().ToString();
                lb_vicrecord.Text = psDTO.Getvictory().ToString("N2");
            }
        }
        private void InitializeStatic()
        {

        }
    }
}
