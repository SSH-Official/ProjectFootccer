using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO.Builder
{
    public class UserInfoDTOBuilder : DTOBuilder<UserInfoDTO>
    {
        private UserDTO User = null;
        private string Name = null;
        private string Gender = null;
        private string Contact = null;
        private string Email = null;
        private PreferenceDTO Prefer = null;
        private Image Image = null;


        public UserInfoDTO Build()
        {
            return new UserInfoDTO(User, Name, Gender, Contact, Email, Prefer, Image);
        }        

        public UserInfoDTOBuilder SetUser(UserDTO user)
        {
            this.User = user;
            return this;
        }

        public UserInfoDTOBuilder SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public UserInfoDTOBuilder SetGender(string gender)
        {
            this.Gender = gender;
            return this;
        }

        public UserInfoDTOBuilder SetContact(string contact)
        {
            this.Contact = contact;
            return this;
        }

        public UserInfoDTOBuilder SetEmail(string email)
        {
            this.Email = email;
            return this;
        }

        public UserInfoDTOBuilder SetPrefer(PreferenceDTO prefer)
        {
            this.Prefer = prefer;
            return this;
        }

        public UserInfoDTOBuilder SetImage(Image image)
        {
            this.Image = image;
            return this;
        }

        
    }
}
