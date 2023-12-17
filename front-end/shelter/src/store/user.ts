import { defineStore } from "pinia";
import service from "@/services/service";
export const useUserStore = defineStore("user", {
  state: () => {
    return {
      loggedUserJWT: "",
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
      }
      }

      
    };
  },
  actions: {
    login(email) {
      this.loggedUserJWT = email
    },
    logout() {
      this.loggedUserJWT = ''
    },
    postShelterLogin(data) {
      service.postShelterLogin(data)
    },
    async postUserLogin(data) {
      const res = await service.postUserLogin(data)

      return res
    },
    async getUserData(userToken){
      const res = await service.getUserData(userToken)

      console.log(res)

      return res
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
    getLoggedUserJWT: (state) => {return state.loggedUserJWT},
  },
  persist: true,
});
