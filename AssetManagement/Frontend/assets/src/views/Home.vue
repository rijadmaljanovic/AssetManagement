<template>
  <div class="Home">
    <Header></Header>
    <Sidebar></Sidebar>
    <div class="charts">
      <Chart1 class="chartSingle" :countAssets="countAssets" :countAssignedAssets="countAssignedAssets"></Chart1>
      <Chart3 class="chartSingle chartSingleMiddle" :productListByTypeCount="productListByTypeCount"></Chart3>
    </div>
    <div class="charts">
      <Chart2 class="chartSingle" :countVendors="countVendors" :countProducts="countProducts" :countAssets="countAssets" :countEmployees="countEmployees"></Chart2>
    </div>
   
    <Footer></Footer>
  </div>
</template>

<script>
import Header from '@/components/Header.vue'
import Sidebar from '@/components/Sidebar.vue'
import Footer from '@/components/Footer.vue'
import Card from '@/components/Card.vue'
import Chart1 from '@/components/charts/Chart1.vue'
import Chart2 from '@/components/charts/Chart2.vue'
import Chart3 from '@/components/charts/Chart3.vue'
import axios from 'axios'


export default {
  name: 'home',
  components: {
    Header,
    Sidebar,
    Footer,
    Card,
    Chart1,
    Chart2,
    Chart3
  },

  data(){
    return {
      countAssets: 0,
      countAssignedAssets: 0,
      countVendors: 0,
      countProducts: 0,
      countEmployees: 0,
      products: [],
      pTypes: [],
      productListByType: [],
      productListByTypeCount: []
    }
  },
  methods: {
    getChartData1(){
        //GET ASSETS
        let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
            };

        axios.get('https://internship2021-api.mss.ba/api/Assets', options)
        .then((response) => {
                 
                let assets = response.data;
                this.countAssets = assets.length;
            })
            .catch((error) => {
                console.log(error);
            })


        //GET ASSIGNED ASSETS
        
        axios.get('https://internship2021-api.mss.ba/api/Reports/assignedAssets')
        .then((response) => {
                 
                let assignedAssets = response.data;
                this.countAssignedAssets = assignedAssets.length;
            })
            .catch((error) => {
                console.log(error);
            })
        },

      getChartData2(){
        //GET EMPLOYEES
        let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
        };

        axios.get('https://internship2021-api.mss.ba/api/Database/employees', options)
        .then((response) => {
                 
                let employees = response.data;
                this.countEmployees = employees.length;
            })
            .catch((error) => {
                console.log(error);
            })

        //GET PRODUCTS
        axios.get('https://internship2021-api.mss.ba/api/Product', options)
        .then((response) => {
                 
                let products = response.data;
                this.countProducts = products.length;
            })
            .catch((error) => {
                console.log(error);
            })

        //GET VENDORS
        axios.get('https://internship2021-api.mss.ba/api/Vendor', options)
        .then((response) => {
                 
                let vendors = response.data;
                this.countVendors = vendors.length;
            })
            .catch((error) => {
                console.log(error);
            })
      },

      getChartData3(){
        //GET PRODUCT TYPES
         let options = { 
                headers: {
                    Authorization: "Bearer " + localStorage.userToken
                }
        };
        
        axios.get('https://internship2021-api.mss.ba/api/Reports/productTypes', options)
        .then((response) => {      
          this.pTypes = response.data;
        })
        .catch((error) => {
          console.log(error);
        })

        //GET PRODUCTS

        axios.get('https://internship2021-api.mss.ba/api/Product', options)
        .then((response) => {             
          this.products = response.data;
          this.FindProductsByProductTypes();
          this.CountPTypes();
        })
        .catch((error) => {
          console.log(error);
        })
      },

      FindProductsByProductTypes() {
        this.pTypes.forEach((type) => {
          this.productListByType[type.productTypeName] = [];

          this.products.forEach((product) => {
            if(type.productTypeName === product.productType){
              this.productListByType[type.productTypeName].push(product);
            }
          });
        });
      },

      CountPTypes() {
        this.pTypes.forEach((type) => { 
          this.productListByTypeCount.push([type.productTypeName, this.productListByType[type.productTypeName].length]);
        })
      }
    },
      mounted() {
        this.getChartData1();
        this.getChartData2();
        this.getChartData3();
    }
  }

</script>

<style>
p{
  margin-top: 0;
  margin-bottom: 1rem;
}

.charts{
  display: flex;
  flex-flow: row wrap;
  margin-bottom: 50px;
  margin-top: 50px;
  justify-content: space-around;
}

@media (max-width: 480px) {
    .charts {
      padding: 0 12px;
      flex-direction: column;
    }

    .chartSingle {
      width: 100% !important;
    }

    .chartSingleMiddle {
      margin-top: 50px !important;
    }
}
</style>