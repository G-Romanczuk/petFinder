import { defineStore } from "pinia";
import service from "@/services/service";
import { usePetStore } from "./pet";
import { useUserStore } from "./user";
export const useShelterStore = defineStore("shelter", {
  state: () => {
    return {
      loggedShelterJWT: '',
      shelterData: {
        name: '',
        email: "",
        phone: "",
        postCode: "",
        town: "",
        adress: "",
        url: "",
          incomeSource: false,
          lifestyle: false,
          housingType: false,
          houseOwner: false,
          hoursAlone: false,
          floor: false,
          elevator: false,
          walksNumber: false,
          walksTime: false,
          fence: false,
          fenceHeight: false,
          propertySize: false,
          petPlace: false,
          petPlaceAlone: false,
          careAlone: false,
          houseMates: false,
          animals: false,
          animalsBefore: false,
          animalsBeforeText: false,
          text: false,
        
        pets: [],
        likedpets: []
      },
      pet: {},
      passwordToken: '',
      users: [],
      count: 0,
    };
  },
  actions: {
    async postShelterLogin(data) {
      const res = await service.postShelterLogin(data)
      return res
    },
    async postUserLogin(data) {
      const res = await service.postUserLogin(data)

      return res
    },
    async postShelterForm(data) {
      const res = await service.postShelterForm(data)
      console.log("store")
      return res
    },
    async getShelterData(email) {
      const res = await service.getShelterData(email)

      this.shelterData.name = res.data.name
      //    this.shelterData.email = res.data.email
      this.shelterData.phone = res.data.phone
      this.shelterData.postCode = res.data.postCode
      this.shelterData.town = res.data.town
      this.shelterData.adress = res.data.adress
      this.shelterData.url = res.data.url
      this.shelterData.incomeSource = res.data.incomeSource
      this.shelterData.lifestyle = res.data.lifestyle
      this.shelterData.housingType = res.data.housingType
      this.shelterData.houseOwner = res.data.houseOwner
      this.shelterData.hoursAlone = res.data.hoursAlone
      this.shelterData.floor = res.data.floor
      this.shelterData.elevator = res.data.elevator
      this.shelterData.walksNumber = res.data.walksNumber
      this.shelterData.walksTime = res.data.walksTime
      this.shelterData.fence = res.data.fence
      this.shelterData.fenceHeight = res.data.fenceHeight
      this.shelterData.propertySize = res.data.propertySize
      this.shelterData.petPlace = res.data.petPlace
      this.shelterData.petPlaceAlone = res.data.petPlaceAlone
      this.shelterData.careAlone = res.data.careAlone
      this.shelterData.houseMates = res.data.houseMates
      this.shelterData.animals = res.data.animals
      this.shelterData.animalsBefore = res.data.animalsBefore
      this.shelterData.animalsBeforeText = res.data.animalsBeforeText
      this.shelterData.text = res.data.text

      console.log(this.shelterData)
      return res
    },
    async getShelterPets(shelterEmail) {
      var petStore = usePetStore();
      const res = await service.getShelterPets(shelterEmail)

      this.shelterData.pets = res.data
      petStore.pet = this.shelterData.pets[0]
      this.getPetLikes()
      return res
    },
    async getShelterDogs(shelterEmail) {
      const res = await service.getShelterDogs(shelterEmail)

      this.shelterData.pets = res.data

      return res
    },
    async getShelterCats(shelterEmail) {
      const res = await service.getShelterCats(shelterEmail)

      this.shelterData.pets = res.data

      return res
    },
    async getShelterRodents(shelterEmail) {
      const res = await service.getShelterRodents(shelterEmail)


      this.shelterData.pets = res.data

      return res
    },
    async getShelterOther(shelterEmail) {
      const res = await service.getShelterOther(shelterEmail)

      this.shelterData.pets = res.data

      return res
    },
    async getPetLikes() {
      for (var i = 0; i < this.shelterData.pets.length; i++) {

        const res = await service.whoLikedPet(this.shelterData.pets[i].id)
        if (res.data.length > 0) {
          this.pet = this.shelterData.pets[i]

this.users = []

          for (var j = 0; j < res.data.length; j++) {

            const userData = await service.getUserData(res.data[j])
            this.users.push(userData.data)
          }
          if (this.count < 1) {
            this.pet.likedBy = this.users
            this.shelterData.likedpets.push(this.pet)
            
          }
        }
      }


      this.count++;
      return this.shelterData.pets
    },

    async deletePet(id) {
      const res = await service.deletePet(id)

      if (res.status == 200) {
        this.getShelterPets(this.shelterData.email)
      }


      return res
    },
    async resetShelterPasswordRequest() {

      var email = { email: this.shelterData.email }

      const res = await service.resetShelterPasswordRequest(email)

      this.passwordToken = res.data
      console.log(this.passwordToken)
      return res
    },
    async resetShelterPassword(data) {

      const res = await service.resetShelterPassword(data)

      return res
    }
  },
  getters: {
    getLoggedShelterJWT: (state) => { return state.loggedShelterJWT },
  },
  persist: true,
});
