using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace shelter.Models.ShelterModels
{
    public class ShelterPetDetailsModel
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        public int ShelterModelId { get; set; }
        [ForeignKey("ShelterModelId")]
        public ShelterModel ShelterModel { get; set; }
        public bool PetPlace { get; set; }
        public bool PetPlaceAlone { get; set; }
        public bool CareAlone { get; set; }
        public bool AnimalsBefore { get; set; }
        public bool AnimalsBeforeText { get; set; }
    }
}
