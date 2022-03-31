using System;

namespace LimsDataAccess.Models
{
    public class Test
    {
        public int Id { get; set; }
        public int SampleId { get; set; }
        public int? ElisaId { get; set; }
        public int? ElisaPlatePosition { get; set; }
        public int? IhcId { get; set; }
        public string Status { get; set; }
        public Sample Sample { get; set; }
        public Elisa Elisa { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
