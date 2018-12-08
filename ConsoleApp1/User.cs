namespace SearchingSystem
{
    class User
    {
        public string Usename { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string usename, string email, string password)
        {
            Usename = usename;
            Email = email;
            Password = password;
        }
    }
}
