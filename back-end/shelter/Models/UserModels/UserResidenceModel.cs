using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shelter.Models.UserModels
{
    public class UserResidenceModel
    {
        [Key]
        public int Id { get; set; }
        public int UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        public UserModel UserModel { get; set; }
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
