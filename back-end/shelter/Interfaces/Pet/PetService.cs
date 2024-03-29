﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using shelter.DataBaseContext.ShelterPetFinderDbContext;
using shelter.Dtos.PetDto;
using shelter.Models.PetModels;
using System.Reflection.Metadata;
using System.Text;

namespace shelter.Interfaces.Pet
{
    public class PetService : IPetService
    {
        private readonly ShelterPetFinderDbContext _shelterPetFinderDbContext;
        private readonly IMapper _mapper;
        private  MemoryStream _imagesStream;
        public PetService
        (
            ShelterPetFinderDbContext shelterPetFinderDbContext,
            IMapper mapper
           

        )
        {
            _shelterPetFinderDbContext = shelterPetFinderDbContext;
            _mapper = mapper;
        }

        public async Task<bool> AddLikedPetList(LikedPetListModel likedPetListModel)
        {
            try
            {
                var userEmail = likedPetListModel.userEmail;
                var existingEmail = await _shelterPetFinderDbContext.PetLike.FirstOrDefaultAsync(e => e.userEmail == userEmail);

                var listOfLikedPets = likedPetListModel.likedPetIds.ToList();

                if (existingEmail != null)
                {
                    var existingLikedPets = _shelterPetFinderDbContext.PetLike
                        .Where(u=>u.userEmail == userEmail)
                        .ToList();
                    _shelterPetFinderDbContext.PetLike.RemoveRange(existingLikedPets);
                    await _shelterPetFinderDbContext.SaveChangesAsync();
                }


                foreach (var item in listOfLikedPets)
                {
                    var petLikeModel = new PetLikeModel
                    {
                        userEmail = userEmail,
                        PetId = item
                    };

                    _shelterPetFinderDbContext.PetLike.Add(petLikeModel);
                    await _shelterPetFinderDbContext.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public async Task<bool> AddPetForm(PetForm pet)
        {
            try
            {
                var newPetModel = _mapper.Map<PetModel>(pet);

                var shelterId = _shelterPetFinderDbContext.Shelters
                    .Where(shEmail=>shEmail.Email == pet.ShelterEmail)
                    .Select(shId => shId.Id)
                    .FirstOrDefault();

                newPetModel.ShelterModelId = shelterId;
                _shelterPetFinderDbContext.Pets.Add(newPetModel);
                await _shelterPetFinderDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeletePet(int id)
        {
            try
            {
                var petToDelete = await _shelterPetFinderDbContext.Pets.FindAsync(id);
                if (petToDelete == null)
                {
                    return false;
                }

                _shelterPetFinderDbContext.Pets.Remove(petToDelete);
                await _shelterPetFinderDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        public async Task<List<PetsBelongsToShelterDto>> GetAllCats()
        {
            try
            {
                var allCats = await _shelterPetFinderDbContext.Pets
                    .Include(p => p.Images)
                    .Include(s => s.ShelterModel)
                    .Where(s => s.Type == "Kot")
                    .ToListAsync();

                return _mapper.Map<List<PetsBelongsToShelterDto>>(allCats);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<PetsBelongsToShelterDto>> GetAllDogs()
        {
            try
            {
                var allDogs = await _shelterPetFinderDbContext.Pets
                    .Include(p => p.Images)
                    .Include(s => s.ShelterModel)
                    .Where(s => s.Type == "Pies")
                    .ToListAsync();

                return  _mapper.Map<List<PetsBelongsToShelterDto>>(allDogs);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<PetsBelongsToShelterDto>> GetAllOtherPets()
        {
            try
            {
                var allOthers = await _shelterPetFinderDbContext.Pets
                    .Include(p => p.Images)
                    .Include(s => s.ShelterModel)
                    .Where(s => s.Type == "Inne")
                    .ToListAsync();

                return _mapper.Map<List<PetsBelongsToShelterDto>>(allOthers);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<PetsBelongsToShelterDto>> GetAllPets()
        {
            try
            {
                var allPets = await _shelterPetFinderDbContext.Pets
                    .Include(p => p.Images)
                    .Include(s=>s.ShelterModel)
                    .ToListAsync();

                var petsToGet = _mapper.Map<List<PetsBelongsToShelterDto>>(allPets);

                return petsToGet;
            }
            catch (Exception ex) 
            {

                return null;
            }
            
        }

        public async Task<List<PetsBelongsToShelterDto>> GetAllRodents()
        {
            try
            {
                var allRodents = await _shelterPetFinderDbContext.Pets
                    .Include(p => p.Images)
                    .Include (s=>s.ShelterModel)
                    .Where(s=>s.Type=="Gryzoń")
                    .ToListAsync();

                return _mapper.Map<List<PetsBelongsToShelterDto>>(allRodents);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PetByIdDto> GetPetById(int id)
        {
            try
            {
                var pet = await _shelterPetFinderDbContext.Pets
                .Include(p => p.Images)
                .Include(s=>s.ShelterModel)
                .FirstOrDefaultAsync(p => p.Id == id);

                var petToGet = _mapper.Map<PetByIdDto>(pet);

                return petToGet;
            }
            catch (Exception ex)
            {

                return null;
            }
         
            
        }

        public async Task<bool> UpdatePet(PetForm pet)
        {
            try
            {
                var existingPet = await _shelterPetFinderDbContext.Pets
                    .Include (p => p.Images)
                    .Include(s=> s.ShelterModel)
                    .FirstOrDefaultAsync(p => p.Id == pet.Id);

                if (existingPet != null)
                {
                    _mapper.Map(pet, existingPet);

                    _shelterPetFinderDbContext.Entry(existingPet).State = EntityState.Modified;
                    await _shelterPetFinderDbContext.SaveChangesAsync();
                    return true;
                }
                else { return false; }
               
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
