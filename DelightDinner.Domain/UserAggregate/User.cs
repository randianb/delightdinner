using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.User.ValueObjects;

namespace DelightDinner.Domain.User;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; } // TODO: Hash password

    public DateTime CreateDateTime { get; private set; }
    public DateTime UpdateDateTime { get; private set; }

    private User(        
        string firstName,
        string lastName,
        string email,
        string password,
        UserId? userId = null) 
        : base(userId ?? UserId.CreateUnique()) 
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password) 
    {
        return new(
            firstName,
            lastName,
            email,
            password);
    }

#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618
}