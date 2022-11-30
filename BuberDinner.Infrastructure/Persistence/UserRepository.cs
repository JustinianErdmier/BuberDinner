using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new ();

    /// <inheritdoc />
    public void Add(User user)
    {
        Users.Add(user);
    }

    /// <inheritdoc />
    public User? GetUserByEmail(string email)
    {
        return Users.FirstOrDefault(u => u.Email.Equals(email));
    }
}
