import Vue from 'vue'
import App from './App.vue'
import ChatHub from './message-hub'

Vue.config.productionTip = false

Vue.use(ChatHub)

new Vue({
  render: h => h(App),
}).$mount('#app')
