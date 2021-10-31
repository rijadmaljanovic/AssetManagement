<template>
    <div class="d-flex align-items-stretch">
        <div class="page-holder">
            <div class="px-lg-4 px-xl-5 container-fluid">
                <div class="page-header d-flex justify-content-between align-items-center">
                    <div>
                        <h1 class="page-heading">Products</h1>
                    </div>
                    <div>
                        <!-- Modal for creating new product -->
                        <Modal modal_title="ADD NEW PRODUCT" modal_id="product_modal_create">
                            <template slot="body">
                                <form @submit.prevent="submitForm()">

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Product name <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Product name" type="text" id="productname" 
                                        v-model.trim="$v.productName.$model" :class="{'is-invalid':$v.productName.$error, 'is-valid':!$v.productName.$invalid }">
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.productName.required">Product name is required.</span>
                                            <span v-if="!$v.productName.minLength">Product name must have at least {{$v.productName.$params.minLength.min}} letters.</span>
                                        </div>    
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">
                                            Product type<span class="text-danger">*</span>
                                        </label>
                                        <select class="form-control form-select form-select-sm form-modal" type="select" id="producttype" placeholder="Product type" 
                                        v-model.trim="$v.productType.$model" :class="{'is-invalid':$v.productType.$error, 'is-valid':!$v.productType.$invalid }">
                                        <option value="" selected>
                                            Choose product type
                                        </option>
                                        <option v-for="productRefValue in productRefValues.productTypes" 
                                                :key="productRefValue.rowKey" 
                                                
                                                :value="productRefValue.rowKey">
                                                {{productRefValue.productTypeName}}
                                        </option>
                                        </select>
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.productType.required">Product type is required.</span>
                                        </div> 
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">
                                            Product category<span class="text-danger">*</span>
                                        </label>

                                        <select class="form-control form-select form-select-sm form-modal" type="select" id="productcategory" placeholder="Product category" 
                                        v-model.trim="$v.productCategory.$model" :class="{'is-invalid':$v.productCategory.$error, 'is-valid':!$v.productCategory.$invalid }">
                                        <option value="" selected>
                                            Choose product category
                                        </option>
                                        <option v-for="productRefValue in productRefValues.productCategories" 
                                                :key="productRefValue.rowKey" 
                                                
                                                :value="productRefValue.rowKey">
                                                {{productRefValue.productCategoryName}}
                                        </option>
                                        </select>
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.productCategory.required">Product type is required.</span>
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Manufacturer <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Manufacturer" type="text" id="manufacturer" 
                                        v-model.trim="$v.manufacturer.$model" :class="{'is-invalid':$v.manufacturer.$error, 'is-valid':!$v.manufacturer.$invalid }">    
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.manufacturer.required">Manufacturer  is required.</span>
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Description</label>
                                        <input class="form-control" placeholder="Description" type="text" id="productname" v-model="description">    
                                    </div>

                                    <button type="submit" class="btn btn-primary">
                                        Save 
                                    </button>
                            </form>
                            </template>
                            <template slot="footer">
                            </template>
                     </Modal>
                        
                        <button @click="$root.$emit('product_modal_create_open')" class="btn btn-primary text-uppercase" type="button">
                            <i class="fas fa-plus"></i> 
                            Add new
                        </button>
                    </div>
                </div>

        <section class="mb-5">
        <div class="card-table mb-4 card">
            <div class="card-header">
                <h4 class="card-heading">List of all products</h4>
            </div>
            <div class="dataTable-wrapper no-footer sortable fixed-columns">
                
                <div class="dataTable-container border-0">
                <table class="table mb-0 table-hover align-middle table-borderless dataTable-table">
                    <thead>
                        <tr>
                            <th data-sortable class>
                                <a href="#" class="dataTable-sorter">Product name</a>
                            </th>
                            <th data-sortable class>
                                <a href="#" class="dataTable-sorter">Product Type</a>
                            </th>
                            <th data-sortable class>
                                <a href="#" class="dataTable-sorter">Product Category</a>
                            </th>
                             <th data-sortable class>
                                <a href="#" class="dataTable-sorter">Action</a>
                            </th>
                            <th data-sortable class>
                                <a href="#" class="dataTable-sorter">Map</a>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="product in products" :key="product.id">
                            <td>{{product.productName}}</td>
                            <td>{{product.productType}}</td>
                            <td>{{product.productCategory}}</td>
                            <td>
                                        <!-- Modal for updating product -->
                        <Modal modal_title="UPDATE PRODUCT" modal_id="product_modal_update">
                            <template slot="body">
                                <form @submit.prevent="updateProduct()">

                                    <input type="hidden" v-model="id">

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Product name <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Product name" type="text" id="productname" 
                                        v-model.trim="$v.productName.$model" :class="{'is-invalid':$v.productName.$error, 'is-valid':!$v.productName.$invalid }"> 
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.productName.required">Product name is required.</span>
                                            <span v-if="!$v.productName.minLength">Product name must have at least {{$v.productName.$params.minLength.min}} letters.</span>
                                        </div> 
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">
                                            Product type<span class="text-danger">*</span>
                                        </label>
                                        <select class="form-control form-select form-select-sm form-modal" type="select" id="producttype" placeholder="Product type" 
                                        v-model.trim="$v.productType.$model" :class="{'is-invalid':$v.productType.$error, 'is-valid':!$v.productType.$invalid }">

                                        <option value="" selected>
                                            Choose product type
                                        </option>
                                        <option v-for="productRefValue in productRefValues.productTypes" 
                                                :key="productRefValue.rowKey" 
                                                
                                                :value="productRefValue.rowKey">
                                                {{productRefValue.productTypeName}}
                                        </option>
                                        </select>
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.productType.required">Product type is required.</span>
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">
                                            Product category<span class="text-danger">*</span>
                                        </label>
                                        <select class="form-control form-select form-select-sm form-modal" type="select" id="productcategory" placeholder="Product category" 
                                        v-model.trim="$v.productCategory.$model" :class="{'is-invalid':$v.productCategory.$error, 'is-valid':!$v.productCategory.$invalid }">

                                        <option value="" selected>
                                            Choose product category
                                        </option>
                                        <option v-for="productRefValue in productRefValues.productCategories" 
                                                :key="productRefValue.rowKey" 
                                                
                                                :value="productRefValue.rowKey">
                                                {{productRefValue.productCategoryName}}
                                        </option>
                                        </select>
                                         <div class="invalid-feedback">
                                            <span v-if="!$v.productCategory.required">Product category is required.</span>
                                        </div>
                                    </div>

                                    <button type="submit" class="btn btn-primary">
                                        Save 
                                    </button>
                            </form>
                            </template>
                            
                     </Modal>
                        
                                <button class="me-3 text-lg text-success" @click="editModalOpened(product)"><i class="fas fa-edit"></i></button>
                                <button class="text-lg text-danger" @click="deleteProduct(product.id)"><i class="fas fa-trash-alt"></i></button>
                            </td>
                            <td>
                                <button @click="openMapModal(product.productName)">
                                    <i class="fas fa-map-marked-alt"></i>
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            </div>
        </div>
        </section>
                </div>
            </div>
        <Modal modal_title="MAP" modal_id="map_modal">
            <template slot="body">
                <Map v-if="mapData.length > 0" :latitude="mapData[mapData.length - 1].latitude" :longitude="mapData[mapData.length - 1].longitude"></Map>
                <div v-else> No geographical data for this product! </div>
            </template>
        </Modal>
    </div>

