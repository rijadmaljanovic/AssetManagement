<template>
<!-- eslint-disable vue/no-use-v-if-with-v-for,vue/no-confusing-v-for-v-if -->
    <div class="col-lg-11 table-margin">
        <div class="mb-3 card">
            <div class="card-header"> 
                <Modal modal_title="ADD NEW EMPLOYEE" modal_id="employee_modal">
                    <template slot="body">
                        <span class="error-msg">{{submitStatus}}</span>
                        <form action="">
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                >Employee name
                                <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Employee name"
                                type="text"
                                id="name"
                                v-model.trim="$v.name.$model"
                                :class="{'is-invalid':$v.name.$error, 'is-valid':!$v.name.$invalid }"
                                >
                                <div class="invalid-feedback">
                                <span v-if="!$v.name.required">Employee's name is required.</span>
                                <span v-if="!$v.name.minLength">Employee's name must have at least {{$v.name.$params.minLength.min}} letters.</span>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                >Employee surname
                                <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Employee surname"
                                type="text"
                                id="name"
                                v-model.trim="$v.lastName.$model"
                                :class="{'is-invalid':$v.lastName.$error, 'is-valid':!$v.lastName.$invalid }"
                                >
                                <div class="invalid-feedback">
                                <span v-if="!$v.lastName.required">Employee's last name is required.</span>
                                <span v-if="!$v.lastName.minLength">Employee's last name must have at least {{$v.lastName.$params.minLength.min}} letters.</span>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label class="text-uppercase form-label"
                                >Location
                                <span class="text-danger">*</span>
                                </label>
                                <select
                                class="form-control form-select form-select-sm form-modal"
                                type="select"
                                id="name"
                                placeholder="Location"
                                v-model.trim="$v.location.$model"
                                :class="{'is-invalid':$v.location.$error, 'is-valid':!$v.location.$invalid }"
                                >
                                <option value="" selected>
                                    Choose employee's location
                                </option>
                                <option v-for="location in locations" :key="location.rowKey">
                                    {{location.locationName}}
                                </option>
                                </select>
                                <div class="invalid-feedback">
                                <span v-if="!$v.location.required">You must choose employee's location.</span>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                >Employee e-mail
                                <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Employee e-mail"
                                type="text"
                                id="name"
                                v-model.trim="$v.email.$model"
                                :class="{'is-invalid':$v.email.$error, 'is-valid':!$v.email.$invalid }"
                                >
                                <div class="invalid-feedback">
                                <span v-if="!$v.email.required">Employee's e-mail is required.</span>
                                <span v-if="!$v.email.isUnique">This email is wrong or already exists.</span>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >Employee phone number
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Employee phone number"
                                type="text"
                                id="name"
                                v-model.trim="$v.phoneNumber.$model"
                                :class="{'is-invalid':$v.phoneNumber.$error, 'is-valid':!$v.phoneNumber.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.phoneNumber.required">Phone number is required.</span>
                                    <span v-if="!$v.phoneNumber.alpha">Only numerics. </span>
                                    <span v-if="!$v.phoneNumber.minLength">Phone number must have at least {{$v.phoneNumber.$params.minLength.min}} characters.</span>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label class="text-uppercase form-label"
                                >Department
                                <span class="text-danger">*</span>
                                </label>
                                <select
                                class="form-control form-select form-select-sm form-modal"
                                type="select"
                                id="name"
                                placeholder="Department"
                                v-model.trim="$v.department.$model"
                                :class="{'is-invalid':$v.department.$error, 'is-valid':!$v.department.$invalid }"
                                >
                                <option value="" selected>
                                    Choose employee's department
                                </option>
                                <option v-for="department in departments" :key="department.rowKey"
                                        v-if="department!=null">
                                    {{department.departmentName}}
                                </option>
                                </select>
                                <div class="invalid-feedback">
                                <span v-if="!$v.department.required">You must choose employee's department.</span>
                                </div>
                            </div>
                        </form>
                    </template>
                    <template slot="footer">
                    <button class="btn btn-primary" @click="addNewEmployee()">
                    Save
                    </button>
                    </template>
                </Modal>
                <div class="card-heading">Employees
                    <button type="button" class="btn btn-primary text-uppercase" @click="$root.$emit('employee_modal_open')">
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
                                <th>Name</th>
                                <th>Surname</th>
                                <th>Location</th>
                                <th>E-mail</th>
                                <th>Phone number</th>
                                <th>Department</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="employee in employees" :key="employee.rowKey">
                                <td scope="row"></td>
                                <td>{{employee.name}}</td>
                                <td>{{employee.lastName}}</td>
                                <td>{{employee.location}}</td>
                                <td>{{employee.email}}</td>
                                <td>{{employee.phoneNumber}}</td>
                                <td>{{employee.department}}</td>
                                <td>
                                    <button class="text-lg" @click="deleteEmployee(employee.rowKey)">
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
import { required, minLength, numeric, email} from 'vuelidate/lib/validators'

