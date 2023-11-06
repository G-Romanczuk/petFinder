using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shelter.Models.PetModels
{
    public class PetImg
    {
        [Key]
        public int Id { get; set; }
        public byte[] Images { get; set; }
        public int PetModelId { get; set; }
        [ForeignKey("PetModelId")]
        public PetModel PetModel { get; set; }
    }
}
