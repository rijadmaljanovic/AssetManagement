<template>
    <div class="test">
        <Header/>
        <Sidebar/>
        <ListAllVendors/>
    </div>
</template>

<script>
import Header from '@/components/Header.vue'
import Sidebar from '@/components/Sidebar.vue'
import ListAllVendors from '@/components/ListAllVendors.vue'
import Footer from '@/components/Footer.vue'

export default {
    name: 'Vendor',
    components: {
        Header,
        Sidebar,
        ListAllVendors,
        Footer,
    },
}
</script>