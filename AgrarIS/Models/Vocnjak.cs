using System.ComponentModel.DataAnnotations.Schema;

namespace AgrarIS.Models
{
    public class Vocnjak
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public int ParcelaId { get; set; }
        [ForeignKey("ParcelaId")]
        public Parcela Parcela { get; set; }
        public int PoljoprivrednoDobroId { get; set; }
        [ForeignKey("PoljoprivrednoDobroId")]
        public PoljoprivrednoDobro PoljoprivrednoDobro { get; set; }
    }
}
