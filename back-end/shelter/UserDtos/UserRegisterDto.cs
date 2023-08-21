﻿using shelter.Models.UserModels;

namespace shelter.UserDtos
{
    public class UserRegisterDto : UserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string PhoneNumber { get; set; }
    }
}