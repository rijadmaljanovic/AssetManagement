<template>
    <div class="test">
        <Header/>
        <Sidebar/>
        <ListAllProducts/>
    </div>
</template>

<script>
import Header from '@/components/Header.vue'
import Sidebar from '@/components/Sidebar.vue'
import ListAllProducts from '@/components/ListAllProducts.vue'
import Footer from '@/components/Footer.vue'

export default {
    name: 'Products',
    components: {
        Header,
        Sidebar,
        ListAllProducts,
        Footer,
    },
}
</script>