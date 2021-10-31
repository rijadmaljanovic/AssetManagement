<template>
    <div class="col-lg-11 table-margin">
        <div class="mb-3 card">
            <div class="card-header"> 
                <Modal modal_title="ADD NEW ASSET TYPE" modal_id="asset_type_modal">
                    <template slot="body">
                        <span class="error-msg">{{submitStatus}}</span>
                        <form action="">
                            <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                    >Asset type
                                    <span class="text-danger">*</span>
                                </label>
                                <input
                                class="form-control"
                                placeholder="Asset type"
                                type="text"
                                id="name"
                                v-model.trim="$v.assetTypeName.$model"
                                :class="{'is-invalid':$v.assetTypeName.$error, 'is-valid':!$v.assetTypeName.$invalid }"
                                >
                                <div class="invalid-feedback">
                                    <span v-if="!$v.assetTypeName.required">Asset type is required.</span>
                                    <span v-if="!$v.assetTypeName.minLength">Type must have at least {{$v.assetTypeName.$params.minLength.min}} characters.</span>
                                </div>
                            </div>
                        </form>
                    </template>
                    <template slot="footer">
                        <button class="btn btn-primary" @click="addNewAssetType()">
                        Save
                        </button>
                    </template>
                </Modal>
                <div class="card-heading">Assets types
                    <button type="button" class="btn btn-primary text-uppercase" @click="$root.$emit('asset_type_modal_open')">
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
                                <th>Asset type</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="assetType in assetTypes" :key="assetType.rowKey">
                                <td scope="row"></td>
                                <td>{{assetType.assetTypeName}}</td>
                                <td>
                                    <button class="text-lg" @click="deleteAssetType(assetType.rowKey)">
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
    name: 'AssetsTypes',
    components:{
        Modal
    },
    data(){
        return {
            assetTypes: [],
            assetTypeName:"",
            submitStatus:null
        }
    },
    validations:{
        assetTypeName: {required, minLength: minLength(3)},
    },
    methods:{
        getAllAssetTypes(){
             var self = this;
      let options = { 
          headers: {
              Authorization: "Bearer " + localStorage.userToken
          }
     };
      axios
        .get('https://internship2021-api.mss.ba/api/Database/assetTypes', options)
        .then(function (response) {
          self.assetTypes = response.data;
        })
        .catch(function (error) {
          console.log(error);
        });
        },
        addNewAssetType(){
            let form = {
                assetTypeName: this.assetTypeName,
            };
            this.$v.$touch()
            if(!this.$v.$invalid){
            
            let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

        axios
            .post('https://internship2021-api.mss.ba/api/Database/assetTypes', form, options)
            .then((response) => {
                this.assetTypeName="";
            this.getAllAssetTypes();
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
        deleteAssetType(rowKey){
            let options = { 
                headers: {
                Authorization: "Bearer " + localStorage.userToken
            }
      };
            axios.delete('https://internship2021-api.mss.ba/api/Database/assetTypes/' + rowKey, options)
            .then((result)=>{
                this.getAllAssetTypes();
            })
            .catch((error) => {
                console.log(error);
            })
        }
    },
    mounted(){
        this.getAllAssetTypes();
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