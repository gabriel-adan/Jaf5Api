using SharpArch.Domain.PersistenceSupport;

namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User Exists(string email);

        UserCamp Exists(int userId, int accountId);
    }
}
