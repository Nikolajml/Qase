namespace BusinessObject.Models
{
    public class UserBuilder
    {
        private User user;

        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetUsername(string username)
        {
            user.Username = username;
            return this;
        }

        public UserBuilder SetPassword(string password)
        {
            user.Password = password;
            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}
