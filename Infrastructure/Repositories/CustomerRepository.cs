using Domain;
using Domain.RepositoryInterfaces;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Domain.PersistenceSupport;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ISession session, ITransactionManager transactionManager) : base(session, transactionManager)
        {

        }

        public Customer Exists(string email)
        {
            try
            {
                return Session.CreateCriteria<Customer>().Add(Restrictions.Where<Customer>(p => p.Email == email)).UniqueResult<Customer>();
            }
            catch
            {
                throw;
            }
        }
    }
}
