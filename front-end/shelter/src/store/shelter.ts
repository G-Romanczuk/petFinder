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
      return res
    },
  },
  getters: {
    getLoggedShelterJWT: (state) => {return state.loggedShelterJWT},
  },
  persist: true,
});
