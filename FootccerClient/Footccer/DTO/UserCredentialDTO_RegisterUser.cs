namespace FootccerClient.Footccer.DAO
{
    public class UserCredentialDTO
    {
        public string ID { get; }
        public string Password { get; }

        public UserCredentialDTO(string iD, string password)
        {
            ID = iD;
            Password = password;
        }
    }
}