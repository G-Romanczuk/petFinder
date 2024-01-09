using Microsoft.AspNetCore.SignalR;

namespace shelter.Models.PetModels
{
    public class PetLikeModel
    {
        public int Id { get; set; }
        public string userEmail { get; set; } 
        public int PetId { get; set; }
    }
}
