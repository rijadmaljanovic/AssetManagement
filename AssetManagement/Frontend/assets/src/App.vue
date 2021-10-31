<template>
  <div id="app">
    <router-view/>
    <Noty/>
  </div>
</template>

<script>
import Vue from 'vue'
import Noty from './components/Noty.vue'
import MessageHub from './message-hub.js'

Vue.use(MessageHub);

export default {
  components:{
    Noty
  },
  mounted(){
    window.$messageHub.JoinGroup("user_" + localStorage.userId);
    window.$messageHub.$on('Message', (message) =>{
      let parsedData = JSON.parse(message.message);
      if (parsedData)
        this.$root.$emit('fireNotification', {type: parsedData.type, text: parsedData.message})
    })
  },
  beforeDestroy(){
    window.$messageHub.$off('Message')
  },
  watch: {
    $route(to, from){
      if (to.name !== 'login' && (!localStorage.userToken || Date.parse(localStorage.expirationToken) <= Date.now())){
        this.$router.push({name: 'login'});
      }
      else {
        this.$router.push(to).catch(err => {});
      }
    }
  }
}
</script>

<style>
* {
    box-sizing: border-box;
    margin: 0;
    border: 0;
}
</style>
