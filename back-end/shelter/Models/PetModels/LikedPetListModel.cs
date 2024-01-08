namespace shelter.Models.PetModels
{
    public class LikedPetListModel
    {
        public int userId { get; set; }
        public List<int> likedPetIds { get; set; }
    }
}
