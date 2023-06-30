using AgrarIS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgrarIS.Dtos
{
    public class VocnjakAddDto
    {
        public string Tip { get; set; }
        public int ParcelaId { get; set; }
    }
}
