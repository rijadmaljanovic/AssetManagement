<template>
<!-- <line-chart :data="chartData"></line-chart> -->
<div class="card">
    <div class="card-header">
        <h4 class="card-heading">Pie chart: Products by Product Types</h4>
    </div>
    <div class="card-body">
        <pie-chart :data="productListByTypeCount" :colors="['#6610f2', '#8540f5', '#a370f7', '#c29ffa', '#B0C4DE', '#7F00FF', '#C3B1E1', '#AA98A9', '#E6E6FA', '#89CFF0','#B9D9EB']"></pie-chart>
    </div>

</div>

</template>

<script>

export default {
  props: ["productListByTypeCount"]

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
    width: 40%;
    height: 450px;
}



</style>