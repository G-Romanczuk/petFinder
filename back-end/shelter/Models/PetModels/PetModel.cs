namespace shelter.Models.PetModels
{
    public class PetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string sex { get; set; }
        public bool IsNeutered { get; set; }
        public string breed { get; set; }
        public string size { get; set; }
        public string age { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsChildFriendly { get; set; }
        public bool HasBasicCommandKnowledge { get; set; }
        public int ActivityLevel { get; set; }
        public bool IsDogFriendly { get; set; }
        public bool IsCatFriendly { get; set; }
        public bool IsItLikeAttention { get; set; }
        public string Temperament { get; set; }
        public string ShortDescription { get; set; }

    }
}
