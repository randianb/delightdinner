using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.User.ValueObjects;

namespace DelightDinner.Domain.User;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } // TODO: Hash password

    public DateTime CreateDateTime { get; }
    public DateTime UpdateDateTime { get; }

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
}