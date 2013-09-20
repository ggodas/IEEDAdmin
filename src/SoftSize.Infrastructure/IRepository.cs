using System;
using System.Collections.Generic;
using LinqSpecs;

namespace SoftSize.Infrastructure
{
    //public interface IRepository<T, TId> : IEnumerable<T>, IQueryFactory where T : Entity<TId>, IAggregateRoot
    //{
    //    void Add(T item);
    //    bool Contains(T item);
    //    int Count { get; }
    //    bool Remove(T item);
    //    IEnumerable<T> FindAll(Specification<T> specification);
    //    T FindOne(Specification<T> specification);
    //}

    public interface IRepository<T> : IEnumerable<T>, IQueryFactory where T : Entity<Guid>, IAggregateRoot
    {
        void Add(T item);
        bool Contains(T item);
        int Count { get; }
        bool Remove(T item);
        IEnumerable<T> FindAll(Specification<T> specification);
        T FindOne(Specification<T> specification);
    }

    public interface IQuery
    {
    }


    public interface IQuery<TResult> : IQuery
    {
        TResult Execute();
    }

    public interface IQueryFactory
    {
        TQuery CreateQuery<TQuery>() where TQuery : IQuery;
    }
 }
