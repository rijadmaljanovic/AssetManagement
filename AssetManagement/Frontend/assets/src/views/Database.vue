<template>
  <div class="database">
    <Header />
    <Sidebar />
    <TabController />
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import Sidebar from "@/components/Sidebar.vue";
import TabController from "@/components/TabController.vue"

export default {
  name: "database",
  components: {
    Header,
    Sidebar,
    TabController
  },
};
</script>