using Domain;
using Domain.RepositoryInterfaces;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Domain.PersistenceSupport;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class HourRepository : Repository<Hour>, IHourRepository
    {
        public HourRepository(ISession session, ITransactionManager transactionManager) : base(session, transactionManager)
        {

        }

        public bool Exists(TimeSpan time, int dayOfWeek, int campId)
        {
            try
            {
                return Session.CreateCriteria<Hour>().Add(Restrictions.Where<Hour>(h => h.Time == time && h.DayOfWeek == dayOfWeek && h.Camp.Id == campId)).UniqueResult() != null;
            }
            catch
            {
                throw;
            }
        }

        public IList<Hour> ToList(int campId)
        {
            try
            {
                return Session.CreateCriteria<Hour>().Add(Restrictions.Where<Hour>(h => h.Camp.Id == campId)).List<Hour>();
            }
            catch
            {
                throw;
            }
        }
    }
}
