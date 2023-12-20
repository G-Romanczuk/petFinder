import { defineStore } from "pinia";
import service from "@/services/service";

export const useShelterStore = defineStore("shelter", {
  state: () => {
    return {
      loggedShelterJWT: '',
      shelterData : {
      name: '',
      email: "",
      phone: "",
      postCode: "",
      town: "",
      adress: "",
      url: "",
      questions: {
        incomeSource: false,
        lifeStyle: false,
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
      }
      }

      
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
      const res = await  service.postShelterForm(data)
      console.log("store")
      return res
    },
    async getShelterData(email){
      const res = await service.getShelterData(email)

      this.shelterData.name = res.data.name
      this.shelterData.email = res.data.email
      this.shelterData.phone = res.data.phone
      this.shelterData.postCode = res.data.postCode
      this.shelterData.town = res.data.town
      this.shelterData.adress = res.data.adress
      this.shelterData.url = res.data.url
      this.shelterData.questions.incomeSource = res.data.questions.incomeSource
      this.shelterData.questions.lifeStyle = res.data.questions.lifeStyle
      this.shelterData.questions.housingType = res.data.questions.housingType
      this.shelterData.questions.houseOwner = res.data.questions.houseOwner
      this.shelterData.questions.hoursAlone = res.data.questions.hoursAlone
      this.shelterData.questions.floor = res.data.questions.floor
      this.shelterData.questions.elevator = res.data.questions.elevator
      this.shelterData.questions.walksNumber = res.data.questions.walksNumber
      this.shelterData.questions.walksTime = res.data.questions.walksTime
      this.shelterData.questions.fence = res.data.questions.fence
      this.shelterData.questions.fenceHeight = res.data.questions.fenceHeight
      this.shelterData.questions.propertySize = res.data.questions.propertySize
      this.shelterData.questions.petPlace = res.data.questions.petPlace
      this.shelterData.questions.petPlaceAlone = res.data.questions.petPlaceAlone
      this.shelterData.questions.careAlone = res.data.questions.careAlone
      this.shelterData.questions.houseMates = res.data.questions.houseMates
      this.shelterData.questions.animals = res.data.questions.animals
      this.shelterData.questions.animalsBefore = res.data.questions.animalsBefore
      this.shelterData.questions.animalsBeforeText = res.data.questions.animalsBeforeText
      this.shelterData.questions.text = res.data.questions.text








      return res
    }
  },
  getters: {
    getLoggedShelterJWT: (state) => {return state.loggedShelterJWT},
  },
  persist: true,
});
