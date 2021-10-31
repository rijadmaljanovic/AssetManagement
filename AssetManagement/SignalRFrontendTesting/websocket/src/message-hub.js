import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'
var URL = 'https://localhost:5001/chatHub'

export default {
  install (Vue) {
    console.log('Installing message hub plugin')
    var connection = new HubConnectionBuilder()
      .withUrl(URL,{skipnegotiation: true})
      .configureLogging(LogLevel.Information)
      .build();
 
      const ChatHub = new Vue ();

      connection.on('Message', (message) => {
        console.log('Connecting')
        
        ChatHub.$emit('sent_notification', { message })
        
      });

      connection.on('Message', (message) => {
        console.log('Connecting')
        
        ChatHub.$emit('Message', { message })
        
      });

      ChatHub.JoinGroup = (group) => {
        console.log("Joining group" + group);
        return startedPromise
        .then(() => connection.invoke('JoinGroup', group)) 
        .catch(console.error)
      }
      
      // ChatHub.LeaveGroup = (group) => {
      //   return startedPromise
      //   .then(() => connection.invoke('LeaveGroup', group)) 
      //   .catch(console.error)
      // }
      
      ChatHub.SendToGroup = (group, message) => {
        return startedPromise
        .then(() => connection.invoke("SendToGroup", group, message)) 
        .catch(console.error)
      }
      
    Vue.prototype.$messageHub = ChatHub
    window.$messageHub = ChatHub
    
    let startedPromise = null;
    function start() {
      startedPromise = connection.start()
      .catch(err => {
        console.error('Failed connection', err)
        return new Promise((resolve,reject) => setTimeout(() => start().then(resolve).catch(reject), 5000))
      })
      return startedPromise;
    }
    connection.onclose(() => start())

    start().then(function(){
      console.log('Connection established')
    })
  }
}

