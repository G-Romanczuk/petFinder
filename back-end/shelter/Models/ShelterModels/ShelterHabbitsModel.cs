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
        public string Lifestyle { get; set; }
        public int HoursAlone { get; set; }
        public int WalksNumber { get; set; }
        public int WalksTime { get; set; }
        public string Text { get; set; }
    }
}
