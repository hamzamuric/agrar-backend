namespace AgrarIS.Dtos
{
    public class UpdatePesticidiDto
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public PoljoprivrednoDobroDto PoljoprivrednoDobro { get; set; }
    }
}
