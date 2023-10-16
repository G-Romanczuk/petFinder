using System.ComponentModel.DataAnnotations;

namespace shelter.Models.UserModels
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Terms { get; set; }
        public string PostalCode { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string IncomeSource { get; set; }

        public List<UserResidenceModel> UserResidence { get; set; }
        public List<UsersDogDetailsModel> usersDogDetails { get; set; }
        public List<UserHabbitsModel> UserHabbits { get; set;}




    }
}
