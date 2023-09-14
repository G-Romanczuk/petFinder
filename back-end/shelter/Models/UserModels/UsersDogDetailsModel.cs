using System.ComponentModel.DataAnnotations.Schema;

namespace shelter.Models.UserModels
{
    public class UsersDogDetailsModel
    {
        public int Id { get; set; }
        public int UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        public UserModel UserModel { get; set; }
        public string DogLocationThroughoutDay { get; set; }
        public string DogLocationDuringOwnerAndOthersAbsence { get; set; }
        public bool CanProvideSubstituteCareDuringExtendedAbsence { get; set; }
        public string TimeWhenOwnedDog { get; set; }
        public string PastDogsHistory { get; set; }
    }
}
