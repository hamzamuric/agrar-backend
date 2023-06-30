namespace AgrarIS.Models
{
    public class Pesticid
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<PoljoprivrednoDobro> PoljoprivrednoDobros { get; set; }
    }
}
