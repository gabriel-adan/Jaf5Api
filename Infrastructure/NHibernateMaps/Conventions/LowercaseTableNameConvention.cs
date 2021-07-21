using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Infrastructure.NHibernateMaps.Conventions
{
    public class LowercaseTableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.TableName.ToLower());
        }
    }
}
