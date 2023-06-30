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
   
  },
  getters: {
    userDataname: (state) => {return state.userData.name}
  },
  persist: true,
});
