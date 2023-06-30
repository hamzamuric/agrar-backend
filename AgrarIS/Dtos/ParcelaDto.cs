using AgrarIS.Models;

namespace AgrarIS.Dtos
{
    public class ParcelaDto
    {
        public int Id { get; set; }
        public int BrojParcele { get; set; }
        public double Povrsina { get; set; }
        public List<VocnjakDto> Vocnjaks { get; set; }
    }
}
