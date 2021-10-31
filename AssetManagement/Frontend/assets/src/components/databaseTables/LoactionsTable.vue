<template>
    <div class="col-lg-11 table-margin">
        <div class="mb-3 card">
            <div class="card-header"> 
                <Modal modal_title="ADD NEW LOCATION" modal_id="location_modal">
                    <template slot="body">
                        <span class="error-msg">{{submitStatus}}</span>
                        <form action="">
                            <div class="mb-3">
                            <label class="text-uppercase form-label" for="name"
                            >Location name
                            <span class="text-danger">*</span>
                            </label>
                            <input
                            class="form-control"
                            placeholder="Location name"
                            type="text"
                            id="name"
                            v-model.trim="$v.locationName.$model"
                            :class="{'is-invalid':$v.locationName.$error, 'is-valid':!$v.locationName.$invalid }"
                            >
                            <div class="invalid-feedback">
                            <span v-if="!$v.locationName.required">Location name is required.</span>
                            <span v-if="!$v.locationName.minLength">Location name must have at least {{$v.locationName.$params.minLength.min}} letters.</span>
                            </div>
                            </div>
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >Address
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Address"
                                type="text"
                                id="name"
                                v-model.trim="$v.address.$model"
                                :class="{'is-invalid':$v.address.$error, 'is-valid':!$v.address.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.address.required">Address is required.</span>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >City
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="City"
                                type="text"
                                id="name"
                                v-model.trim="$v.city.$model"
                                :class="{'is-invalid':$v.city.$error, 'is-valid':!$v.city.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.city.required">City is required.</span>
                                    <span v-if="!$v.city.minLength">City must have at least {{$v.city.$params.minLength.min}} characters.</span>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >Contact person name
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Contact person name"
                                type="text"
                                id="name"
                                v-model.trim="$v.contactPersonName.$model"
                                :class="{'is-invalid':$v.contactPersonName.$error, 'is-valid':!$v.contactPersonName.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.contactPersonName.required">Name is required.</span>
                                    <span v-if="!$v.contactPersonName.minLength">Name must have at least {{$v.contactPersonName.$params.minLength.min}} characters.</span>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >Contact person phone number
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Contact person phone number"
                                type="text"
                                id="name"
                                v-model.trim="$v.contactPersonPhoneNumber.$model"
                                :class="{'is-invalid':$v.contactPersonPhoneNumber.$error, 'is-valid':!$v.contactPersonPhoneNumber.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.contactPersonPhoneNumber.required">Phone number is required.</span>
                                    <span v-if="!$v.contactPersonPhoneNumber.alphaNum">Only alphanumerics. </span>
                                    <span v-if="!$v.contactPersonPhoneNumber.minLength">Phone number must have at least {{$v.contactPersonPhoneNumber.$params.minLength.min}} characters.</span>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >Contact person e-mail
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Contact person e-mail"
                                type="text"
                                id="name"
                                v-model.trim="$v.contactPersonEmail.$model"
                                :class="{'is-invalid':$v.contactPersonEmail.$error, 'is-valid':!$v.contactPersonEmail.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.contactPersonEmail.required">E-mail is required.</span>
                                    <span v-if="!$v.contactPersonEmail.isUnique">This email is wrong or already exists.</span>
                                </div>
                            </div>
                        </form>
                    </template>
                    <template slot="footer">
                    <button class="btn btn-primary" @click="addNewLocation()">
                    Save
                    </button>
                    </template>
                </Modal>
                <div class="card-heading">Locations
                    <button type="button" class="btn btn-primary text-uppercase" @click="$root.$emit('location_modal_open')">
              <i class="fas fa-plus"></i>
              Add new
            </button>
                </div>
                
            </div>
            <div class="card-body"> 
                <div class="table-responsive">
                    <table class="card-text table table-striped table-hover">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Location name</th>
                                <th>Address</th>
                                <th>City</th>
                                <th>Contact person</th>
                                <th>Phone Number</th>
                                <th>E-mail</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="location in locations" :key="location.rowKey">
                                <td scope="row"></td>
                                <td>{{location.locationName}}</td>
                                <td>{{location.address}}</td>
                                <td>{{location.city}}</td>
                                <td>{{location.contactPersonName}}</td>
                                <td>{{location.contactPersonPhoneNumber}}</td>
                                <td>{{location.contactPersonEmail}}</td>
                                <td>
                                    <button class="text-lg" @click="deleteLocation(location.rowKey)">
                                    <i class="fas fa-trash-alt"></i>
                                    </button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
import Modal from '@/components/Modal.vue';
import { required, minLength, alphaNum, email} from 'vuelidate/lib/validators'

export default{
    name: 'LocationsTable',
    components:{
        Modal
    },
    data(){
        return {
            locations: [],
            locationName:"",
            address:"",
            city:"",
            contactPersonName:"",
            contactPersonPhoneNumber:"",
            contactPersonEmail:"",
            submitStatus: null,
        }
    },
    validations:{
        locationName: { required, minLength: minLength(3) },
        address: {required},
        city: {required, minLength: minLength(3)},
        contactPersonName:{required, minLength: minLength(3)},
        contactPersonPhoneNumber:{required, alphaNum, minLength: minLength(6)},
        contactPersonEmail: {required, email,
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
        }
    },
    methods:{
        getAllLocations(){
            var self = this;
      let options = { 
          headers: {
              Authorization: "Bearer " + localStorage.userToken
          }
     };
      axios
        .get('https://internship2021-api.mss.ba/api/Database/locations' ,options)
        .then(function (response) {
          self.locations = response.data;
        })
        .catch(function (error) {
          console.log(error);
        });
        },
        addNewLocation(){
            let form = {
                locationName: this.locationName,
                address: this.address,
                city: this.city,
                contactPersonName: this.contactPersonName,
                contactPersonPhoneNumber: this.contactPersonPhoneNumber,
                contactPersonEmail: this.contactPersonEmail,
            };

            this.$v.$touch()
        if(!this.$v.$invalid){
          
            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

        axios
            .post('https://internship2021-api.mss.ba/api/Database/locations', form,options)
            .then((response) => {
                this.locationName="";
                this.address="";
                this.city="";
                this.contactPersonName="";
                this.contactPersonPhoneNumber="";
                this.contactPersonEmail="";
            this.getAllLocations();
            this.$v.$reset();

            if(response.status === 200){
                this.$root.$emit('modal_close');
            } 
            })
            .catch((error) => {
                console.log(error);
            });
            } else{
                this.submitStatus = "Request failed."
            }
        },
        deleteLocation(rowKey){
      let options = { 
        headers: {
          Authorization: "Bearer " + localStorage.userToken
        }
      };
            axios.delete('https://internship2021-api.mss.ba/api/Database/locations/' + rowKey, options)
            .then((result)=>{
                this.getAllLocations();
            })
            .catch((error) => {
                console.log(error);
            })
        }
    },
    mounted(){
        this.getAllLocations();
    }
}
</script>

<style> 
    .card-heading{
        margin-bottom: 0;
        font-size: .9rem;
        font-weight: 400;
        text-transform: uppercase;
        letter-spacing: .2em;
        margin-top: 2%;
    }
    .btn{
        float: right;
        margin-bottom: 1%;
    }
</style>