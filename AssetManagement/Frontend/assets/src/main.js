import Vue from 'vue'
import App from './App.vue'
import Vuelidate from 'vuelidate'
import router from './router'
import Chartkick from 'vue-chartkick'
import {Chart} from 'chart.js'
import {store} from "./store";
import {request} from './plugins/axios'
import ChatHub from './message-hub'
import 'leaflet/dist/leaflet.css';
import { Icon } from 'leaflet';

// import 'bootstrap/dist/css/bootstrap.min.css'
import Tabs from "vue-material-tabs";

Vue.use(Tabs);

Vue.use(Vuelidate)

Vue.use(ChatHub)

Vue.use(Chartkick.use(Chart))


delete Icon.Default.prototype._getIconUrl;
Icon.Default.mergeOptions({
  iconRetinaUrl: require('leaflet/dist/images/marker-icon-2x.png'),
  iconUrl: require('leaflet/dist/images/marker-icon.png'),
  shadowUrl: require('leaflet/dist/images/marker-shadow.png'),
});


Vue.config.productionTip = false

new Vue({
  router,
  store,
  request,
  render: h => h(App)
}).$mount('#app')
