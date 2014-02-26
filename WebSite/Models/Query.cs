namespace WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class Query<T>
    {
        private readonly IList<Expression<Func<T, bool>>> filters = new List<Expression<Func<T, bool>>>();

        public IQueryable<T> GetList(IQueryable<T> source)
        {
            return this.filters.Aggregate(source, (queryable, func) => queryable.Where(func));
        }

        public T GetSingle(IQueryable<T> source)
        {
            return this.GetList(source).SingleOrDefault();
        }

        protected void AddFilter(Expression<Func<T, bool>> func)
        {
            filters.Add(func);
        }
    }
}