<template>
<!-- eslint-disable vue/no-use-v-if-with-v-for,vue/no-confusing-v-for-v-if -->
  <div class="d-flex align-items-stretch">
    <div class="page-holder">
      <div class="px-lg-4 px-xl-5 container-fluid">
        <div class="page-header d-flex justify-content-between align-items-center">
          <div>
            <h1 class="page-heading">Assets</h1>
          </div>
          <div>
            <Modal modal_title="ADD NEW ASSET" modal_id="asset_modal">
              <template slot="body">
                <form method="post">
                  <div class="mb-3">
                    <label class="text-uppercase form-label"
                      >Asset category
                      <span class="text-danger">*</span>
                    </label>
                    <select
                      class="form-control form-select form-select-sm form-modal"
                      type="select"
                      id="name"
                      placeholder="Asset category"
                      v-model.trim="$v.assetCategory.$model"
                      :class="{'is-invalid':$v.assetCategory.$error, 'is-valid':!$v.assetCategory.$invalid }"
                    >
                      <option value="" selected>
                        Choose asset category
                      </option>
                      <option v-for="assetRefValue in assetRefValues.categories" 
                              v-if="assetRefValue !== null"
                              :key="assetRefValue.categories"
                              :value="assetRefValue" >
                        {{assetRefValue}}
                      </option>
                    </select>
                    <div class="invalid-feedback">
                    <span v-if="!$v.assetCategory.required">You must choose asset category.</span>
                    </div>
                  </div>
                  <div class="mb-3">
                    <label class="text-uppercase form-label" for="name"
                      >Asset type
                      <span class="text-danger">*</span>
                    </label
                    >
                    <select
                      class="form-control form-select form-select-sm form-modal"
                      type="select"
                      id="name"
                      placeholder="Asset type"
                      v-model.trim="$v.assetType.$model"
                      :class="{'is-invalid':$v.assetType.$error, 'is-valid':!$v.assetType.$invalid }"
                    >
                      <option value="" selected>
                        Choose asset type
                      </option>
                      <option v-for="assetRefValue in assetRefValues.types" 
                              v-if="assetRefValue !== null"
                              :key="assetRefValue.types" 
                              :value="assetRefValue">
                        {{assetRefValue}}
                      </option>
                    </select>
                    <div class="invalid-feedback">
                    <span v-if="!$v.assetType.required">You must choose asset type.</span>
                    </div>
                  </div>
                  <div class="mb-3">
                    <label class="text-uppercase form-label" for="name"
                      >Vendor
                      <span class="text-danger">*</span>
                    </label
                    >
                    <select
                      class="form-control form-select form-select-sm form-modal"
                      type="select"
                      id="name"
                      placeholder="Vendor"
                      v-model.trim="$v.vendor.$model"
                      :class="{'is-invalid':$v.vendor.$error, 'is-valid':!$v.vendor.$invalid }"
                    >
                      <option value="" selected>Choose vendor</option>
                      <option v-for="assetRefValue in assetRefValues.vendors" 
                              v-if="assetRefValue !== null"
                              :key="assetRefValue.vendors" 
                              :value="assetRefValue">
                        {{assetRefValue}}
                      </option>
                    </select>
                    <div class="invalid-feedback">
                    <span v-if="!$v.vendor.required">You must choose a vendor.</span>
                    </div>
                  </div>
                  <div class="mb-3">
                    <label class="text-uppercase form-label" for="name"
                      >Asset name
                      <span class="text-danger">*</span>
                      </label>
                    <input
                      class="form-control"
                      placeholder="Asset name"
                      type="text"
                      id="name"
                      v-model.trim="$v.assetName.$model"
                      :class="{'is-invalid':$v.assetName.$error, 'is-valid':!$v.assetName.$invalid }"
                    >
                    <div class="invalid-feedback">
                      <span v-if="!$v.assetName.required">Asset name is required.</span>
                      <span v-if="!$v.assetName.minLength">Asset name must have at least {{$v.assetName.$params.minLength.min}} letters.</span>
                    </div>
                  </div>
                  <div class="mb-3">
                    <label class="text-uppercase form-label" for="name"
                      >Serial number
                      <span class="text-danger">*</span>
                    </label>
                    <input
                      class="form-control"
                      placeholder="Serial number"
                      type="text"
                      id="name"
                      v-model.trim="$v.serialNumber.$model"
                      :class="{'is-invalid':$v.serialNumber.$error, 'is-valid':!$v.serialNumber.$invalid }"
                    >
                    <div class="invalid-feedback">
                      <span v-if="!$v.serialNumber.required">Serial number is required. </span>
                      <span v-if="!$v.serialNumber.alphaNum">Only alphanumerics.</span>
                    </div>   
                  </div>
                  <div class="mb-3">
                    <label class="text-uppercase form-label" for="name"
                      >Price
                      <span class="text-danger">*</span>
                    </label>
                    <input
                      class="form-control"
                      placeholder="Price"
                      type="text"
                      id="name"
                      v-model.number.trim="$v.price.$model"
                      :class="{'is-invalid':$v.price.$error, 'is-valid':!$v.price.$invalid }"
                    >
                    <div class="invalid-feedback">
                      <span v-if="!$v.price.required">Price number is required.</span>
                      <span v-if="!$v.price.numeric">Price must be with numbers only.</span>
                    </div>
                  </div>
                  <div class="mb-3">
                    <label class="text-uppercase form-label" for="name"
                      >Location
                      <span class="text-danger">*</span>
                    </label
                    >
                    <select
                      class="form-control form-select form-select-sm form-modal"
                      type="select"
                      id="name"
                      placeholder="Location"
                      v-model.trim="$v.location.$model"
                      :class="{'is-invalid':$v.location.$error, 'is-valid':!$v.location.$invalid }"
                    >
                      <option value="" selected>Pick a location</option>
                      <option v-for="assetRefValue in assetRefValues.locations" 
                              v-if="assetRefValue !== null" 
                              :key="assetRefValue.locations" 
                              :value="assetRefValue">
                        {{assetRefValue}}
                      </option>
                    </select>
                    <div class="invalid-feedback">
                      <span v-if="!$v.price.required">You must pick a location.</span>
                    </div>
                  </div>
                  <div class="mb-3">
                    <label class="text-uppercase form-label" for="name"
                      >Purchase date
                      <span class="text-danger">*</span>
                    </label
                    >
                    <input
                      class="form-control"
                      placeholder="Purchase date"
                      type="date"
                      id="name"
                      v-model.trim="$v.purchaseDate.$model"
                      :class="{'is-invalid':$v.purchaseDate.$error, 'is-valid':!$v.purchaseDate.$invalid }"
                    />
                    <div class="invalid-feedback">
                      <span v-if="!$v.purchaseDate.required">You must select a purchase date.</span>
                    </div>
                  </div>
                  <div class="mb-3">
                    <label class="text-uppercase form-label" for="name"
                      >Warranty expiry date
                    </label
                    >
                    <input
                      class="form-control"
                      placeholder="Warranty expiry date"
                      type="date"
                      id="name"
                      v-model="warrantyExpiryDate"
                    />
                  </div>
                  <div class="mb-3">
                    <label class="text-uppercase form-label" for="name"
                      >Purchase type
                      <span class="text-danger">*</span>
                    </label
                    >
                    <select
                      class="form-control form-select form-select-sm form-modal"
                      type="select"
                      id="name"
                      placeholder="Purchase type"
                      v-model.trim="$v.purchaseType.$model"
                      :class="{'is-invalid':$v.purchaseType.$error, 'is-valid':!$v.purchaseType.$invalid }"
                    >
                      <option value="" selected>
                        Choose a purchase type
                      </option>
                      <option v-for="assetRefValue in assetRefValues.purchaseTypes" 
                              v-if="assetRefValue !== null" 
                              :key="assetRefValue.purchaseTypes" 
                              :value="assetRefValue">
                       {{assetRefValue}}
                      </option>
                    </select>
                    <div class="invalid-feedback">
                      <span v-if="!$v.purchaseType.required">You must select a purchase type.</span>
                    </div>
                  </div>
                </form>
              </template>
              <template slot="footer">
                <button @click="addNewAsset()" class="btn btn-primary">
                  Save
                </button>
              </template>
            </Modal>

            <button
              @click="$root.$emit('asset_modal_open')"
              class="btn btn-primary text-uppercase"
              type="button"
            >
              <i class="fas fa-plus"></i>
              Add new
            </button>
          </div>
        </div>
        <section>
          <div class="card-table mb-4 card">
            <div class="card-header">
              <h4 class="card-heading">Data table - assets</h4>
            </div>
            <div class="dataTable-wrapper no-footer sortable fixed-columns">
              <div class="dataTable-container border-0">
                <table
                  class="
                    table
                    mb-0
                    table-hover
                    align-middle
                    table-borderless
                    dataTable-table
                  "
                >
                  <thead>
                    <tr>
                      <th data-sortable class="asc">
                        <a href="#" class="dataTable-sorter">Number</a>
                      </th>
                      <th data-sortable class>
                        <a href="#" class="dataTable-sorter">Asset name</a>
                      </th>
                      <th data-sortable class>
                        <a href="#" class="dataTable-sorter">Asset type</a>
                      </th>
                      <th data-sortable class>
                        <a href="#" class="dataTable-sorter">Vendor</a>
                      </th>
                      <th data-sortable class>
                        <a href="#" class="dataTable-sorter">Current state</a>
                      </th>
                      <th data-sortable class>
                        <a href="#" class="dataTable-sorter">
                          Assigned to employee</a>
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
                    <tr v-for="asset in assets" :key="asset.id">
                      <td>{{ asset.number }}</td>
                      <td>{{ asset.assetName }}</td>
                      <td>{{ asset.assetType }}</td>
                      <td>{{ asset.vendor }}</td>
                      <td>{{ asset.currentState }}</td>
                      <td>{{ asset.employee }}</td>
                      <td>
                        <Modal modal_title="ASSIGN ASSET" modal_id="assign_asset_to_employee">
                          <template slot="body">
                            <form method="post">
                              <input type="hidden" v-model="id">
                              <div class="mb-3">
                                <label class="text-uppercase form-label"
                                  >Asset
                                </label>
                                <div>{{assetToAssign.assetName}}</div>
                              </div>
                              <!-- <div class="mb-3">
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
                                    Choose location
                                  </option>
                                  <option v-for="assetRefValue in assetRefValues.locations" 
                                          v-if="assetRefValue !== null"
                                          :key="assetRefValue.locations"
                                          :value="assetRefValue" >
                                    {{assetRefValue}}
                                  </option>
                                </select>
                                <div class="invalid-feedback">
                                <span v-if="!$v.location.required">You must pick a location.</span>
                                </div>
                              </div> -->
                              <div class="mb-3">
                                <label class="text-uppercase form-label" for="name"
                                  >Employee name
                                  <span class="text-danger">*</span>
                                </label
                                >
                                <select
                                  class="form-control form-select form-select-sm form-modal"
                                  type="select"
                                  id="name"
                                  placeholder="Employee name"
                                  v-model.trim="$v.employee.$model"
                                  :class="{'is-invalid':$v.employee.$error, 'is-valid':!$v.employee.$invalid }"
                                >
                                  <option value="" selected>
                                    Choose employee
                                  </option>
                                  <option v-for="employee in employees" 
                                          v-if="employee.name !== null" 
                                          :key="employee.rowKey" 
                                          :value="employee.rowKey">
                                  {{employee.name}} {{employee.lastName}}
                                  </option>
                                </select>
                                <div class="invalid-feedback">
                                  <span v-if="!$v.employee.required">You must choose employee.</span>
                                </div>
                              </div>
                            </form>
                          </template>
                          <template slot="footer">
                            <button @click="assignAsset()" class="btn btn-primary">
                              Assign
                            </button>
                          </template>
                        </Modal>
                        <button class="me-3 text-lg text-success" @click="openAssignAssetForm(asset)">
                          <i class="fas fa-edit"></i>
                        </button>
                        <button class="text-lg text-danger" @click="deleteAsset(asset.id)">
                          <i class="fas fa-trash-alt"></i>
                        </button>
                      </td>
                      <td>
                        <button @click="openMapModal(asset.assetName)">
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
        <div v-else > No geographical data for this asset! </div>
      </template>
    </Modal>
  </div>
