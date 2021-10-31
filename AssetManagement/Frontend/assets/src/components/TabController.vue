<template>
  <div class="wrapper">
    <Tabs class="tabController">
    <TabItem name="Locations">
      <div class="tab"><LocationsTable/></div>
    </TabItem>
    <TabItem name="Departments">
      <div class="tab"><DepartmentsTable/></div>
    </TabItem>
    <TabItem name="Product Category">
      <div class="tab"><ProductsCategories/></div>
    </TabItem>
    <TabItem name="Product Type">
      <div class="tab"><ProductsTypes/></div>
    </TabItem>
    <TabItem name="Asset Category">
      <div class="tab"><AssetsCategories/></div>
    </TabItem>
    <TabItem name="Asset Type">
      <div class="tab"><AssetsTypes/></div>
    </TabItem>
    <TabItem name="Employees">
      <div class="tab"><EmployeesTable/></div>
    </TabItem>
    </Tabs>
  </div>
</template>

<script>
import { Tabs, TabItem } from "vue-material-tabs";
import LocationsTable from "./databaseTables/LoactionsTable.vue"
import DepartmentsTable from "./databaseTables/DepartmentsTable.vue"
import ProductsCategories from "./databaseTables/ProductsCategories.vue"
import AssetsTypes from "./databaseTables/AssetsTypes.vue"
import EmployeesTable from "./databaseTables/EmployeesTable.vue"
import ProductsTypes from "./databaseTables/ProductsTypes.vue"
import AssetsCategories from "./databaseTables/AssetsCategories.vue"

export default {
    name: 'TabController',
    components:{
        Tabs,
        TabItem,
        LocationsTable,
        DepartmentsTable,
        ProductsCategories,
        AssetsTypes,
        EmployeesTable,
        ProductsTypes,
        AssetsCategories
    }
}
</script>

<style>
.wrapper{
    margin-top: 2%;
}
.tab{
    margin-top: 2%;
    margin-left: 2%;
}
.display{
  display: inherit;
}
</style>