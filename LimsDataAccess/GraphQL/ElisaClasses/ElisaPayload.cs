using LimsDataAccess.Models;

namespace LimsDataAccess.GraphQL.ElisaClasses
{
    public class ElisaPayload
    {
        public Elisa Elisa { get; set; }

        public ElisaPayload(Elisa elisa)
        {
            Elisa = elisa;
        }
    }
}
