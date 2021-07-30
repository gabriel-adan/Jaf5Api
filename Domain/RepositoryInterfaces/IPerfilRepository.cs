using SharpArch.Domain.PersistenceSupport;

namespace Domain.RepositoryInterfaces
{
    public interface IPerfilRepository : IRepository<Perfil>
    {
        Perfil Exists(string email);
    }
}
