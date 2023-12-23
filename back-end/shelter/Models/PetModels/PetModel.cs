using shelter.Models.ShelterModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shelter.Models.PetModels
{
    public class PetModel
    {
        [Key]
        public int Id { get; set; }
        public int ShelterModelId { get; set; }
        [ForeignKey("ShelterModelId")]
        public ShelterModel ShelterModel { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public string? Castration { get; set; }
        public string? Breed { get; set; }
        public string? Size { get; set; }
        public string? Age { get; set; }
        public string? Vaccination { get; set; }
        public string? ChildFriendly { get; set; }
        public string? BasicTraining { get; set; }
        public string? Activity { get; set; }
        public string? OtherDogs { get; set; }
        public string? OtherCats { get; set; }
        public string? Cuddly { get; set; }
        public string? Temper { get; set; }
        public string? Text { get; set; }
        public List<PetImg> Images { get; set; }

    }
   

}
