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

        public List<UserResidenceModel> UserResidence { get; set; }
        public List<UsersDogDetailsModel> usersDogDetails { get; set; }
        public List<UserHabbitsModel> UserHabbits { get; set;}




    }
}
