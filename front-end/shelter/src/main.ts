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
const store = createPinia();

const app = createApp(App)

registerPlugins(app)

app.use(router)
app.use(store)
app.mount('#app')
