<template>
    <div class="d-flex align-items-stretch">
        <div class="page-holder">
            <div class="px-lg-4 px-xl-5 container-fluid">
                <div class="page-header d-flex justify-content-between align-items-center">
                    <div>
                        <h1 class="page-heading">Vendors</h1>
                    </div>
                    <div>
                        <!-- Modal for creating new vendor -->
                        <Modal modal_title="ADD NEW VENDOR" modal_id="vendor_modal_create">
                            <template slot="body">
                                <form @submit.prevent="submitForm()">
                                    <div class="mb-3">
                                        <label class="text-uppercase form-label">Vendor name <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Vendor name" type="text" id="name" 
                                        v-model.trim="$v.vendorName.$model" :class="{'is-invalid':$v.vendorName.$error, 'is-valid':!$v.vendorName.$invalid }">    
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.vendorName.required">Vendor name is required.</span>
                                            <span v-if="!$v.vendorName.minLength">Vendor name must have at least {{$v.vendorName.$params.minLength.min}} letters.</span>
                                            <span v-if="!$v.vendorName.alpha">Only alphabet characters.</span>
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Email <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Email" type="email" id="email" 
                                        v-model.trim="$v.email.$model" :class="{'is-invalid':$v.email.$error, 'is-valid':!$v.email.$invalid }">   
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.email.required">Email is required.</span>
                                            <span v-if="!$v.email.isUnique">This email is wrong or already exists.</span>
                                        </div> 
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Phone number <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Phone number" type="text" id="phonenumber" 
                                        v-model.trim="$v.phoneNumber.$model" :class="{'is-invalid':$v.phoneNumber.$error, 'is-valid':!$v.phoneNumber.$invalid }">
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.phoneNumber.required">Phone number is required. </span>
                                            <span v-if="!$v.phoneNumber.numeric">Only numerics. </span>
                                            <span v-if="!$v.phoneNumber.minLength">Phone number must have at least {{$v.phoneNumber.$params.minLength.min}} numbers.</span>
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Contact person <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Contact person" type="text" id="contactperson" 
                                        v-model.trim="$v.contactPerson.$model" :class="{'is-invalid':$v.contactPerson.$error, 'is-valid':!$v.contactPerson.$invalid }">  
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.contactPerson.required">Contact person is required. </span>
                                            <span v-if="!$v.contactPerson.alpha">Only alphabet characters.</span>
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">City <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="City" type="text" id="city" 
                                        v-model.trim="$v.city.$model" :class="{'is-invalid':$v.city.$error, 'is-valid':!$v.city.$invalid }">
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.city.required">City is required. </span>
                                            <span v-if="!$v.city.alpha">Only alphabet characters.</span>
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Zip code <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Zip code" type="text" id="zipcode" 
                                        v-model.trim="$v.zipCode.$model" :class="{'is-invalid':$v.zipCode.$error, 'is-valid':!$v.zipCode.$invalid }">  
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.zipCode.required">Zip code is required. </span>
                                            <span v-if="!$v.zipCode.minLength">Zip code must have at least {{$v.zipCode.$params.minLength.min}} numbers.</span>
                                            <span v-if="!$v.city.alphaNum"> Only alphanumeric characters.</span>

                                        </div>  
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Address <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Address" type="text" id="address" 
                                        v-model.trim="$v.address.$model" :class="{'is-invalid':$v.address.$error, 'is-valid':!$v.address.$invalid }">
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.address.required">Address is required. </span>
                                            <span v-if="!$v.city.alphaNum">Only alphanumeric characters.</span>
                                        </div>    
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Additional Comment</label>
                                        <input class="form-control" placeholder="Additional Comment" type="text" id="additionalComment" v-model="additionalComment">    
                                    </div>

                                    <button type="submit" class="btn btn-primary">
                                        Save 
                                    </button>
                            </form>
                            </template>
                            <template slot="footer">
                            </template>
                     </Modal>
                     
                        <button @click="$root.$emit('vendor_modal_create_open')" class="btn btn-primary text-uppercase" type="button">
                            <i class="fas fa-plus"></i> 
                            Add new
                        </button>
                    </div>
                </div>

        <section class="mb-5">
        <div class="card-table mb-4 card">
            <div class="card-header">
                <h4 class="card-heading">List of all vendors</h4>
            </div>
            <div class="dataTable-wrapper no-footer sortable fixed-columns">
                
                <div class="dataTable-container border-0">
                <table class="table mb-0 table-hover align-middle table-borderless dataTable-table">
                    <thead>
                        <tr>
                           
                            <th data-sortable class>
                                <a href="#" class="dataTable-sorter">Vendor name</a>
                            </th>
                            <th data-sortable class>
                                <a href="#" class="dataTable-sorter">Phone number</a>
                            </th>
                            <th data-sortable class>
                                <a href="#" class="dataTable-sorter">Email</a>
                            </th>
                            <th data-sortable class>
                                <a href="#" class="dataTable-sorter">Contact person</a>
                            </th>
                            <th data-sortable class>
                                <a href="#" class="dataTable-sorter">City</a>
                            </th>
                             <th data-sortable class="asc">
                                <a href="#" class="dataTable-sorter">Zip Code</a>
                            </th>
                             <th data-sortable class>
                                <a href="#" class="dataTable-sorter">Address</a>
                            </th>
                             <th data-sortable class="asc">
                                <a href="#" class="dataTable-sorter">Additional Comment</a>
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
                        <tr v-for="vendor in vendors" :key="vendor.guid">
                            <td>{{vendor.vendor_Name}}</td>
                            <td>{{vendor.phone_Number}}</td>
                            <td>{{vendor.email}}</td>
                            <td>{{vendor.contact_Person}}</td>
                            <td>{{vendor.city}}</td>
                            <td>{{vendor.zip_Code}}</td>
                            <td>{{vendor.address}}</td>
                            <td>{{vendor.additional_Comment}}</td>
                            <td>
                                        <!-- Modal for updating vendor -->
                        <Modal modal_title="UPDATE VENDOR" modal_id="vendor_modal_update">
                            <template slot="body">
                                <form @submit.prevent="updateVendor()">

                                    <input type="hidden" v-model="guid">
                                    
                                    <div class="mb-3" hidden>
                                        <label class="text-uppercase form-label">Vendor name <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Vendor name" type="text" id="name" v-model="vendorName">    
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Email <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Email" type="email" id="email" 
                                        v-model.trim="$v.email.$model" :class="{'is-invalid':$v.email.$error, 'is-valid':!$v.email.$invalid }">   
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.email.required">Email is required.</span>
                                            <span v-if="!$v.email.isUnique">This email is wrong or already exists.</span>
                                        </div> 
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Phone number <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Phone number" type="text" id="phonenumber" 
                                        v-model.trim="$v.phoneNumber.$model" :class="{'is-invalid':$v.phoneNumber.$error, 'is-valid':!$v.phoneNumber.$invalid }">
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.phoneNumber.required">Phone number is required. </span>
                                            <span v-if="!$v.phoneNumber.alpha">Only numerics. </span>
                                            <span v-if="!$v.phoneNumber.minLength">Phone number must have at least {{$v.phoneNumber.$params.minLength.min}} numbers.</span>
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Contact person <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Contact person" type="text" id="contactperson" 
                                        v-model.trim="$v.contactPerson.$model" :class="{'is-invalid':$v.contactPerson.$error, 'is-valid':!$v.contactPerson.$invalid }">  
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.contactPerson.required">Contact person is required. </span>
                                            <span v-if="!$v.contactPerson.alpha">Only alphabet characters.</span>
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">City <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="City" type="text" id="city" 
                                        v-model.trim="$v.city.$model" :class="{'is-invalid':$v.city.$error, 'is-valid':!$v.city.$invalid }">
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.city.required">City is required. </span>
                                            <span v-if="!$v.city.alpha">Only alphabet characters.</span>
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Zip code <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Zip code" type="text" id="zipcode" 
                                        v-model.trim="$v.zipCode.$model" :class="{'is-invalid':$v.zipCode.$error, 'is-valid':!$v.zipCode.$invalid }">  
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.zipCode.required">Zip code is required. </span>
                                            <span v-if="!$v.zipCode.minLength">Zip code must have at least {{$v.zipCode.$params.minLength.min}} numbers.</span>
                                            <span v-if="!$v.city.alphaNum">Only alphanumeric characters.</span>

                                        </div>  
                                    </div>

                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Address <span class="text-danger">*</span></label>
                                        <input class="form-control" placeholder="Address" type="text" id="address" 
                                        v-model.trim="$v.address.$model" :class="{'is-invalid':$v.address.$error, 'is-valid':!$v.address.$invalid }">
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.address.required">Address is required. </span>
                                            <span v-if="!$v.address.alphaNum">Only alphanumerics.</span>
                                        </div>    
                                    </div>


                                    <div class="mb-3">
                                        <label class="text-uppercase form-label" for="name">Additional Comment</label>
                                        <input class="form-control" placeholder="Additional Comment" type="text" id="additionalComment" v-model="additionalComment">    
                                    </div>

                                    <button type="submit" class="btn btn-primary">
                                        Save
                                    </button>
                            </form>
                            </template>
                            <template slot="footer">
                            </template>
                     </Modal>
                                
                                <button class="me-3 text-lg text-success" @click="editModalOpened(vendor.guid)"><i class="fas fa-edit"></i></button>
                                <button class="text-lg text-danger" @click="deleteVendor(vendor.guid)"><i class="fas fa-trash-alt"></i></button>
                            </td>
                            <td>
                                <button @click="openMapModal(vendor.vendor_Name)">
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
                <div v-else> No geographical data for this vendor! </div>
            </template>
        </Modal>
    </div>
