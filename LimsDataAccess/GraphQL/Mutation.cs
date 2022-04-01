using HotChocolate;
using HotChocolate.Data;
using LimsDataAccess.Data;
using LimsDataAccess.GraphQL.ElisaClasses;
using LimsDataAccess.GraphQL.TestClasses;
using LimsDataAccess.Models;
using System;
using System.Threading.Tasks;

namespace LimsDataAccess.GraphQL
{

    public class Mutation
    {
        [UseDbContext(typeof(LimsContext))]
        public async Task<ElisaPayload> AddElisaAsync([ScopedService] LimsContext context)
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

        [UseDbContext(typeof(LimsContext))]
        public async Task<TestPayload> AddTest(TestInput input, [ScopedService] LimsContext context)
        {
            Test test = new Test
            {
                SampleId = input.SampleId,
                ElisaId = input.ElisaId,
                ElisaPlatePosition = input.ElisaPlatePosition,
                Status = "In Progress",
                DateAdded = DateTime.Now
            };

            context.Test.Add(test);
            await context.SaveChangesAsync();

            TestPayload payload = new TestPayload(test);

            return payload;
        }

        
        //private Test CreateTest(TestInput input)
        //{
        //    Test test = new Test();

        //    //TODO: felhantering om det inte går att parsa input-värden

        //    if (int.TryParse(input.SampleId, out int sampleId))
        //        test.SampleId = sampleId;
        //    if (int.TryParse(input.ElisaId, out int elisaId))
        //        test.ElisaId = elisaId;
        //    if (int.TryParse(input.ElisaPlatePosition, out int platePosition))
        //        test.ElisaPlatePosition = platePosition;

        //    return test;
        //}
    }
}
