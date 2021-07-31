using Domain;
using Domain.RepositoryInterfaces;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Domain.PersistenceSupport;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class FieldRepository : Repository<Field>, IFieldRepository
    {
        public FieldRepository(ISession session, ITransactionManager transactionManager) : base(session, transactionManager)
        {

        }

        public Field FindAvailable(DateTime date, Hour hour)
        {
            try
            {
                var query = Session.CreateSQLQuery("CALL SP_AVAILABLE_FIELD(:date, :hourId, :campId);").AddEntity(typeof(Field));
                query.SetDateTime("date", date);
                query.SetInt32("hourId", hour.Id);
                query.SetInt32("campId", hour.Camp.Id);
                return query.UniqueResult<Field>();
            }
            catch
            {
                throw;
            }
        }

        public Field Exists(string name, int campId)
        {
            try
            {
                return Session.CreateCriteria<Field>()
                    .Add(Restrictions.Where<Field>(f => f.Name == name && f.Camp.Id == campId)).UniqueResult<Field>();
            }
            catch
            {
                throw;
            }
        }

        public IList<Field> List(int campId)
        {
            try
            {
                return Session.CreateCriteria<Field>()
                    .Add(Restrictions.Where<Field>(f => f.Camp.Id == campId)).List<Field>();
            }
            catch
            {
                throw;
            }
        }

        public Field FindAvailableReserve(DateTime date, Hour hour)
        {
            try
            {
                var query = Session.CreateSQLQuery("CALL SP_AVAILABLE_FIELD_FOR_RESERVE(:date, :hourId, :campId);").AddEntity(typeof(Field));
                query.SetDateTime("date", date);
                query.SetInt32("hourId", hour.Id);
                query.SetInt32("campId", hour.Camp.Id);
                return query.UniqueResult<Field>();
            }
            catch
            {
                throw;
            }
        }
    }
}
