namespace AgrarIS.Models
{
    public class PoljoprivrednoDobro
    {
        public int Id { get; set; }
        public DateTime DatumSadnice { get; set; }
        public string Naziv { get; set; }
        public string Sorta { get; set; }
        public int ZivotniVek { get; set; }
        public int VremeSazrevanja { get; set; }
        public double MinimalniPotencijalDavanja { get; set; }
        public double MaksimalniPotencijalDavanja { get; set; }
        public Vocnjak Vocnjak { get; set; }
        public int VocnjakId { get; set; }
        public List<Pesticid> Pesticidis { get; set; }
    }
}
