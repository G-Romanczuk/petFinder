using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace shelter.Models.ShelterModels
{
    public class ShelterResidenceModel
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        public int ShelterModelId { get; set; }
        [ForeignKey("ShelterModelId")]
        public ShelterModel ShelterModel { get; set; }
        public string HousingType { get; set; }
        public string HouseOwner { get; set; }
        public string Floor { get; set; }
        public string Elevator { get; set; }
        public string Fence { get; set; }
        public string FenceHeight { get; set; }
        public string PropertySize { get; set; }
        public string HouseMates { get; set; }
        public string Animals { get; set; }
    }
}
