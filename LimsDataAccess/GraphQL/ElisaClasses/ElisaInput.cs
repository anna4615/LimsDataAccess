using LimsDataAccess.GraphQL.TestClasses;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LimsDataAccess.GraphQL.ElisaClasses
{
   
    public class ElisaInput
    {
        public int  Id { get; set; }
        public string Status { get; set; }
        public List<TestInput> TestInputs { get; set; }
    }
}
