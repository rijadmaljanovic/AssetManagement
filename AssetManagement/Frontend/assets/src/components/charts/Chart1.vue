<template>
<!-- <line-chart :data="chartData"></line-chart> -->
<div class="card">
    <div class="card-header">
        <h4 class="card-heading">Pie chart: Assets & Assigned Assets</h4>
    </div>
    <div class="card-body">
        <pie-chart :data="[['Assets', countAssets], ['Assigned Assets', countAssignedAssets]]" :colors="['#6610f2', '#a370f7']" :donut="true"></pie-chart>
    </div>

</div>

</template>

<script>

export default {
  props: ["countAssets", "countAssignedAssets" ],

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
    width: 35%;
    height: 450px;
}

</style>