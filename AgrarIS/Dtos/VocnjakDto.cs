using AgrarIS.Models;

namespace AgrarIS.Dtos
{
    public class VocnjakDto
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public PoljoprivrednoDobroDto PoljoprivrednoDobro { get; set; }
    }

}
