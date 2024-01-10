<template>
    <div>
      
      <v-snackbar
        v-model="snackbar"
        right="true"
        :color="notification.color"
        :on-load="deleteAfterTimeout(notification.id, notification.timeout)"
        timeout="-1"
        :id="notification.id"
        :style="{ bottom: calcDistance(number) }"
       
        v-for="(notification, number) in notifications"
        location="bottom right"
      >
        <template v-slot:default>
          <v-dialog   v-model="notification.isSuccess" v-if=" notification.isSuccess " attach="v-snackbar" z-index="-1" >    <v-img   src="@/assets/fireworks.gif" style=" position: relative; top: -100px;" ></v-img></v-dialog>
            <div style="height: 100%; width: 100%; display: flex; " >
            <div style="height: fit-content; width: 70%; margin: auto 0; ">
              <v-icon v-if="notification.icon" style="padding-right: 10px;">{{ notification.icon }}</v-icon>
              {{ notification.message }}
            </div>
            
          <v-btn
            class="close-button"
            text
            :id="notification.id"
            @click="deleteNotification = notification.id"
            color="rgba(0,0,0,0.3)"
            right="0vh"
          >
            Close</v-btn
          >
        </div>

      
        </template>
      </v-snackbar>
    </div>
  </template>
  
  <script setup lang="ts">
  import { ref, computed, watch, reactive } from "vue"
  import {useNotificationsStore} from "@/store/notifications"

  const store = useNotificationsStore();






  const snackbar = ref(true)
  const notifications = computed({
      get: () => {
        return store.notifications
      },
      set: (value) =>
        store.updateNotificationList(value)
    })

    watch(store.notifications, (newValue, oldValue) => {
  
      snackbar.value = true
    })

    const deleteNotification = computed({
      get: () => {
        return id
      },
      set: (id) => {
        store.remove(id)
      },
    })

    function deleteAfterTimeout(id, timeout) {
      if (timeout != -1) {
        setTimeout(function del() {
          store.remove(id)
        }, timeout)
      }
    }

    function calcDistance(number) {
      return number * 67 + "px"
    }



  </script>
  
  <style lang="css" scoped>
  .close-button {
    float: right;
  }
  .my-snackbar {
    display: flexbox;
    max-height: 4vh;
  }


  </style>

  
  