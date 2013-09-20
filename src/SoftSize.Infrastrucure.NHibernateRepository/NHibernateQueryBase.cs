using NHibernate;
using SoftSize.Infrastructure;

namespace SoftSize.Infrastrucure.NHibernateRepository
{
    public abstract class NHibernateQueryBase<TResult> : NHibernateBase, IQuery<TResult>
    {
        protected NHibernateQueryBase(ISessionFactory sessionFactory) : base(sessionFactory)
        {
            
        }
        public abstract TResult Execute();
    }
}
