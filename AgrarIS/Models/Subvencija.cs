namespace AgrarIS.Models
{
    public class Subvencija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Odobrena { get; set; } = false;
    }
}
