import { defineStore } from "pinia";

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
  },
  getters: {
    getLoggedUser: (state) => {return state.loggedUser},
  },
  persist: true,
});
