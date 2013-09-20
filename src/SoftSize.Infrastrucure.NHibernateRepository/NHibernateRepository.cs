using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LinqSpecs;
using NHibernate;
using NHibernate.Linq;
using SoftSize.Infrastructure;

namespace SoftSize.Infrastrucure.NHibernateRepository
{
    public class NHibernateRepository<T> : NHibernateBase, IRepository<T> where T : Entity<Guid>, IAggregateRoot
    {
        private readonly IQueryFactory queryFactory;

        public NHibernateRepository(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {

        }

        public void Add(T item)
        {
            Transact(() => session.Save(item));
        }

        public bool Contains(T item)
        {
            var id = default(Guid);
            if (item.Id.Equals(id))
                return false;
            return Transact(() => session.Get<T>(item.Id)) != null;
        }

        public int Count
        {
            get
            {
                return Transact(() => session.Query<T>().Count());
            }
        }

        public bool Remove(T item)
        {
            Transact(() => session.Delete(item));
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Transact(() => session.Query<T>()
                .Take(1000).GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Transact(() => GetEnumerator());
        }

        public TQuery CreateQuery<TQuery>() where TQuery : SoftSize.Infrastructure.IQuery
        {
            return queryFactory.CreateQuery<TQuery>();
        }

        public IEnumerable<T> FindAll(Specification<T> specification)
        {
            var query = GetQuery(specification);
            return Transact(() => query.ToList());
        }

        public T FindOne(Specification<T> specification)
        {
            var query = GetQuery(specification);
            return Transact(() => query.SingleOrDefault());
        }

        private IQueryable<T> GetQuery(Specification<T> specification)
        {
            return session.Query<T>()
            .Where(specification.IsSatisfiedBy());
        }
    }


    //public class NHibernateRepository<T> : NHibernateRepository<T, Guid> where T : Entity, IAggregateRoot
    //{
    //    public NHibernateRepository(ISessionFactory sessionFactory)
    //        : base(sessionFactory)
    //    {
    //    }
    //}
}
