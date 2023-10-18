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
        public bool IncomeSource { get; set; }
        public bool HousingType { get; set; }
        public bool HouseOwner { get; set; }
        public bool Floor { get; set; }
        public bool Elevator { get; set; }
        public bool Fence { get; set; }
        public bool FenceHeight { get; set; }
        public bool PropertySize { get; set; }
        public bool HouseMates { get; set; }
        public bool Animals { get; set; }
    }
}
