using SharpArch.Domain.PersistenceSupport;
using System.Collections.Generic;

namespace Domain.RepositoryInterfaces
{
    public interface ICampRepository : IRepository<Camp>
    {
        IList<Camp> ListByBufferZone(double longitude, double latitude, float radius);

        IList<Camp> List(string userName);
    }
}
