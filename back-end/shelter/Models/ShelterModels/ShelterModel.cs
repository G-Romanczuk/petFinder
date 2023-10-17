using System.ComponentModel.DataAnnotations;

namespace shelter.Models.ShelterModels
{
    public class ShelterModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailShelter { get; set; } 
        public string Phone { get; set; }
        public string PostCode { get; set; }
        public string Town { get; set; }
        public string Adress { get; set; }
        public string Url { get; set; }

        public List<ShelterResidenceModel> ShelterResidence { get; set; }
        public List<ShelterPetDetailsModel> ShelterPetDetails { get; set; }
        public List<ShelterHabbitsModel> ShelterHabbits { get; set; }

    }
}
