using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class UserInfoDTO
    {
        public UserDTO User { get; }
        public string Name { get; }
        public string Gender { get; }
        public string Contact { get; }
        public string Email { get; }
        public PreferenceDTO Prefer { get; }
        public Image Image { get; }


        public UserInfoDTO(int idx, string id, string name, string gender, string contact, string email,
            int cityidx, string cityname, int activityidx, string activityname, Image image)
        {
            this.User = new UserDTO(idx, id);
            this.Name = name;
            this.Gender = gender;
            this.Contact = contact;
            this.Email = email;
            this.Prefer = new PreferenceDTO(cityidx, cityname, activityidx, activityname);
            this.Image = image;
        }
        public UserInfoDTO(UserDTO user,string name, string gender, string contact, string email, PreferenceDTO prefer, Image image)
        {
            this.User = user;
            this.Name = name;
            this.Gender = gender;
            this.Contact = contact;
            this.Email = email;
            this.Prefer = prefer;
            this.Image = image;
        }

        public override string ToString()
        {
            return $"UserInformation : {{ {User}, {Gender}, {Contact}, {Email}, {Prefer}, {Image} }}";
        }
    }
}
