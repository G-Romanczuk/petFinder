﻿namespace shelter.Models.UserModels
{
    public class ResetPasswordModel
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set;}
    }
}
