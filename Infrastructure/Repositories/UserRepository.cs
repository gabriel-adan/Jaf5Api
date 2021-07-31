using Domain;
using Domain.RepositoryInterfaces;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Domain.PersistenceSupport;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ISession session, ITransactionManager transactionManager) : base(session, transactionManager)
        {

        }

        public User Exists(string email)
        {
            try
            {
                return Session.CreateCriteria<User>().Add(Restrictions.Where<User>(u => u.Email == email)).UniqueResult<User>();
            }
            catch
            {
                throw;
            }
        }

        public UserCamp Exists(int userId, int accountId)
        {
            try
            {
                return Session.CreateCriteria<UserCamp>().Add(Restrictions.Where<UserCamp>(uc => uc.User.Id == userId && uc.Account.Id == accountId)).UniqueResult<UserCamp>();
            }
            catch
            {
                throw;
            }
        }
    }
}
