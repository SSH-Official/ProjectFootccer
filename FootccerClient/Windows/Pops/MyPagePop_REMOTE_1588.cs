using FootccerClient.Footccer;
using FootccerClient.Footccer.DTO;
using FootccerClient.Footccer.DTO.Builder;
using FootccerClient.Footccer.Util;
using FootccerClient.Windows.Pops;
using FootccerClient.Work_MyPage.Pops;
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

namespace FootccerClient.Windows.MyPage
{
    public partial class MyPagePop : MasterPop
    {
        UserInfoDTO userInfo;
        
        /// <summary>
        /// App.Instance.Session 정보로 유저 정보를 가져와 마이페이지 팝업을 생성합니다.
        /// 실패하면 오류를 발생시킵니다.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public MyPagePop()
        {
            userInfo = App.Instance.DB.MyPage.GetUserInfoAsSession();
            if (userInfo == null) 
            { 
                throw new Exception(
                    "UserInfo를 읽어오는 데에 실패했습니다.\r\n" +
                    "자세한 내용은 콘솔 로그를 확인해주세요."); 
            }
            InitializeComponent();
            InitailizeMyPagePop_AsUserInfo();
        }

       

        private void InitailizeMyPagePop_AsUserInfo()
        {
            tbox_Name.Text = userInfo.Name;
            tbox_Name.ReadOnly= true;
            tbox_Gender.Text = userInfo.Gender;
            tbox_Gender.ReadOnly= true;
            tbox_Contact.Text = userInfo.Contact;
            tbox_Contact.ReadOnly= true;    
            tbox_Email.Text = userInfo.Email;
            tbox_Email.ReadOnly= true;

            List<string> cityList = App.Instance.DB.CreateParty.getCityName();
            addComboBoxItems(cityList, cBox_City);

            List<string> actList = App.Instance.DB.CreateParty.getActivityName();
            addComboBoxItems(actList, cBox_activity);
            cBox_activity.SelectedIndex = userInfo.Prefer.Activity.Index -1;
            cBox_City.SelectedIndex = userInfo.Prefer.City.Index -1;

            
            panel_Image.BackgroundImage = userInfo.Image;
            panel_Image.BackgroundImageLayout = ImageLayout.Stretch;
            panel_Image.Tag = userInfo.Image.Tag;
        }

        private bool ValidateTest()
        {
            bool _result = true;
            string _msg = "";
            if (tbox_Contact.Text.Length <= 0)
            {
                if (_msg.Length == 0) { tbox_Contact.Focus(); }
                else { _msg += "\r\n"; }
                _msg += "전화번호를 입력해주세요.";
            }
            if (tbox_Email.Text.Length <= 0)
            {
                if (_msg.Length == 0) { tbox_Email.Focus(); }
                else { _msg += "\r\n"; }
                _msg += "이메일을 입력해주세요";
            }
            if (cBox_City.Text.Length <= 0)
            {
                if (_msg.Length == 0) { cBox_City.Focus(); }
                else { _msg += "\r\n"; }
                _msg += "선호지역을 선택해주세요";
            }
            if (cBox_activity.Text.Length <= 0)
            {
                if (_msg.Length == 0) { cBox_activity.Focus(); }
                else { _msg += "\r\n"; }
                _msg += "선호경기를 선택해주세요";
            }
            if (_msg.Length > 0)
            {
                _result = false;
                MessageBox.Show(_msg);
            }
            return _result;
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("변경사항을 저장하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ValidateTest())
                {   
                    //city,activity,-> prefer 객체 생성     userdto생성 
                    UserInfoDTO modifyuserinfo = new UserInfoDTOBuilder()
                                        .SetUser(userInfo.User)
                                        .SetName(tbox_Name.Text)
                                        .SetGender(tbox_Gender.Text)
                                        .SetContact(tbox_Contact.Text)
                                        .SetEmail(tbox_Email.Text)
                                        .SetPrefer(new PreferenceDTO(
                                            new CityDTO(cBox_City.SelectedIndex+1,cBox_City.Text),
                                            new ActivityDTO(cBox_activity.SelectedIndex+1,cBox_activity.Text)
                                            ))
                                        .Build();    
                    
                    bool result= App.Instance.DB.MyPage.UpdateUserinfo(modifyuserinfo);
                    if (result)
                    {
                        MessageBox.Show("성공");
                        cBox_activity.Enabled = false;
                        cBox_City.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("오류");
                    }
                }
            }
            else
            {
                MessageBox.Show("취소되었습니다.");
                InitailizeMyPagePop_AsUserInfo();
            }
        }

        private void btn_DeleteFile_Click(object sender, EventArgs e)
        {
            panel_Image.BackgroundImage = null;
            panel_Image.Tag = null;
        }

        private void button_TestFeature_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{panel_Image.Tag}");
        }

        private void btn_FindFile_Click(object sender, EventArgs e)
        {
            UrlRecieverPop pop = new UrlRecieverPop();
            if (pop.ShowDialog() == DialogResult.OK )
            {
                string url = pop.Value;
                panel_Image.BackgroundImage = App.Instance.Image.GetImageFromURL(url);
                panel_Image.Tag = url;
            }
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowPop<MyPage_ChangePasswordPop>();
        }
        
        private void btn_modi_Click(object sender, EventArgs e)
        {
            tbox_Email.ReadOnly = false;
            tbox_Contact.ReadOnly = false;
            cBox_activity.Enabled = true;
            cBox_City.Enabled = true;
            cBox_activity.Text = userInfo.Prefer.Activity.Name;
            cBox_City.Text = userInfo.Prefer.City.Name;


        }

        private void addComboBoxItems(List<string> list, ComboBox cBox)
        {
            for (int i = 0; i < list.Count; i++)
            {
                cBox.Items.Add(list[i]);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
