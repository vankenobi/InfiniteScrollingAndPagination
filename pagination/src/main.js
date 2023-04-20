import { createApp } from 'vue'
import App from './App.vue'

import PrimeVue from 'primevue/config';
import "primevue/resources/themes/lara-light-indigo/theme.css";     
import "primevue/resources/primevue.min.css";
import "primeicons/primeicons.css";

import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';


createApp(App)
.use(PrimeVue)
.mount('#app')
