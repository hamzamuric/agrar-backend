namespace AgrarIS.Dtos
{
    public class PesticidiDto
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<PoljoprivrednoDobroDto> PoljoprivrednoDobros { get; set; }
    }
}
