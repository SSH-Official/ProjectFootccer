using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Work_MyPage.DTO
{
    public class UserInfoDTO
    {
        public UserCredentialDTO User { get; }
        public string Gender { get; }
        public string Contact { get; }
        public string Email { get; }
        public PreferenceDTO Prefer { get; }
        public Image Image { get; }


        public UserInfoDTO(int idx, string id, string name, string gender, string contact, string email,
            int cityidx, string cityname, int activityidx, string activityname, Image image)
        {
            this.User = new UserCredentialDTO(idx, id, name);
            this.Gender = gender;
            this.Contact = contact;
            this.Email = email;
            this.Prefer = new PreferenceDTO(cityidx, cityname, activityidx, activityname);
            this.Image = image;
        }
        public UserInfoDTO(UserCredentialDTO user, string gender, string contact, string email, PreferenceDTO prefer, Image image)
        {
            User = user;
            Gender = gender;
            Contact = contact;
            Email = email;
            Prefer = prefer;
            Image = image;
        }

        public override string ToString()
        {
            return $"UserInformation : {{ {User}, {Gender}, {Contact}, {Email}, {Prefer}, {Image} }}";
        }
    }
}
