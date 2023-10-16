using System.ComponentModel.DataAnnotations.Schema;

namespace shelter.Models.UserModels
{
    public class UserHabbitsModel
    {
        public int Id { get; set; }
        public int UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        public UserModel UserModel { get; set; }
        public string Lifestyle { get; set; }
        public int MaxHoursAway { get; set; }
        public int WalksPerDay { get; set; }
        public int LongestWalkDurationMinutes { get; set; }
        public string UserStoryLine { get; set; }
    }
}