</template>

<script>
import axios from "axios";
import { required, minLength, alphaNum, numeric} from 'vuelidate/lib/validators'
import Modal from './Modal.vue';
import Map from '@/components/Map.vue'

export default {
  name: "AssetsDatatable",
  components: {
    Modal,
    Map
  },
  data() {
    return {
      reason: "",
      assets: [],
      assetToAssign:'',
      employee: "",
      employees: [],
      name:"",
      search:"",
      assetRefValues: [],
      assetCategory: "",
      assetType: "",
      vendor: "",
      assetName: "",
      serialNumber: "",
      price: "",
      location: "",
      purchaseDate: "",
      warrantyExpiryDate: "",
      purchaseType: "",
      submitStatus: null,
      id:'',
      selected:{employees:''},
      employeeId:'',
      departmentId:'',
      departmentName:'',
      mapData: [],
    
    };
  },
  validations:{
    assetCategory: {required},
    employee: {required},
    assetType: {required},
    vendor: {required},
    assetName: { required, minLength: minLength(3) },
    serialNumber: { required, alphaNum},
    price: { required, numeric },
    location: {required},
    purchaseDate: {required},
    purchaseType: {required},
    name: {required}
  },
  methods: {
    say: function (message) {
      this.reason = message;
    },
    getAllAssets: function () {
      var self = this;
      let options = { 
          headers: {
              Authorization: "Bearer " + localStorage.userToken
          }
      };
      axios
        .get('https://internship2021-api.mss.ba/api/Assets', options)
        .then(function (response) {
          self.assets = response.data;
          if(this.search){
            this.assets = response.data.filter(assets =>{
              assets.assetName.toLowerCase().includes(this.search.toLowerCase())
            })
          } else{
            this.search = response.data;
          }
        })
        .catch(function (error) {
          // handle error
          console.log(error);
        });

    },
    addNewAsset() {
      let form = {
        assetCategory: this.assetCategory,
        assetType: this.assetType,
        vendor: this.vendor,
        assetName: this.assetName,
        serialNumber: this.serialNumber,
        price: parseFloat(this.price),
        location: this.location,
        purchaseDate: this.purchaseDate,
        warrantyExpiryDate: this.warrantyExpiryDate,
        purchaseType: this.purchaseType,
      };


        let options = { 
          headers: {
            Authorization: "Bearer " + localStorage.userToken
          }
        };
            this.$v.$touch()
              if(this.$v.$invalid){
                this.submitStatus = "Request failed."
              }

      axios
        .post('https://internship2021-api.mss.ba/api/Assets', form, options)
        .then((response) => {
          this.getAllAssets();
          this.assetCategory= "";
          this.assetType = "";
          this.vendor = "";
          this.assetName = "";
          this.serialNumber = "";
          this.price = "";
          this.location = "";
          this.purchaseDate = "";
          this.warrantyExpiryDate = "";
          this.purchaseType = "";
          this.$v.$reset();
          this.submitStatus = "";

          if(response.status === 200){
            this.$root.$emit('modal_close');
          } 
        })
        .catch((error) => {
          console.log(error);
        });

        
    },
    openAssignAssetForm(asset){
      this.assetToAssign = asset;
      this.$root.$emit('assign_asset_to_employee_open')
    },
    getAssetRefValues(){
      var self = this;
      let options = { 
          headers: {
              Authorization: "Bearer " + localStorage.userToken
          }
        };

      axios
        .get('https://internship2021-api.mss.ba/api/Assets/getAssetRefValues', options)
        .then(function (response) {
          // handle success
          // this.assets=response.data;
          self.assetRefValues = response.data;
        })
        .catch(function (error) {
          // handle error
          console.log(error);
        });
    },
    getEmployees(){
      var self = this;
      let options = { 
          headers: {
              Authorization: "Bearer " + localStorage.userToken
          }
        };

      axios
        .get('https://internship2021-api.mss.ba/api/Database/employees', options)
        .then(function (response) {
          self.employees = response.data;
        })
        .catch(function (error) {
          console.log(error);
        });
    },
    assignAsset(){   
      // let aDepartment = this.departments.find((x) => x.departmentName === aEmployee.department);

      let form = {
        employeeId : this.employee
        // employeeId: employeeId.rowKey,
        // departmentId: aDepartment.rowKey
      };
      let options = { 
        headers: {
          Authorization: "Bearer " + localStorage.userToken
        }
      };

      axios.put('https://internship2021-api.mss.ba/api/Assets/' + this.assetToAssign.id, form, options)
            .then(response => {
                this.getAllAssets();

                if(response.status === 200 ){
                  this.$root.$emit('modal_close');
                } 
            })
            .catch((error) => {
                console.log(error);
            })
    },
    deleteAsset(id){
      let options = { 
        headers: {
          Authorization: "Bearer " + localStorage.userToken
        }
      };
            axios.delete('https://internship2021-api.mss.ba/api/Assets/' + id, options)
            .then((result)=>{
                this.getAllAssets();
            })
            .catch((error) => {
                console.log(error);
            })
        },
    openMapModal(assetName) {
      let selectedAsset = assetName;
      this.getMapData(selectedAsset);
    },
    
    getMapData(selectedAssetProp) {
      let self = this;
      axios.get('https://internship2021-gw.mss.ba/data/' + selectedAssetProp)
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
    this.getAllAssets();
    this.getAssetRefValues();
    this.getEmployees();
  },
};
</script>

<style>
div {
  display: block;
}
.container,
.container-fluid,
.container-lg,
.container-md,
.container-sm,
.container-xl,
.container-xxl {
  width: 100%;
  margin-right: auto;
  margin-left: auto;
  overflow: hidden;
}
.page-header {
  margin-bottom: 3rem;
  margin-top: 3%;
  margin-left: 0 !important;
}
.error-msg{
    color: rgb(238, 0, 0);
}
.align-items-center {
  align-items: center !important;
}
.justify-content-between {
  justify-content: space-between !important;
}
.d-flex {
  display: flex !important;
}
.page-header {
  margin-bottom: 3rem;
}
.align-items-center {
  align-items: center !important;
}
.justify-content-between {
  justify-content: space-between !important;
}
.d-flex {
  display: flex !important;
}
.page-heading {
  text-transform: uppercase;
  letter-spacing: 0.2em;
  font-weight: 300;
  font-size: 45px;
}
.text-sm {
  font-size: 0.7875rem !important;
}
.list-inline,
.list-unstyled {
  list-style: none;
}
dl,
ol,
ul {
  margin-top: 0;
  margin-bottom: 1rem;
}
.list-inline-item {
  display: inline-block;
}
.text-gray-600 {
  color: #6c757d !important;
}
.text-uppercase {
  text-transform: uppercase !important;
  letter-spacing: 0.2em;
}
.btn-primary {
  color: #fff;
  background-color: #4650dd;
  border-color: #4650dd;
}
.btn {
  display: inline-block;
}
select {
  font-family: "Poppins", sans-serif;
}
.form-modal {
  font-size: 14px;
  padding: 8px;
  color: #6c757d;
}
.mb-4 {
  margin-bottom: 3rem !important;
  overflow: hidden;
  position: relative;
}
.nav {
  margin-left: 0;
  flex-wrap: wrap;
  padding-left: 0;
  margin-bottom: 0;
  list-style: none;
  overflow: hidden;
}
.nav-tabs {
  border-bottom: 1px solid #dee2e6;
}
.nav-tabs .nav-item.show .nav-link,
.nav-tabs .nav-link.active {
  border-bottom-width: 5px;
  margin-bottom: -3px;
}
.nav-tabs .nav-item.show .nav-link,
.nav-tabs .nav-link.active {
  color: #4650dd;
  background-color: transparent;
  border-color: transparent transparent #4650dd;
}
.nav-link {
  display: block;
  padding: 0.5rem 1rem;
  color: #4650dd;
  transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out,
    border-color 0.15s ease-in-out;
}
.nav-tabs .nav-link {
  border-left-width: 0;
  border-right-width: 0;
  background: none;
}
button,
select {
  text-transform: none;
}
button {
  border-radius: 0;
}
[type="button"]:not(:disabled),
[type="reset"]:not(:disabled),
[type="submit"]:not(:disabled),
button:not(:disabled) {
  cursor: pointer;
}
[type="button"],
[type="reset"],
[type="submit"],
button {
  -webkit-appearance: button;
}
.nav-tabs .nav-link:focus,
.nav-tabs .nav-link:hover {
  isolation: isolate;
}
button:focus:not(:focus-visible) {
  outline: 0;
}
.nav-link:focus,
.nav-link:hover {
  color: #212bb5;
  text-decoration: none;
}
button,
input,
optgroup,
select,
textarea {
  margin: 0;
  font-family: inherit;
  font-size: inherit;
  line-height: inherit;
}
.card-table {
  margin-left: 0 !important;
}
.card {
  margin-top: 1.5%;
  border: none;
  box-shadow: 0 0.5rem 1rem rgb(0 0 0 / 15%);
  flex-direction: column;
  min-width: 0;
  word-wrap: break-word;
  border-radius: 1rem;
}
.card-header:first-child {
  border-radius: calc(1rem - 1px) calc(1rem - 1px) 0 0;
}
.card-header {
  padding: 2rem;
  border-bottom: none;
  background-color: #fff;
  box-shadow: 0 0.125rem 0.25rem rgb(0 0 0 / 8%);
  margin-bottom: 0;
}
.card-heading {
  margin-bottom: 0;
  font-size: 0.9rem;
  font-weight: 400;
  text-transform: uppercase;
  letter-spacing: 0.2em;
}
h4 {
  display: block;
  margin-block-start: 1.33em;
  margin-block-end: 1.33em;
  margin-inline-start: 0px;
  margin-inline-end: 0px;
}
.mb-4 {
  margin-bottom: 1.5rem !important;
}
.dataTable-wrapper {
  background: #f8f9fa;
  overflow-x: auto;
  max-width: 100%;
}
.dataTable-top {
  font-size: 0.7875rem;
  padding: 2rem;
  background: #f8f9fa;
}
.dataTable-dropdown > div:last-child {
  float: right;
}
label {
  display: inline-block;
  cursor: default;
}
.dataTable-selector {
  display: inline !important;
  width: auto;
}
.form-select-sm {
  padding-top: 0.25rem;
  padding-bottom: 0.25rem;
  padding-left: 0.5rem;
  font-size: 0.7875rem;
}
.form-select {
  padding: 0.2rem 1.25rem 0.3rem 0.5rem;
  font-weight: 400;
  line-height: 1.5;
  color: #343a40;
  background-color: #fff;
  background-repeat: no-repeat;
  background-position: right center;
  background-size: 16px 12px;
  border: 1px solid #ced4da;
}
.dataTable-input.form-control-sm {
  padding: 0.25rem 0.5rem;
}
select {
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
.dataTable-container {
  border: 0;
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
  vertical-align: middle !important;
}
.border-0 {
  border: 0 !important;
}
.table > thead {
  vertical-align: bottom;
}
tbody,
td,
tfoot,
th,
thead,
tr {
  border: 0 solid;
  border-color: inherit;
}
.card-table .table tr td:first-child,
.card-table .table tr th:first-child {
  padding-left: 2rem;
}
.table > :not(:last-child) > :last-child > {
  border-bottom-color: currentColor;
}
.card-table thead th {
  letter-spacing: 0.1em;
  text-transform: uppercase;
  color: #fff;
  background: #343a40;
  font-size: 13px;
}
a.dataTable-sorter {
  color: white;
  text-decoration: none;
}
.card-table .dataTable-bottom {
  padding: 2rem;
  background: #f8f9fa;
  margin-bottom: 2%;
}
.dataTable-bottom > nav:last-child {
  float: right;
}
nav {
  display: block;
}
.dataTable-bottom > div:first-child {
  float: left;
}
.dataTable-info {
  margin: 7px 0;
}
.text-lg {
  font-size: 1.125rem !important;
}
.text-success,
.text-success-hover:hover {
  color: seagreen !important;
}
.me-3 {
  margin-right: 1rem !important;
}
@media (min-width: 992px) {
  .px-lg-4 {
    padding-right: 1.5rem !important;
    padding-left: 1.5rem !important;
  }
}
@media (min-width: 1200px) {
  .px-xl-5 {
    padding-right: 3rem !important;
    padding-left: 3rem !important;
  }
}
</style>