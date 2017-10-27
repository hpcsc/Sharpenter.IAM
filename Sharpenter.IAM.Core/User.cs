namespace Sharpenter.IAM.Core
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }

        public User(string username)
        {
            Username = username;
        }
        
        private User() {}
    }
}