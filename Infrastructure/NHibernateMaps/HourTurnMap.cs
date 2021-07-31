using Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Infrastructure.NHibernateMaps
{
    public class HourTurnMap : IAutoMappingOverride<HourTurn>
    {
        public void Override(AutoMapping<HourTurn> mapping)
        {
            mapping.ReadOnly();
            mapping.Table("HOUR_TURNS_STATE_VIEW");
        }
    }
}
