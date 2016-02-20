namespace FitnessSystem.Web.Infrastructure.Mapping
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;

    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }

        public static TDestination ToModel<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
