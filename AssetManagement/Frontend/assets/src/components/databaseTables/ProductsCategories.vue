<template>
    <div class="col-lg-11 table-margin">
        <div class="mb-3 card">
            <div class="card-header"> 
                <Modal modal_title="ADD NEW PRODUCT CATEGORY" modal_id="product_category_modal">
                    <template slot="body">
                        <span class="error-msg">{{submitStatus}}</span>
                        <form action="">
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >Product category
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Product category"
                                type="text"
                                id="name"
                                v-model.trim="$v.productCategoryName.$model"
                                :class="{'is-invalid':$v.productCategoryName.$error, 'is-valid':!$v.productCategoryName.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.productCategoryName.required">Product category is required.</span>
                                    <span v-if="!$v.productCategoryName.minLength">Category must have at least {{$v.productCategoryName.$params.minLength.min}} characters.</span>
                                </div>
                            </div>
                        </form>
                    </template>
                    <template slot="footer">
                        <button class="btn btn-primary" @click="addNewProductCategory()">
                        Save
                        </button>
                    </template>
                </Modal>
                <div class="card-heading">Products categories
                    <button type="button" class="btn btn-primary text-uppercase" @click="$root.$emit('product_category_modal_open')">
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
                                <th>Product category</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="productCategory in productCategories" :key="productCategory.rowKey">
                                <td scope="row"></td>
                                <td>{{productCategory.productCategoryName}}</td>
                                <td>
                                    <button class="text-lg" @click="deleteProductCategory(productCategory.rowKey)">
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
    name: 'ProductsCategories',
    components:{
        Modal
    },
    data(){
        return {
            productCategories: [],
            productCategoryName:"",
            submitStatus:null
        }
    },
    validations:{
        productCategoryName: {required, minLength: minLength(3)},
    },
    methods:{
        getAllProductsCategories(){
            var self = this;
      let options = { 
          headers: {
              Authorization: "Bearer " + localStorage.userToken
          }
     };
      axios
        .get('https://internship2021-api.mss.ba/api/Database/productCategories', options)
        .then(function (response) {
          self.productCategories = response.data;
        })
        .catch(function (error) {
          console.log(error);
        });
        },
        addNewProductCategory(){
            let form = {
                productCategoryName: this.productCategoryName,
            };
            this.$v.$touch()
            if(!this.$v.$invalid){
            
            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

        axios
            .post('https://internship2021-api.mss.ba/api/Database/productCategories', form, options)
            .then((response) => {
                this.productCategoryName="";
                this.getAllProductsCategories();
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
        deleteProductCategory(rowKey){
               let options = { 
        headers: {
          Authorization: "Bearer " + localStorage.userToken
        }
      };
            axios.delete('https://internship2021-api.mss.ba/api/Database/productCategories/' + rowKey, options)
            .then((result)=>{
                this.getAllProductsCategories();
            })
            .catch((error) => {
                console.log(error);
            })
        }
    },
    mounted(){
        this.getAllProductsCategories();
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