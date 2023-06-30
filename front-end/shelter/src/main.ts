/**
 * main.ts
 *
 * Bootstraps Vuetify and other plugins then mounts the App`
 */

// Components
import App from './App.vue'

// Composables
import { createApp } from 'vue'

// Plugins
import { registerPlugins } from '@/plugins'

//router
import router from './router'

//store
import {createPinia} from 'pinia';
import piniaPluginPersistedState from "pinia-plugin-persistedstate"
const store = createPinia();
store.use(piniaPluginPersistedState);
const app = createApp(App)

registerPlugins(app)

app.use(router)
app.use(store)
app.mount('#app')
