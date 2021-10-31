<template>
  <div class="assets">
    <Header />
    <Sidebar />
    <AssetsDatatable />
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import Sidebar from "@/components/Sidebar.vue";
import AssetsDatatable from "@/components/AssetsDatatable.vue";

export default {
  name: "assets",
  components: {
    Header,
    Sidebar,
    AssetsDatatable,
  },
};
</script>
