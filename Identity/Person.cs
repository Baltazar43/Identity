namespace Identity.Properties;

public class User
{
    public string login { get; set; }
    public string password { get; set; }
    
    public Role role { get; set; }
    
    public Guid id { get; set; }

    public enum Role
    {
        Admin,
        User
    }
    
}

public class Register
{
    public string login { get; set; }
    public string password { get; set; }
}

public class Login
{
    public string login { get; set; }
    public string password { get; set; }
}

public class ChangeRole
{
    public Guid id { get; set; }
    public User.Role role { get; set; }
}


