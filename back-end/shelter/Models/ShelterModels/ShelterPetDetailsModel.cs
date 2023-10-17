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
        public string PetPlace { get; set; }
        public string PetPlaceAlone { get; set; }
        public string CareAlone { get; set; }
        public string AnimalsBefore { get; set; }
        public string AnimalsBeforeText { get; set; }
    }
}
