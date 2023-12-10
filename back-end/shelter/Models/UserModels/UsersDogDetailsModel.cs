using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace shelter.Models.UserModels
{
    public class UsersDogDetailsModel
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        public int UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        public UserModel UserModel { get; set; }
        public string PetPlace { get; set; }
        public string PetPlaceAlone { get; set; }
        public string CareAlone { get; set; }
        public string AnimalsBefore { get; set; }
        public string AnimalsBeforeText { get; set; }
    }
}
