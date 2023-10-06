import { defineStore } from "pinia";
import service from "@/services/service";
export const useUserStore = defineStore("user", {
  state: () => {
    return {
      loggedUser: "",
      userData: {
        name: "",
      lname: "",
      email: "",
      phone: "",
      postCode: "",
      town: "",
      adress: "",
      incomeSource: "",
      lifestyle: "",
      housingType: "",
      houseOwner: "",
      hoursAlone: "",
      floor: "",
      elevator: "",
      walksNumber: "",
      walksTime: "",
      fence: "",
      fenceHeight: "",
      propertySize: "",
      petPlace: "",
      petPlaceAlone: "",
      careAlone: "",
      houseMates: "",
      animals: "",
      animalsBefore: "",
      animalsBeforeText: "",
      text: "",
      },
      loggedShelter: '',
      shelterData : {
      name: '',
      email: "",
      phone: "",
      postCode: "",
      town: "",
      adress: "",
      url: "",
      questions: {
        incomeSource: "",
        lifestyle: "",
        housingType: "",
        houseOwner: "",
        hoursAlone: "",
        floor: "",
        elevator: "",
        walksNumber: "",
        walksTime: "",
        fence: "",
        fenceHeight: "",
        propertySize: "",
        petPlace: "",
        petPlaceAlone: "",
        careAlone: "",
        houseMates: "",
        animals: "",
        animalsBefore: "",
        animalsBeforeText: "",
        text: "",
      }
      }

      
    };
  },
  actions: {
    login(email) {
      this.loggedUser = email
    },
    logout() {
      this.loggedUser = ''
    },
    postShelterLogin(data) {
      service.postShelterLogin(data)
    },
    postUserLogin(data) {
      service.postUserLogin(data)
    },
    postRegister(data) {
      service.postRegister(data)
    },
    postUserForm(data) {
      service.postUserForm(data)
    },
    postShelterForm(data) {
      service.postShelterForm(data)
    },
  },
  getters: {
    getLoggedUser: (state) => {return state.loggedUser},
  },
  persist: true,
});
