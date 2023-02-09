using BitMouse.LeadGenerator.Infrastructure.Domain;

namespace BitMouse.LeadGenerator.Model.Users;

public interface IUserRepository : IRepository<User>
{
    Task<DateTime?> GetDateCreatedByEmail(string email);
}
