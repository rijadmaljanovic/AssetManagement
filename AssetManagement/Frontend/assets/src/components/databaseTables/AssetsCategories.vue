<template>
    <div class="col-lg-11 table-margin">
        <div class="mb-3 card">
            <div class="card-header"> 
                <Modal modal_title="ADD NEW ASSET CATEGORY" modal_id="asset_category_modal">
                    <template slot="body">
                        <span class="error-msg">{{submitStatus}}</span>
                        <form action="">
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >Asset category
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Asset category"
                                type="text"
                                id="name"
                                v-model.trim="$v.assetCategoryName.$model"
                                :class="{'is-invalid':$v.assetCategoryName.$error, 'is-valid':!$v.assetCategoryName.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.assetCategoryName.required">Asset category is required.</span>
                                    <span v-if="!$v.assetCategoryName.minLength">Category must have at least {{$v.assetCategoryName.$params.minLength.min}} characters.</span>
                                </div>
                            </div>
                        </form>
                    </template>
                    <template slot="footer">
                        <button class="btn btn-primary" @click="addNewAssetCategory()">
                        Save
                        </button>
                    </template>
                </Modal>
                <div class="card-heading">Assets Category
                    <button type="button" class="btn btn-primary text-uppercase" @click="$root.$emit('asset_category_modal_open')">
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
                                <th>Asset category</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="assetCategory in assetCategories" :key="assetCategory.rowKey">
                                <td scope="row"></td>
                                <td>{{assetCategory.assetCategoryName}}</td>
                                <td>
                                    <button class="text-lg" @click="deleteAssetCategory(assetCategory.rowKey)">
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
    name: 'AssetsCategories',
    components:{
        Modal,
    },
    data(){
        return {
            assetCategories: [],
            assetCategoryName:"",
            submitStatus:null
        }
    },
    validations:{
        assetCategoryName: {required, minLength: minLength(3)},
    },
    methods:{
        getAllAssetCategories(){
            var self = this;
      let options = { 
          headers: {
              Authorization: "Bearer " + localStorage.userToken
          }
     };
      axios
        .get('https://internship2021-api.mss.ba/api/Database/assetCategories',options)
        .then(function (response) {
          self.assetCategories = response.data;
        })
        .catch(function (error) {
          console.log(error);
        });
        },
        addNewAssetCategory(){
            let form = {
                assetCategoryName: this.assetCategoryName,
            };
            this.$v.$touch()
            if(!this.$v.$invalid){
            
            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

        axios
            .post('https://internship2021-api.mss.ba/api/Database/assetCategories', form,options)
            .then((response) => {
                this.assetCategoryName="";
            this.getAllAssetCategories();
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
        deleteAssetCategory(rowKey){
            let options = { 
        headers: {
            Authorization: "Bearer " + localStorage.userToken
        }
      };
            axios.delete('https://internship2021-api.mss.ba/api/Database/assetCategories/' + rowKey,options)
            .then((result)=>{
                this.getAllAssetCategories();
            })
            .catch((error) => {
                console.log(error);
            })
        }
    },
    mounted(){
        this.getAllAssetCategories();
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