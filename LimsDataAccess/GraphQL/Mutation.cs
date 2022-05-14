using HotChocolate;
using HotChocolate.Data;
using LimsDataAccess.Data;
using LimsDataAccess.GraphQL.ElisaClasses;
using LimsDataAccess.GraphQL.TestClasses;
using LimsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
                DateAdded = DateTime.UtcNow
            };

            context.Elisa.Add(elisa);
            await context.SaveChangesAsync();

            ElisaPayload elisaPayload = new ElisaPayload(elisa);

            return elisaPayload;
        }


        [UseDbContext(typeof(LimsContext))]
        public async Task<TestPayload> AddTestAsync(TestInput input, [ScopedService] LimsContext context)
        {
            Test test = new Test
            {
                SampleId = (int)input.SampleId,
                ElisaId = (int)input.ElisaId,
                ElisaPlatePosition = (int)input.ElisaPlatePosition,
                Status = "In Progress",
                DateAdded = DateTime.UtcNow
            };

            context.Test.Add(test);
            await context.SaveChangesAsync();

            TestPayload payload = new TestPayload(test);

            return payload;
        }



        [UseDbContext(typeof(LimsContext))]
        public async Task<ElisaPayload> SaveElisaResultAsync(ElisaInput elisaInput, [ScopedService] LimsContext context)
        {
            Elisa elisa = context.Elisa.Include(e => e.Tests).ThenInclude(t => t.Sample).ToListAsync().Result
                            .FirstOrDefault(e => e.Id == elisaInput.Id);


            elisa.Status = elisaInput.Status;
            elisa.DateFinished = DateTime.UtcNow;

            context.Entry(elisa).State = EntityState.Modified;


            foreach (Test test in elisa.Tests)
            {
                TestInput testInput = elisaInput.TestInputs.FirstOrDefault(ti => ti.Id == test.Id);

                if (testInput.Concentration.HasValue)
                    test.Concentration = testInput.Concentration;

                if (testInput.MeasureValue.HasValue)
                    test.MeasureValue = testInput.MeasureValue;

                if (string.IsNullOrEmpty(testInput.Status) == false)
                {
                    test.Status = testInput.Status;
                    if (testInput.Status.ToLower() == "approved")
                    {
                        test.Sample.Concentration = testInput.Concentration;
                    }
                }
            }

            await context.SaveChangesAsync();

            ElisaPayload payload = new ElisaPayload(elisa);

            return payload;
        }


        //I nuläget har alltid alla Elisans tester samma status som Elisan. Om man i framtiden vill sätta olika status 
        //för tester i samma Elisa msåte man göra om den här metoden
        [UseDbContext(typeof(LimsContext))]
        public async Task<ElisaPayload> UpdateElisaStatus(int elisaId, string status, [ScopedService] LimsContext context)
        {
            Elisa elisa = context.Elisa.Include(e => e.Tests)
                                        .ThenInclude(t => t.Sample)
                                        .ToListAsync().Result
                                        .FirstOrDefault(e => e.Id == elisaId);

            context.Entry(elisa).State = EntityState.Modified;

            elisa.Status = status;

            foreach (Test test in elisa.Tests)
            {
                test.Status = status;

            }

            await context.SaveChangesAsync();

            ElisaPayload payload = new ElisaPayload(elisa);

            return payload;
        }
    }
}



