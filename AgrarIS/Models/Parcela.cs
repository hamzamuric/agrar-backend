namespace AgrarIS.Models
{
    public class Parcela
    {
        public int Id { get; set; }
        public int BrojParcele { get; set; }
        public double Povrsina { get; set; }
        public int KorisnikId { get; set; }
        //public Korisnik? Korisnik { get; set; }
        public List<Vocnjak> Vocnjaks { get; set; }
    }
}
