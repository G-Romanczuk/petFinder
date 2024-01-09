namespace shelter.Models.PetModels
{
    public class LikedPetListModel
    {
        public string userEmail { get; set; }
        public List<int> likedPetIds { get; set; }
    }
}
