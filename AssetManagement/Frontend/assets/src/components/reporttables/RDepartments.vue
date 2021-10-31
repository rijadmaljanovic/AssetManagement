<template>
    <section class="mb-5">
    <div class="card-table mb-4 card">
        <div class="card-header">
            <h4 class="card-heading">List of all Departments</h4>
        </div>
        <div class="dataTable-wrapper no-footer sortable fixed-columns">
            <div class="dataTable-container border-0">
            <table class="table mb-0 table-hover align-middle table-borderless dataTable-table">
                <thead>
                    <tr>
                        <th data-sortable class>
                            <a href="#" class="dataTable-sorter">Department name</a>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="department in departments" :key="department.id">
                            <td>{{department.departmentName}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
        </div>
        </div>
        </section>
</template>

<script>
import axios from 'axios'

export default {
    name: 'ReportVendor',
    
    data() {
        return {
            departments: [],
        }
    },

    methods: {
        
        getDepartments() {
            axios.get('https://internship2021-api.mss.ba/api/Reports/departments')
           
            .then((response) => {
                this.departments = response.data;
            })
            .catch((error) => {
                console.log(error);
            })
        },
    },

    mounted() {
        this.getDepartments();
    }
}

</script>

<style>
*{
    box-sizing: border-box;
}
.align-items-stretch{
    align-items: stretch!important;
}

.d-flex{
     display: flex!important;
}

.page-holder{
    display: flex;
    overflow-x: hidden;
    width: 100%;
    min-height: calc(100vh - 72px);
    padding-top: 3rem;
    flex-wrap: wrap;
  

}

.bg-gray-100{
    background-color: #f8f9fa!important;
}

.container-fluid{
    width: 100%;
    margin-right: auto;
    margin-left: auto;
}

.page-header{
    margin-bottom: 3rem;
}

.align-items-center{
    align-items: center!important;
}

.justify-content-between{
    justify-content: space-between!important;
}

.d-flex{
    display: flex!important;
}

.page-heading{
    text-transform: uppercase;
    letter-spacing: .2em;
    font-weight: 300;
}

h1{
    display: block;
    font-size: 2em;
    margin-block-start: 0.67em;
    margin-block-end: 0.67em;
    margin-inline-start: 0px;
    margin-inline-end: 0px;
    font-weight: bold;
}

a{
    text-decoration: none;
}
.text-uppercase{
    letter-spacing: .2em;
}

.btn{
    display: inline-block;
    font-weight: 400;
    line-height: 1.5;
    text-align: center;
    vertical-align: middle;
    cursor: pointer;
    user-select: none;
    border: 1px solid transparent;
    padding: .375rem .75rem;
    font-size: .9rem;
    border-radius: .25rem;
}

.btn-primary{
    color: #fff;
    background-color: #4650dd;
    border-color: #4650dd;
}

.mb-5{
    margin-bottom: 3rem!important;
}

.dataTable-wrapper{
    background: #f8f9fa;
    overflow-x: auto;
    max-width: 100%;
}
.dataTable-top{
    font-size: .7875rem;
    padding: 2rem;
    background: #f8f9fa;
}

.dataTable-dropdown>div:last-child {
    float: right;
}

label {
    display: inline-block;
    cursor: default;
}

.dataTable-selector {
    display: inline!important;
    width: auto;
}

.form-select-sm {
    padding-top: .25rem;
    padding-bottom: .25rem;
    padding-left: .5rem;
    font-size: .7875rem;
}
.form-select{
    padding: .200rem 1.25rem .300rem .50rem;
    font-weight: 400;
    line-height: 1.5;
    color: #343a40;
    background-color: #fff;
    background-repeat: no-repeat;
    background-position: right  center;
    background-size: 16px 12px;
    border: 1px solid #ced4da;
}

select{
    text-transform: none;
    margin: 0;
    letter-spacing: normal;
    word-spacing: normal;
    display: inline-block;
    text-align: start;
    box-sizing: border-box;
    align-items: center;
    font: 400 13.3333px Arial;
    border-radius: 0px;
    border-width: 1px;
    border-style: solid;
    cursor: pointer;
}

.dataTable-input.form-control-sm {
    padding: .25rem .5rem;
}

.dataTable-container{
    border: 0;
}

.border-0 {
    border: 0!important;
}

.card-table .dataTable-table {
    background: #fff;
}
.dataTable-table {
    width: 100%;
    max-width: 100%;
    border-collapse: separate;
    border-spacing: 0;
}
.align-middle {
    vertical-align: middle!important;
}
.border-0 {
    border: 0!important;
}
.table>thead {
    vertical-align: bottom;
}
tbody, td, tfoot, th, thead, tr {
    border: 0 solid;
    border-color: inherit;
}
.card-table .table tr td:first-child, .card-table .table tr th:first-child {
    padding-left: 2rem;
}
.table>:not(:last-child)>:last-child> {
    border-bottom-color: currentColor;
}
.card-table thead th {
    letter-spacing: .1em;
    text-transform: uppercase;
    color: #fff;
    background: #343a40;
    font-size: 13px;
}
a.dataTable-sorter{
    color: white;
    text-decoration: none;
}
.card-table .dataTable-bottom {
    padding: 2rem;
    background: #f8f9fa;
    margin-bottom: 2%;
}
.dataTable-bottom>nav:last-child {
    float: right;
}
nav {
    display: block;
}
.dataTable-bottom>div:first-child {
    float: left;
}
.dataTable-info {
    margin: 7px 0;
}
.dataTable-pagination li {
    float: left;
    list-style: none;
}
.dataTable-pagination ul {
    margin: 0;
    padding-left: 0;
}
.dataTable-pagination .active a, .dataTable-pagination .active a:focus, .dataTable-pagination .active a:hover {
    cursor: default;
    background-color: #d9d9d9;
}
.dataTable-pagination a {
    position: relative;
    float: left;
    margin-left: 2px;
    padding: 6px 12px;
    text-decoration: none;
    color: #333;
    border: 1px solid transparent;
}
a {
    transition: all .3s;
}
.dataTable-pagination a:hover{
    background-color: #d9d9d9;
}
@media (min-width: 992px){
    .px-lg-4 {
        padding-right: 1.5rem!important;
        padding-left: 1.5rem!important;
    }
}
@media (min-width: 1200px){
    .px-xl-5 {
        padding-right: 3rem!important;
        padding-left: 3rem!important;
    }
}

</style>