using LimsDataAccess.GraphQL.TestClasses;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LimsDataAccess.GraphQL.ElisaClasses
{
   
    public class ElisaInput
    {
        [JsonPropertyName("id")]
        public int  Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("testInputs")]
        public List<TestInput> TestInputs { get; set; }
    }
}
