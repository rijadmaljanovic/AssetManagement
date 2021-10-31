<template>
    <div class="noty-wrapper"></div>
</template>

<script>
import Noty from 'noty'

export default {
    name: "Notification",
    props: ['type', 'text'],
    mounted() {
        this.$root.$on('fireNotification', (params) => {
            let settings = {};

            "type" in params ? settings.type = params.type : settings.type = "default-type"; 
            "text" in params ? settings.text = params.text : settings.text = "default text"; 
            "theme" in params ? settings.theme = params.theme : settings.theme = "bootstrap-v4"; 
            "timeout" in params ? settings.timeout = params.timeout : settings.timeout = 5000; 
            "progressBar" in params ? settings.progressBar = params.progressBar : settings.progressBar = true; 

            new Noty(settings).show();
        });
    },
    beforeDestroy() {
      //Remove event listeners
      this.$root.$off('fireNotification');
    },
}
</script>

<style lang="scss" >
    @import './node_modules/noty/src/noty.scss';
    @import './node_modules/noty/src/themes/bootstrap-v4.scss';  
</style>