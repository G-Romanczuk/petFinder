using System.ComponentModel.DataAnnotations;

namespace shelter.Models.UserModels
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool terms { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string IncomeSource { get; set; }
        public string Lifestyle { get; set; }
        public int MaxHoursAway { get; set; }
        public int  WalksPerDay { get; set; }
        public int LongestWalkDurationMinutes { get; set; }
        public string DogWhereaboutsThroughoutDay { get; set; }
        public string DogLocationDuringOwnerAndOthersAbsence { get; set; }
        public bool CanProvideSubstituteCareDuringExtendedAbsence { get; set; }
        public string TimeWhenOwnedDog { get; set; }
        public string PastDogsHistory { get; set; }
        public string UserStoryLine { get; set; }

        public List<UserResidence> UserResidence { get; set; }




    }
}
