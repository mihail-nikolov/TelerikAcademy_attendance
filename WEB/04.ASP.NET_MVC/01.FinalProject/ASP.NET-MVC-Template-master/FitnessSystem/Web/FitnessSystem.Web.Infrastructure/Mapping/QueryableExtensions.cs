namespace FitnessSystem.Web.Infrastructure.Mapping
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }

        public static TDestination ToModel<TDestination>(this object source)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            return Mapper.Map<TDestination>(source);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
