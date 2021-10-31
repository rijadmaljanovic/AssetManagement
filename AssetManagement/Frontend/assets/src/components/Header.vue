<template>
    <header>
        <nav class="px-4 py-2 shadow navbar navbar-expand-lg bg-white">
            <Burger/>
            <div>
                    <a href="/home" class="fw-bold text-uppercase text-base navbar-brand"><span class="d-none d-sm-inline">ASSETS MANAGEMENT</span></a>
                </div>
            
            <div class="ms-auto d-flex align-items-center mb-0 test">
                
                <div class="ms-auto show dropdown nav-item">
                    <a href="#" class="pe-0 dropdown-toggle nav-link" role="button">
                        <div class="avatar">
                            <div class="position-relative overflow-hidden rounded-circle h-100 d-flex align-items-center justify-content-center">
                                <div class="imgdiv">
                                    <img alt="Jason Doe" src="https://www.shareicon.net/data/512x512/2016/05/24/770137_man_512x512.png" class="rounded-circle image">
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </nav>  
    </header>
</template>

<script>
import Burger from '@/components/Burger.vue'

export default{
    name: 'Header',
    components: {
        Burger,
    }
}
</script>

<style scoped>
    header{
        display: block;
        height: 20%;
        width: 100%;
    }

    .navbar {
        position: relative;
        display: flex;
        flex-wrap: wrap;
        align-items: center;
        justify-content: space-between;
    }   

    .navbar .navbar-brand {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%,-50%);
    }


    a{
        color: #4650dd;
    }

    .rounded-circle{
        border-radius: 50%!important;
    }

    .ms-auto{
        margin-left: auto!important;
    }

    .mb-0{
        margin-bottom: 0!important;
    }

    .align-items-center{
        align-items: center!important;
    }

    .d-flex{
        display: flex!important;
    }


    .text-base{
        font-size: .9rem!important;
    }

    .text-uppercase{
        letter-spacing: .2em;
    }

    .fw-bold{
        font-weight: 700!important;
    }

    .navbar-brand{
    padding-top: .33125rem;
    padding-bottom: .33125rem;
    margin-right: 1rem;
    font-size: 1.125rem;
    text-decoration: none;
    white-space: nowrap;
    }

    .pe-0{
        padding-right: 0!important;
    }

    .dropdown-toggle{
            white-space: nowrap;
    }

    .dropdown-toggle::after{
        display: none;
    }
   
   [role=button]{
       cursor: pointer;
   }

   .avatar{
        display: inline-block;
        position: relative;
        width: 3rem;
        height: 3rem;
        text-align: center;
        border: #dee2e6;
        border-radius: 50%;
        background: #fff;
        box-shadow: 0 0.5rem 1rem rgb(0 0 0 / 15%);
        line-height: 3rem;
   }

   .marginleft{
        margin-left: 550px;
   }

   .imgdiv{
       overflow:hidden;
       box-sizing:border-box;
       display:inline-block;
       position:relative;
       width:40px;
       height:40px
   }

   .image{
       position:absolute;
       top:0;
       left:0;
       bottom:0;
       right:0;
       box-sizing:border-box;
       padding:0;
       border:none;
       margin:auto;
       display:block;
       width:0;
       height:0;
       min-width:100%;
       max-width:100%;
       min-height:100%;
       max-height:100%
   }

   
</style>