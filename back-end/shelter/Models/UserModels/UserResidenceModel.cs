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
        public int Floor { get; set; }
        public bool IsElevator { get; set; }
        public int IsFence { get; set; }
        public int FenceHeight { get; set; }
        public int PropertySize { get; set; }
        public string HouseMates { get; set; }
        public string Animals { get; set; }
    }
}
