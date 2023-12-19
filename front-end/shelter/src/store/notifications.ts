// const common = require("/common/common.js")
// import Vue from "vue"
import { defineStore } from "pinia";

export const useNotificationsStore = defineStore("notifications", {
    state: () => {
        return {
    notifications: [],
    nextId: 0,
        }
    },
actions: {
    notificationLook(type) {
        const types = [
          "notif",
          "success",
          "error",
          "pet",
          "downloadedFile",
          "downloadingFolder",
          "downloadedFolder",
          // "syncingFile",
          // "syncingFiles",
        ] //todo move to UI or common lib
        const colors = [
          "#ad6493",
          "#ad6493",
          "#c62727",
          "blue darken-1",
          "blue darken-1",
          "blue darken-3",
          "blue darken-3",
          // "blue darken-1",
          // "blue darken-3",
        ]
        const icons = [
          "mdi-bell-outline", //work in progress, dev
          "mdi-check-circle-outline",
          "mdi-alert-circle-outline",
          "mdi-download",
          "mdi-download",
          "mdi-briefcase-download",
          "mdi-briefcase-download",
          // "mdi-download",
          // "mdi-briefcase-download",
        ]
        let i = types.indexOf(type)
        let color = i > 0 ? colors[i] : colors[0]
        let icon = i > 0 ? icons[i] : icons[0]
        return { color, icon }
      },

      add( notification) {
        console.log(notification)
        //TODO: when there are many errors(messages) of the same type then edit the first one with a count
        let { color, icon } = this.notificationLook(notification.type)
        let timeout = 5000 //default
        if (("" + notification.type).startsWith("downloading")) {
          timeout = -1
        }
        
        let isSuccess = false

        if(notification.type == "success"){
            isSuccess = true
        }


        let newNotification = {
          ...notification,
          icon,
          id: this.nextId++,
          color,
          timeout,
          isSuccess
        }
    
        if (("" + notification.type).startsWith("downloaded")) {
          //get all notifications for this particular folder/file
    
          let foundNotifications = this.notifications.filter(
            (x) => x.fileActionId == notification.fileActionId
          )
          //now remove them from the notification list by their unique ids
          for (let i = 0; i < foundNotifications.length; i++) {
            let index = this.notifications.findIndex(
              (x) => x.id == foundNotifications[i].id
            )
            // Vue.set(this.notifications, index, newNotification) //refactored by vue3
            this.notifications[index] = newNotification
          }
        } else {
          this.notifications.push(newNotification)
        }
      },
      remove(id) {
        this.notifications = this.notifications.filter(
          (notification) => notification.id !== id
        )
      },
      updateNotificationList(notificationList) {
        this.notifications = notificationList
      },



},
getters: {
},
persist: true,
});


// const notification = {
//     type: "error",
//     message: `[${Date.now()}]err when save: ${err}`,
//   }

//   console.error(notification.message)
//   store.dispatch("notifications/add", notification, {
//     root: true,
//   })