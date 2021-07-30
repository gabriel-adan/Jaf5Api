using SharpArch.Domain.PersistenceSupport;

namespace Domain.RepositoryInterfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Exists(string email);
    }
}
