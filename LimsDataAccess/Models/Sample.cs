using System.Collections.Generic;

namespace LimsDataAccess.Models
{
    public class Sample
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Concentration { get; set; }
        public List<Test> Tests { get; set; }

    }
}
