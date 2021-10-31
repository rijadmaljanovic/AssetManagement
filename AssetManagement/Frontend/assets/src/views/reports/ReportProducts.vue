<template>
    <div class="assets">
        <Header/>
        <Sidebar/>
    <div class="px-lg-4 px-xl-5 container-fluid">
    <div class="page-header d-flex justify-content-between align-items-center">
        <div>
            <h1 class="page-heading">Products Report</h1>
        </div>

        <button class="btn btn-primary text-uppercase" @click="downloadPdf()">
                <i class="fas fa-download"></i>
                Download 
        </button>

    </div>
    <RProducts/>

    </div>
    </div>
</template>

<script>
import Header from '@/components/Header.vue'
import Sidebar from '@/components/Sidebar.vue'
import RProducts from '@/components/reporttables/RProducts.vue'
import axios from 'axios'

export default {
    name: 'assets',
    components: {
        Header,
        Sidebar,
        RProducts,
    },
    methods: {

        downloadPdf() {
            axios.get('https://internship2021-api.mss.ba/api/PdfCreator/getProductsPDF')
            .then((response) => {
                let r = response.data;
                let url = 'https://internship2021-api.mss.ba/' + r.FileName;
                let w = window.open(url);
            })
            .catch((error) => {
                console.log(error);
            })
        }
    }
}
</script>

<style>
.container, .container-fluid, .container-lg, .container-md, .container-sm, .container-xl, .container-xxl {
    width: 100%;
    margin-right: auto;
    margin-left: auto;
}
.page-header {
    margin-bottom: 3rem;
    margin-left: 20%;
    margin-top: 3%;
}
.align-items-center {
    align-items: center!important;
}
.justify-content-between {
    justify-content: space-between!important;
}
.d-flex {
    display: flex!important;
}
.page-header {
    margin-bottom: 3rem;
}
.align-items-center {
    align-items: center!important;
}
.justify-content-between {
    justify-content: space-between!important;
}
.d-flex {
    display: flex!important;
}
.page-heading {
    text-transform: uppercase;
    letter-spacing: .2em;
    font-weight: 300;
    font-size: 45px;
}
.text-sm {
    font-size: .7875rem!important;
}
.list-inline, .list-unstyled {
    list-style: none;
}
dl, ol, ul {
    margin-top: 0;
    margin-bottom: 1rem;
}
.list-inline-item {
    display: inline-block;
}
.text-gray-600 {
    color: #6c757d!important;
}
.text-uppercase {
    text-transform: uppercase!important;;
    letter-spacing: .2em;
}
.btn-primary {
    color: #fff;
    background-color: #4650dd;
    border-color: #4650dd;
}
.btn{
    display: inline-block;
}
select{
    font-family: 'Poppins', sans-serif;
}
.form-modal{
    font-size: 14px;
    padding: 8px;
    color:#6c757d;
}
</style>