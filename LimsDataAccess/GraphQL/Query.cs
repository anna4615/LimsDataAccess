using HotChocolate;
using HotChocolate.Data;
using LimsDataAccess.Data;
using LimsDataAccess.Models;
using System.Linq;

namespace LimsDataAccess.GraphQL
{
    public class Query
    {

        //Injektion av context görs med [Service] i metoden, se nedan
        //private readonly LimsContext _context;

        //public Query(LimsContext context)
        //{
        //    _context = context;
        //}


        //[service] tillgängligt via Hotchocolate, gör att context inte behöver injiceras från konstruktor utan direkt i metoden
        [UseDbContext(typeof(LimsContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Elisa> GetElisas([ScopedService] LimsContext context)
        {
            return context.Elisa;
        }

        [UseDbContext(typeof(LimsContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Sample> GetSamples([ScopedService] LimsContext context)
        {
            return context.Sample;
        }

        [UseDbContext(typeof(LimsContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Test> GetTests([ScopedService] LimsContext context)
        {
            return context.Test;
        }
    }
}
