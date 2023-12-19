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
      lifeStyle: "",
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
    async getUserData(email){
      const res = await service.getUserData(email)

      this.userData.name = res.data.name
      this.userData.lname = res.data.lname
      this.userData.email = res.data.email
      this.userData.phone = res.data.phone
      this.userData.postCode = res.data.postCode
      this.userData.town = res.data.town
      this.userData.adress = res.data.adress
      this.userData.incomeSource = res.data.incomeSource
      this.userData.lifeStyle = res.data.lifeStyle
      this.userData.housingType = res.data.housingType
      this.userData.houseOwner = res.data.houseOwner
      this.userData.hoursAlone = res.data.hoursAlone
      this.userData.floor = res.data.floor
      this.userData.elevator = res.data.elevator
      this.userData.walksNumber = res.data.walksNumber
      this.userData.walksTime = res.data.walksTime
      this.userData.fence = res.data.fence
      this.userData.fenceHeight = res.data.fenceHeight
      this.userData.propertySize = res.data.propertySize
      this.userData.petPlace = res.data.petPlace
      this.userData.petPlaceAlone = res.data.petPlaceAlone
      this.userData.careAlone = res.data.careAlone
      this.userData.houseMates = res.data.houseMates
      this.userData.animals = res.data.animals
      this.userData.animalsBefore = res.data.animalsBefore
      this.userData.animalsBeforeText = res.data.animalsBeforeText
      this.userData.text = res.data.text



      console.log(this.userData)

      return res
    },
    postRegister(data) {
      service.postRegister(data)
    },
   async postUserForm(data) {
     const res = await service.postUserForm(data)
     console.log(res)
     return res
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