</template>

<script>
import Modal from '@/components/Modal.vue'
import Map from '@/components/Map.vue'
import axios from 'axios'
import { required, minLength } from 'vuelidate/lib/validators'

export default {
    name: 'ListAllProducts',
    components: {
        Modal,
        Map
    },
    data() {
        return {
            products: [],
            productRefValues: [],
            productName: '',
            productType: '',
            productCategory: '',
            manufacturer: '',
            description: '',        
            id: '',
            submitStatus: null,
            mapData: []

        }
    },
    validations: {
        productName: { required, minLength: minLength(3) },
        productType: { required },
        productCategory: { required },
        manufacturer: { required }
    },

    methods: {

        getProducts() {
            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

            axios.get('https://internship2021-api.mss.ba/api/Product', options)
           
            .then((response) => {
                this.products = response.data;
            })
            .catch((error) => {
                console.log(error);
            })
        },

        getProductTypes() {
            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

            axios.get('https://internship2021-api.mss.ba/api/Product/getProductRefValues', options)
           
            .then((response) => {
                this.productRefValues = response.data;
            })
            .catch((error) => {
                console.log(error);
            })
        },
        
        submitForm(){
            let form = {
                productName: this.productName,
                productTypeId: this.productType,
                productCategoryId: this.productCategory,
                manufacturer: this.manufacturer,
                description: this.description
            };

            this.$v.$touch()
            if(!this.$v.$invalid){
                let options = { 
                    headers: {
                        Authorization: "Bearer " + localStorage.userToken
                    }
                };

                axios.post('https://internship2021-api.mss.ba/api/Product', form, options)
                .then(response => {
                    console.log(response);
                    this.productName = "";
                    this.productType = "";
                    this.productCategory = "";
                    this.manufacturer = "";
                    this.description = "";
                    this.getProducts();
                    this.$v.$reset();

                    if(response.status === 200){
                    this.$root.$emit('modal_close');
                    } 
                })
                .catch((error) => {
                    console.log(error);
                })
            }
            else{
                this.submitStatus = "fail"
            }

            axios.post('https://internship2021-api.mss.ba/api/Product', form)
            .then(response => {
                this.getProducts();

                if(response.status === 200){
                 this.$root.$emit('modal_close');
                } 
            })
            .catch((error) => {
                console.log(error);
            })
        },

        editModalOpened(product){
            let productTypeE = this.productRefValues.productTypes.find(x => x.productTypeName == product.productType).rowKey;
            let productCategoryE = this.productRefValues.productCategories.find(x => x.productCategoryName == product.productCategory).rowKey;

            this.productName = product.productName;
            this.productType = productTypeE;
            this.productCategory = productCategoryE;
            this.id = product.id;
            
            this.$root.$emit('product_modal_update_open');
            
        },

        updateProduct(){
            let id = this.id;

            let form = {
                productName: this.productName,
                productTypeId: this.productType,
                productCategoryId: this.productCategory
                // manufacturer: "test",
                // description: "test"
            };

            this.$v.$touch()
            if(this.$v.$invalid){
                this.submitStatus = "fail"
            }
            else{
                this.submitStatus = "success"
            }

            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

            axios.put('https://internship2021-api.mss.ba/api/Product/' + id, form, options)
            .then(response => {
                this.getProducts();

                if(response.status === 200)
                    this.$root.$emit('modal_close');
            })
            .catch((error) => {
                console.log(error);
            })
        },

        deleteProduct(id){
            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

            axios.delete('https://internship2021-api.mss.ba/api/Product/' + id, options)
            .then((result)=>{
                this.getProducts();
            })
            .catch((error) => {
                console.log(error);
            })
        },

        openMapModal(productName) {
            let selectedProduct = productName;
            this.getMapData(selectedProduct);
        },

        getMapData(selectedProductProp) {
            let self = this;
            axios.get('https://internship2021-gw.mss.ba/data/' + selectedProductProp)
            .then((res)=>{
                self.mapData = res.data;
                self.$root.$emit("map_modal_open");
            })
            .catch((error) => {
                self.mapData = [];
                console.log(error);
            })
        }
    },
        
    mounted() {
        this.getProducts();
        this.getProductTypes();
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