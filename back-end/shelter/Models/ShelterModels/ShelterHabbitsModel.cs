using shelter.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace shelter.Models.ShelterModels
{
    public class ShelterHabbitsModel
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public int ShelterModelId { get; set; }
        [ForeignKey("ShelterModelId")]
        public ShelterModel ShelterModel { get; set; }
        public bool Lifestyle { get; set; }
        public bool HoursAlone { get; set; }
        public bool WalksNumber { get; set; }
        public bool WalksTime { get; set; }
        public bool Text { get; set; }
    }
}
