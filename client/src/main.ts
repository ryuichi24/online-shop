import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
// import store from './store';
// scss
import './assets/scss/base.scss';

createApp(App).use(router).mount('#app');
