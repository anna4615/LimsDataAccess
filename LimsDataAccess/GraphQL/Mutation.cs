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
                if (testInput.MeasuredValue.HasValue)
                    test.MeasureValue = testInput.MeasuredValue;
                if (string.IsNullOrEmpty(testInput.Status) == false)
                {
                    test.Status = testInput.Status;
                    if (testInput.Status == "Approved")
                    {
                        test.Sample.Concentration = testInput.Concentration;
                    }
                }
            }



            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ElisaExists(input.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                throw;
                //}
            }

            ElisaPayload payload = new ElisaPayload(elisa);

            return payload;
        }

        //private bool ElisaExists(int id, [ScopedService] LimsContext context)
        //{
        //    return context.Elisa.Any(e => e.Id == id);
        //}

    }
}
