using System;
using System.Collections.Generic;
using SharpArch.Domain.PersistenceSupport;

namespace Domain.RepositoryInterfaces
{
    public interface IHourRepository : IRepository<Hour>
    {
        IList<Hour> ToList(int campId);

        bool Exists(TimeSpan time, int dayOfWeek, int campId);
    }
}
