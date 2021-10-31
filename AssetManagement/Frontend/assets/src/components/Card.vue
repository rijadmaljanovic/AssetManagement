<template>
    <div class="mb-4 col-xl-3 col-md-6 card-margin">
        <div class="card-widget h-100">
            <div class="card-widget-body">
                <div class="dot me-3 bg-indigo"></div>
                <div class="text">
                    <h6 class="mb-0">Assets</h6>
                    <span class="text-gray-500">Assets</span>
                </div>
            </div>
            <div class="icon text-white bg-indigo">
                <i class="fas fa-layer-group fa-2x"></i>
            </div>
        </div>

    </div>
</template>

<script>
    export default {
        name: 'Card',
    }
</script>

<style scoped>
.mb-4{
    margin-bottom: 1.5rem!important;
}

.card-widget, .card-widget-body{
    display: flex;
    align-items: center;
}

.card-widget{
    background: #fff;
    -webkit-box-shadow: 0 0.5rem 1rem rgb(0 0 0 / 15%);
    box-shadow: 0 0.5rem 1rem rgb(0 0 0 / 15%);
    justify-content: space-between;
    border-radius: 50rem;
    padding: 1.5rem;
}

.h-100{
    height: 100%!important;
}

.card-widget-body{
    flex-grow: 1;
}

.dot{
    width: 10px;
    height: 10px;
    border-radius: 50%;
    flex-grow: 0;
    flex-shrink: 0;
}

.bg-indigo{
    background-color: #6610f2!important;
}

.me-3{
    margin-right: 1rem!important;
}

.mb-0{
    margin-bottom: 0!important;
}

.h6, h6{
    font-size: .9rem;
    margin-top: 0;
    font-weight: 700;
    line-height: 1.2;
}

.text-gray-500{
    color: #adb5bd!important;
}

.icon{
    display: flex;
    width: 2.6rem;
    height: 2.6rem;
    flex-shrink: 0;
    border-radius: 50%;
    align-items: center;
    justify-content: center;
}

.bg-indigo{
    background-color: #6610f2!important;
}

.card-margin{
    margin: 50px 0 0 350px;
}

</style>
