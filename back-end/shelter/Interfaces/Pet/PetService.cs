using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using shelter.DataBaseContext.PetDbContext;
using shelter.Models.PetModels;
using System.Reflection.Metadata;
using System.Text;

namespace shelter.Interfaces.Pet
{
    public class PetService : IPetService
    {
        private readonly PetDbContext _petDbContext;
        private readonly IMapper _mapper;
        private  MemoryStream _imagesStream;
        public PetService
        (
            PetDbContext petDbContext,
            IMapper mapper

        )
        {
            _petDbContext = petDbContext;
            _mapper = mapper;
        }

        public async Task<bool> AddPetForm(PetForm pet)
        {
            try
            {
                var newPetModel = _mapper.Map<PetModel>(pet);
                _petDbContext.Pets.Add(newPetModel);
                await _petDbContext.SaveChangesAsync();

                string blob;
                foreach (var img in pet.Images)
                {
                    if (img.Length>0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            img.CopyTo( ms );
                            var fileBytes = ms.ToArray();
                            blob = Convert.ToBase64String( fileBytes );
                        }
                        var newPetImgs = new PetImg()
                        {
                            Images = Encoding.UTF8.GetBytes(blob),
                            PetModelId = newPetModel.Id
                        };
                        _petDbContext.PetImgs.Add(newPetImgs);
                        await _petDbContext.SaveChangesAsync();
                    }
                    
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
