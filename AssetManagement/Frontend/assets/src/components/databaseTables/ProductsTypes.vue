<template>
    <div class="col-lg-11 table-margin">
        <div class="mb-3 card">
            <div class="card-header"> 
                <Modal modal_title="ADD NEW PRODUCT TYPE" modal_id="product_type_modal">
                    <template slot="body">
                        <span class="error-msg">{{submitStatus}}</span>
                        <form action="">
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >Product type
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Product type"
                                type="text"
                                id="name"
                                v-model.trim="$v.productTypeName.$model"
                                :class="{'is-invalid':$v.productTypeName.$error, 'is-valid':!$v.productTypeName.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.productTypeName.required">Product type is required.</span>
                                    <span v-if="!$v.productTypeName.minLength">Type must have at least {{$v.productTypeName.$params.minLength.min}} characters.</span>
                                </div>
                            </div>
                        </form>
                    </template>
                    <template slot="footer">
                        <button class="btn btn-primary" @click="addNewProductType()">
                        Save
                        </button>
                    </template>
                </Modal>
                <div class="card-heading">Products types
                    <button type="button" class="btn btn-primary text-uppercase" @click="$root.$emit('product_type_modal_open')">
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
                                <th>Product type</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="productType in productTypes" :key="productType.rowKey">
                                <td scope="row"></td>
                                <td>{{productType.productTypeName}}</td>
                                 <td>
                                    <button class="text-lg" @click="deleteProductType(productType.rowKey)">
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
import { required, minLength} from 'vuelidate/lib/validators'
import axios from "axios";

export default{
    name: 'ProductsTypes',
    components:{
        Modal
    },
    data(){
        return {
            productTypes: [],
            productTypeName:"",
            submitStatus: null
        }
    },
    validations:{
        productTypeName: {required, minLength: minLength(3)},
    },
    methods:{
        getAllProductTypes(){
            var self = this;
      let options = { 
          headers: {
              Authorization: "Bearer " + localStorage.userToken
          }
     };
      axios
        .get('https://internship2021-api.mss.ba/api/Database/productTypes', options)
        .then(function (response) {
          self.productTypes = response.data;
        })
        .catch(function (error) {
          console.log(error);
        });
        },
        addNewProductType(){
            let form = {
                productTypeName: this.productTypeName,
            };
                let options = { 
                    headers: {
                        Authorization: "Bearer " + localStorage.userToken
                    }
                };
            this.$v.$touch()
            if(!this.$v.$invalid){

            axios
                .post('https://internship2021-api.mss.ba/api/Database/productTypes', form, options)
                .then((response) => {
                this.productTypeName="";
                this.getAllProductTypes();
                this.$v.$reset();

                if(response.status === 200){
                    this.$root.$emit('modal_close');
                } 
                })
                .catch((error) => {
                console.log(error);
                });
            }
            else{
                this.submitStatus = "Request failed"
            }
        },
        deleteProductType(rowKey){
                        let options = { 
        headers: {
          Authorization: "Bearer " + localStorage.userToken
        }
      };
            axios.delete('https://internship2021-api.mss.ba/api/Database/productTypes/' +rowKey, options)
            .then((result)=>{
                this.getAllProductTypes();
            })
            .catch((error) => {
                console.log(error);
            })
        }
    },
    mounted(){
       this.getAllProductTypes(); 
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