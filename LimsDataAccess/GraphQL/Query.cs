using HotChocolate;
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
        public IQueryable<Elisa> GetElisas([Service] LimsContext context)
        {
            return context.Elisa;
        }

        public IQueryable<Sample> GetSamples([Service] LimsContext context)
        {
            return context.Sample;
        }

        public IQueryable<Test> GetTests([Service] LimsContext context)
        {
            return context.Test;
        }
    }
}
