import { email } from "@vuelidate/validators";
import axios from "axios";
const baseURL = "https://localhost:7164";
import { useNotificationsStore } from "@/store/notifications";
export default {
  async postShelterLogin(data) {
    //data
    // {
    //     emailShelter : emailShelter.value,
    //     passwordShelter: passwordShelter.value
    //   }
    return await axios.post(baseURL + "/Shelter/Login", data).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async postUserLogin(data) {
    //data
    // {
    //     emailShelter : emailUser.value,
    //     passwordUser: passwordUser.value
    //   }
    return await axios.post(baseURL + "/User/Login", data).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async getUserData(data) {
    //data
    // {
    //     jwtToken - string
    //   }
    return await axios.get(baseURL + "/User/Get", { params: { email: data } }  ).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async getLikedPets(data) {

    return await axios.get(baseURL + "/User/LikedPets", { params: { userEmail: data } }  ).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async addLikedPets(data) {
    
    return await axios.post(baseURL + "/Pet/AddLikedPets", data).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async getShelterData(data) {
    //data
    // {
    //     jwtToken - string
    //   }
    return await axios.get(baseURL + "/Shelter/Get", { params: { email: data } }  ).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async getShelterPets(data) {
    return await axios.get(baseURL + "/Shelter/GetPets", { params: { shelterEmail: data } }  ).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async getShelterDogs(data) {
    return await axios.get(baseURL + "/Shelter/GetDogs", { params: { shelterEmail: data } }  ).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async getShelterCats(data) {
    return await axios.get(baseURL + "/Shelter/GetCats", { params: { shelterEmail: data } }  ).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async getShelterRodents(data) {
    //data
    // {
    //     jwtToken - string
    //   }
    return await axios.get(baseURL + "/Shelter/GetRodents", { params: { shelterEmail: data } }  ).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async getShelterOther(data) {
    //data
    // {
    //     jwtToken - string
    //   }
    return await axios.get(baseURL + "/Shelter/GetOthers", { params: { shelterEmail: data } }  ).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async getAllPets() {
    return await axios.get(baseURL + "/Pet/GetAllPets"  ).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async postRegister(data) {
    //data
    //  {
    //     name: nameValue.value,
    //     lname: lnameValue.value,
    //     email: emailValue.value,
    //     password: passwordValue.value,
    //     passwordConfirm: passwordConfirmValue.value,
    //     phone: phoneValue.value,
    //     terms:termsValue.value
    // }
    return await axios.post(baseURL + "/user/register", data).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async postUserForm(data) {
    //data
    //  {
    //   name: name.value,
    //   lname: lname.value,
    //   email: email.value,
    //   phone: phone.value,
    //   postCode: postCode.value,
    //   town: town.value,
    //   adress: adress.value,
    //   incomeSource: incomeSource.value,
    //   lifeStyle: lifeStyle.value,
    //   housingType: housingType.value,
    //   houseOwner: houseOwner.value,
    //   hoursAlone: hoursAlone.value,
    //   floor: floor.value,
    //   elevator: elevator.value,
    //   walksNumber: walksNumber.value,
    //   walksTime: walksTime.value,
    //   fence: fence.value,
    //   fenceHeight: fenceHeight.value,
    //   propertySize: propertySize.value,
    //   petPlace: petPlace.value,
    //   petPlaceAlone: petPlaceAlone.value,
    //   careAlone: careAlone.value,
    //   houseMates: houseMates.value,
    //   animals: animals.value,
    //   animalsBefore: animalsBefore.value,
    //   animalsBeforeText: animalsBeforeText.value,
    //   text: text.value
    // }
    return await axios.post(baseURL + "/User/DetailsForm", data).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async postShelterForm(data) {
    //data
    // {
    //     name: name.value,
    //     email: email.value,
    //     phone: phone.value,
    //     postCode: postCode.value,
    //     town: town.value,
    //     adress: adress.value,
    //     url: url.value,
    //     questions: {
    //         incomeSource: incomeSource.value,
    //         lifeStyle: lifeStyle.value,
    //         housingType: housingType.value,
    //         houseOwner: houseOwner.value,
    //         hoursAlone: hoursAlone.value,
    //         floor: floor.value,
    //         elevator: elevator.value,
    //         walksNumber: walksNumber.value,
    //         walksTime: walksTime.value,
    //         fence: fence.value,
    //         fenceHeight: fenceHeight.value,
    //         propertySize: propertySize.value,
    //         petPlace: petPlace.value,
    //         petPlaceAlone: petPlaceAlone.value,
    //         careAlone: careAlone.value,
    //         houseMates: houseMates.value,
    //         animals: animals.value,
    //         animalsBefore: animalsBefore.value,
    //         animalsBeforeText: animalsBeforeText.value,
    //         text: text.value
    //     }
    //   }
    return await axios.post(baseURL + "/Shelter/DetailsForm", data).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async resetShelterPasswordRequest(email) {
    return await axios.post(baseURL + "/Shelter/ResetShelterPasswordRequest", email).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async resetShelterPassword(data) {
    return await axios.post(baseURL + "/Shelter/ResetShelterPassword", data).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async resetUserPasswordRequest(email) {
    return await axios.post(baseURL + "/User/ResetPasswordRequest", email).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async resetUserPassword(data) {
    return await axios.post(baseURL + "/User/ResetPassword", data).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },


  async postPetForm(data) {
    return await axios.post(baseURL + "/Pet/Add", data, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    }).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async postPetFormUpdate(data) {
  
    return await axios.put(baseURL + "/Pet/Update", data, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    }).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
  async deletePet(id) {
console.log(id)
    return await axios.delete(baseURL + "/Pet/Delete", id).catch((error) => { 
      
      const notifStore = useNotificationsStore();
      const notification = {
      type: "error",
      message: error.message,
    }
    notifStore.add(notification)
  });
  },
};
