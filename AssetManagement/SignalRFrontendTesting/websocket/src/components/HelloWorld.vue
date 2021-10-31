<template>
  <div class="hello">
    <Noty/>
    <h1>{{ msg }}</h1>
    <div class="form-wrapper">
        <div class="mb-3">
        <label class="text-uppercase form-label" for="name">Message</label>
        <input class="form-control" placeholder="Message" type="text" id="MessageInput" v-model="message">    
        </div>
    </div>
     <p>
    <button class="btn text-uppercase" id="sendButton" @click="sendDummyNotif()">Send message</button>
    </p>
    <div v-for="(k,index) in listMessage" :key="index">
      <p>{{k.name}} : {{k.message}}</p> 
    </div> 
  </div>
</template>

<script>
import Noty from './Noty.vue'
export default {
  name: 'HelloWorld',
  data(){
    return{
    message: '',
    listMessage: [],
    }
  },
  components:{
    Noty,
  },
  props: {
    msg: String
  },
  created(){
    window.$messageHub.JoinGroup("Group");
    // window.$messageHub.$on('Message', (message)=>{
    //   this.$root.$emit('fire-notification', {type: message.type, message: message.message})
    // })
  },
  mounted(){
    window.$messageHub.$on('Message', (message) =>{
      const insertData = message;
      this.listMessage.push(insertData)
      this.$root.$emit('fireNotification', {type: "success", text: message.message})
      console.log(this.listMessage);
    })
  },
  beforeDestroy(){
    window.$messageHub.$off('Message')
    // window.$messageHub.LeaveGroup("Group");
  },
  methods: {
    sendDummyNotif(){
      window.$messageHub.SendToGroup("Group",this.message);
    },
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
