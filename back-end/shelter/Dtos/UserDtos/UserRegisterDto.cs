using shelter.Models.UserModels;

namespace shelter.Dtos.UserDtos
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Phone { get; set; }
        public bool Terms { get; set; }
    }
}
