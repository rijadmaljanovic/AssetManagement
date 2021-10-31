<template>
<!-- <line-chart :data="chartData"></line-chart> -->
<div class="card">
    <div class="card-header">
        <h4 class="card-heading">Column chart</h4>
    </div>
    <div class="card-body">
       <column-chart :data="[['Vendors', countVendors], ['Products', countProducts], ['Assets', countAssets], ['Employees', countEmployees]]" :colors="['#6610f2', '#a370f7']"></column-chart>
    </div>

</div>

</template>

<script>

export default {
  props: ["countVendors", "countProducts", "countAssets", "countEmployees"]

}

</script>


<style scoped>
.card {
    margin-top: 1.5%;
    border: none;
    box-shadow: 0 0.5rem 1rem rgb(0 0 0 / 15%);
    position: relative;
    display: flex;
    min-width: 0;
    word-wrap: break-word;
    background-color: #fff;
    background-clip: border-box;
    border-radius: 1rem;
    width: 55%;
    height: 450px;
}

</style>