</template>

<script>
import Modal from '@/components/Modal.vue'
import Map from '@/components/Map.vue'
import axios from 'axios'
import { required, minLength, email, numeric, alpha, alphaNum, helpers } from 'vuelidate/lib/validators'

export default {
    name: 'ListAllVendors',
    components: {
        Modal,
        Map
    },
    data() {
        return {
            vendors: [],
            vendorName: '',
            phoneNumber: '',
            email: '',
            contactPerson: '',
            city: '',
            zipCode: '',
            address: '',
            additionalComment: '',
            guid: '',
            submitStatus: null,
            mapData: []
        }
    },

    validations: {
        vendorName: { 
            required, 
            minLength: minLength(3), 
            isNameValid: helpers.regex('isNameValid', /^[a-zA-Z ]*$/)
            },

        email: {
            required, email,
            isUnique (value) {
                if(value === '') return true

                //eslint-disable-next-line
                var email_regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

                return new Promise((resolve) => {
                    setTimeout(() => {
                        resolve(email_regex.test(value))
                    }, 350 + Math.random() * 300)
                })
            }
        },

        city: { 
            required, 
            isCityValid: helpers.regex('isCityValid', /^[a-zA-Z ]*$/)
        },

        phoneNumber: { required, numeric, minLength: minLength(6) },

        contactPerson: { 
            required, 
            isContactPersonValid: helpers.regex('isContactPersonValid', /^[a-zA-Z ]*$/)
        },

        zipCode: { required, alphaNum, minLength: minLength(2) },

        address: { 
            required,
            isAddressValid: helpers.regex('isAddressValid', /^[a-zA-Z0-9 ]+$/)
        }
    }, 

    methods: {
        
        getVendors() {
            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

            axios.get('https://internship2021-api.mss.ba/api/vendor', options)
           
            .then((response) => {
                this.vendors = response.data;
            })
            .catch((error) => {
                console.log(error);
            })
        },

        submitForm(){
            let form = {
                vendor_Name: this.vendorName,
                phone_Number: this.phoneNumber,
                email: this.email,
                contact_Person: this.contactPerson,
                city: this.city,
                zip_Code: this.zipCode,
                address: this.address,
                additional_Comment: this.additionalComment
            };

            this.$v.$touch()
            if(!this.$v.$invalid){
                let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                    }
                };

                axios.post('https://internship2021-api.mss.ba/api/vendor', form, options)
                .then(response => {
                    console.log(response);
                    this.vendorName = "";
                    this.phoneNumber = "";
                    this.email = "";
                    this.contactPerson = "";
                    this.city = "";
                    this.zipCode = "";
                    this.address = "";
                    this.additionalComment = "";
                    this.getVendors();
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

            axios.post('https://internship2021-api.mss.ba/api/vendor', form)
            .then(response => {
                this.getVendors();

                if(response.status === 200){
                    this.$root.$emit('modal_close');
                }
            })
            .catch((error) => {
                console.log(error);
            })
            
        },

        editModalOpened(guid){
            let vendoredit = this.vendors.find(x => x.guid == guid);

            this.vendorName = vendoredit.vendor_Name;
            this.phoneNumber = vendoredit.phone_Number;
            this.email = vendoredit.email;
            this.contactPerson = vendoredit.contact_Person;
            this.city = vendoredit.city;
            this.zipCode = vendoredit.zip_Code;
            this.address = vendoredit.address;
            this.additionalComment = vendoredit.additional_Comment;
            this.guid = guid;

            this.$root.$emit('vendor_modal_update_open');
            
        },

        updateVendor(){

            let form = {
                vendor_Name: this.vendorName,
                phone_Number: this.phoneNumber,
                email: this.email,
                contact_Person: this.contactPerson,
                city: this.city,
                zip_Code: this.zipCode,
                address: this.address,
                additional_Comment: this.additionalComment,
                guid: this.guid
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

            axios.patch('https://internship2021-api.mss.ba/api/vendor/' + form.guid, form, options)
            .then(response => {
                this.getVendors();

                if(response.status === 200){
                    this.$root.$emit('modal_close');
                }
            })
            .catch((error) => {
                console.log(error);
            })
        },

        deleteVendor(guid){
            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

            axios.delete('https://internship2021-api.mss.ba/api/vendor/' + guid, options)
            .then((result)=>{
                this.getVendors();
            })
            .catch((error) => {
                console.log(error);
            })
        },

        openMapModal(vendorName) {
            let selectedVendor= vendorName;
            this.getMapData(selectedVendor);
        },

        getMapData(selectedVendorProp) {
            let self = this;
            axios.get('https://internship2021-gw.mss.ba/data/' + selectedVendorProp)
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
        this.getVendors();
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