using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shelter.Models.UserModels
{
    public class UserResidence
    {
        [Key]
        public int Id { get; set; }
        public int UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        public UserModel UserModel { get; set; }
        public string TypeOfResidence { get; set; }
        public string OwnerOfResidence { get; set; }
        public int FloorNumber { get; set; }
        public bool IsElevator { get; set; }
        public int IsResidenceFenced { get; set; }
        public int FenceHeightInCentimeters { get; set; }
        public int YardOrGardenAreaInSquareMeters { get; set; }
        public string HouseholdResidents { get; set; }
        public string OtherAnimalsInResidence { get; set; }
    }
}
