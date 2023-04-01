using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.User.ValueObjects;

namespace DelightDinner.Domain.User;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password) 
        : base(userId) 
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
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password);
    }
}