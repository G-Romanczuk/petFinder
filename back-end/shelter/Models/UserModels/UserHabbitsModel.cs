using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace shelter.Models.UserModels
{
    public class UserHabbitsModel
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public int UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        public UserModel UserModel { get; set; }
        public string Lifestyle { get; set; }
        public int HoursAlone { get; set; }
        public int WalksNumber { get; set; }
        public int WalksTime { get; set; }
        public string Text { get; set; }
    }
}