export default{
    name: 'EmployeesTable',
    components:{
        Modal
    },
    data(){
        return{
            employees:[],
            name:"",
            lastName:"",
            location:"",
            email:"",
            phoneNumber:"",
            department:"",
            locations:[],
            departments:[],
            departmentId:"",
            submitStatus:null
        }
    },
    validations:{
        name: { required, minLength: minLength(3) },
        lastName: { required, minLength: minLength(3) },
        location: { required},
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
        phoneNumber:{required, numeric, minLength: minLength(6)},
        department: { required},
    },
    methods:{
        getAllEmployees(){
            var self = this;
      let options = { 
          headers: {
              Authorization: "Bearer " + localStorage.userToken
          }
     };
      axios
        .get('https://internship2021-api.mss.ba/api/Database/employees',options)
        .then(function (response) {
          self.employees = response.data;
        })
        .catch(function (error) {
          console.log(error);
        });
        },
        addNewEmployee(){

        var chosen = "";
        
        for(var i = 0; i<this.departments.length; i++){
            if (this.departments[i].departmentName === this.department){
                chosen = this.departments[i].rowKey;
            }

        }

        let form = {
            name: this.name,
            lastName: this.lastName,
            location: this.location,
            email: this.email,
            phoneNumber: this.phoneNumber,
            departmentId: chosen,
        };
        this.$v.$touch()
            if(!this.$v.$invalid){
            
            let options = { 
            headers: {
                Authorization: "Bearer " + localStorage.userToken
            }
            };

        axios
            .post('https://internship2021-api.mss.ba/api/Database/employees', form, options)
            .then((response) => {
                this.name="";
                this.lastName="";
                this.location="";
                this.email="";
                this.phoneNumber="";
                this.department="";
            this.getAllEmployees();
            this.$v.$reset();

            if(response.status === 200){
                this.$root.$emit('modal_close');
            } 
            })
            .catch((error) => {
                console.log(error);
            });
                }else{
                    this.submitStatus = "Request failed."
                }
        },
        deleteEmployee(rowKey){
        let options = { 
            headers: {
                Authorization: "Bearer " + localStorage.userToken
            }
      };
            axios.delete('https://internship2021-api.mss.ba/api/Database/employees/' + rowKey,options)
            .then((result)=>{
                this.getAllEmployees();
            })
            .catch((error) => {
                console.log(error);
            })
        },
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
        getAllDepartmeents(){
             var self = this;
      let options = { 
          headers: {
              Authorization: "Bearer " + localStorage.userToken
          }
     };
      axios
        .get('https://internship2021-api.mss.ba/api/Database/departments', options)
        .then(function (response) {
          self.departments = response.data;
        })
        .catch(function (error) {
          console.log(error);
        });
        }
    },
    mounted(){
        this.getAllEmployees();
        this.getAllLocations();
        this.getAllDepartmeents();
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