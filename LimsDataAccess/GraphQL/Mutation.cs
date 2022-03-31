using HotChocolate;
using HotChocolate.Data;
using LimsDataAccess.Data;
using LimsDataAccess.GraphQL.Samples;
using LimsDataAccess.Models;
using System;
using System.Threading.Tasks;

namespace LimsDataAccess.GraphQL{

    public class Mutation
    {
        [UseDbContext(typeof(LimsContext))]
        public async Task<ElisaPayload> AddElisaAsync(
            [ScopedService] LimsContext context)
        {

            Elisa elisa = new Elisa
            {
                Status = "In Progress",
                DateAdded = DateTime.Now
            };

            context.Elisa.Add(elisa);
            await context.SaveChangesAsync();

            ElisaPayload elisaPayload = new ElisaPayload(elisa);

            return elisaPayload;
        }
    }
}
