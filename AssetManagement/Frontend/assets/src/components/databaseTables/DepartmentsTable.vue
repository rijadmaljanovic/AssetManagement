<template>
    <div class="col-lg-11 table-margin">
        <div class="mb-3 card">
            <div class="card-header"> 
                <Modal modal_title="ADD NEW DEPARTMENT" modal_id="department_modal">
                    <template slot="body">
                        <span class="error-msg">{{submitStatus}}</span>
                        <form action="">
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >Department name
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Department name"
                                type="text"
                                id="name"
                                v-model.trim="$v.departmentName.$model"
                                :class="{'is-invalid':$v.departmentName.$error, 'is-valid':!$v.departmentName.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.departmentName.required">Department name is required.</span>
                                </div>
                            </div>
                        </form>
                    </template>
                    <template slot="footer">
                        <button class="btn btn-primary" @click="addNewDepartment()">
                        Save
                        </button>
                    </template>
                </Modal>
                <div class="card-heading">Departments
                    <button type="button" class="btn btn-primary text-uppercase" @click="$root.$emit('department_modal_open')">
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
                                <th>Department name</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="department in departments" :key="department.rowKey">
                                <td scope="row"></td>
                                <td>{{department.departmentName}}</td>
                                <td>
                                    <button class="text-lg" @click="deleteDepartment(department.rowKey)">
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
import Modal from '@/components/Modal.vue';
import { required} from 'vuelidate/lib/validators'
import axios from "axios";

export default{
    name: 'DepartmentsTable',
    components:{
        Modal
    },
    data(){
        return {
            departments: [],
            departmentName:"",
            submitStatus:null
        }
    },
    validations:{
        departmentName: {required},
    },
    methods:{
        getAllDepartments(){
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
        },
        addNewDepartment(){
            let form = {
                departmentName: this.departmentName,
            };
            this.$v.$touch()
            if(!this.$v.$invalid){
            
            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

        axios
            .post('https://internship2021-api.mss.ba/api/Database/departments', form,options)
            .then((response) => {
                this.departmentName="";
            this.getAllDepartments();
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
        deleteDepartment(rowKey){
               let options = { 
        headers: {
          Authorization: "Bearer " + localStorage.userToken
        }
      };
            axios.delete('https://internship2021-api.mss.ba/api/Database/departments/' + rowKey,options)
            .then((result)=>{
                this.getAllDepartments();
            })
            .catch((error) => {
                console.log(error);
            })
        }

    },
    mounted(){
        this.getAllDepartments();
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