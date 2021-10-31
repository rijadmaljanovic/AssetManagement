<template>
<div class="d-flex align-items-stretch">
      <div class="sidebar-backdrop" @click="closeSidebarPanel" v-if="isPanelOpen">
        <transition class="slide">
          <div class="sidebar py-3 shrink show" id="sidebar">
            <div v-if="isPanelOpen" class="sidebar-panel">
                <h6 class="sidebar-heading">Main</h6>
                      <ul class="list-unstyled">
                        <li class="sidebar-item">
                          <router-link class="sidebar-link text-muted" to="home">
                            <i class="fas fa-home fa-2x"></i>
                            <h6 class="sidebar-link-title">Dashboard</h6>
                          </router-link>
                        </li>
                        <li class="sidebar-item">
                           <router-link class="sidebar-link text-muted" to="assets">
                            <i class="far fa-folder fa-2x"></i>
                            <h6 class="sidebar-link-title">Assets</h6>
                          </router-link>
                        </li>
                        <li class="sidebar-item">
                           <router-link class="sidebar-link text-muted" to="vendor">
                            <i class="fas fa-industry fa-2x"></i>
                            <h6 class="sidebar-link-title">Vendors</h6>
                          </router-link>
                        </li>
                        <li class="sidebar-item">
                           <router-link class="sidebar-link text-muted" to="products">
                            <i class="fas fa-layer-group fa-2x"></i>
                            <h6 class="sidebar-link-title">Products</h6>
                          </router-link>
                        </li>
                         <li class="sidebar-item">
                           <router-link class="sidebar-link text-muted" to="reports">
                           <i class="far fa-file-alt fa-2x"></i>
                            <h6 class="sidebar-link-title">Reports</h6>
                          </router-link>
                        </li>
                        <li class="sidebar-item">
                           <router-link class="sidebar-link text-muted" to="database">
                           <i class="fas fa-database fa-2x"></i>
                            <h6 class="sidebar-link-title">Database</h6>
                          </router-link>
                        </li>
                      </ul>
                    </div>
              
        </div>
      </transition>
        </div>
    </div>   
    
</template>

<script>
import { store, mutations } from '@/store.js'

export default {
    name: 'Sidebar',
    methods: {
            closeSidebarPanel: mutations.toggleNav
    },
    computed: {
        isPanelOpen() {
          return store.isNavOpen
        }
    } 
}
</script>

<style scoped>
  * {
    margin-left: 0;
    margin-right: auto;
  }
  .collapse:not(.show) {
    display: none;
}
.sidebar-menu {
    position: absolute;
    background: #f8f9fa;
    box-shadow: inset 4px -2px 0.25rem 0 rgb(0 0 0 / 8%);
    font-size: .7875rem;
    margin-left: 0;
    list-style: none;
}
  .text-muted {
    --bs-text-opacity: 1;
    color: #6c757d!important;
}
  .align-items-stretch {
    align-items: stretch!important;
  }
  div{
    display: block;
  }
  .sidebar{
    display: inline;
    font-size: 15px;
    position: absolute;
    height: 100%;
    width: 17%;
    /* text-align: left; */
    box-shadow: 0 0.5rem 1rem rgb(0 0 0 / 15%);
    background: white;
    z-index: 4;
  }
  
  .slide-fade-enter-active {
  transition: all 0.3s ease-out;
}

.slide-fade-leave-active {
  transition: all 0.8s cubic-bezier(1, 0.5, 0.8, 1);
}

.slide-fade-enter-from,
.slide-fade-leave-to {
  transform: translateX(20px);
  opacity: 0;
}
  .py-3{
    padding-top: 1rem!important;
    padding-bottom: 1rem!important;
  }
  .list-inline, .list-unstyled {
    padding-left: 0;
    list-style: none;
}
  ul {
    display: block;
    margin-block-start: 0em;
    margin-block-end: 1em;
    margin-inline-start: 0px;
    margin-inline-end: 0px;
    padding-inline-start: 40px;
  }
  .sidebar-link.active, .sidebar-link:focus {
    text-decoration: none;
    color: #fff!important;
    background: #4650dd;
}
  li {
    display: list-item;
  }
  li a{
    display: block;
  }
  .sidebar-link {
    display: flex;
    padding: .5rem 1.5rem;
    transition: background .3s;
    text-decoration: none;
    align-items: center;
}
  .sidebar-link-title {
    padding-top: 12px;
    display: inline-block;
    transition: all .3s;
    text-align: left;
    font-weight: lighter;
    margin: 0 5%;
    width: 70%;
  }
  .sidebar-heading {
    margin-bottom: 0;
    padding: 1.5rem;
    color: #adb5bd;
    font-size: .9000rem;
    font-weight: 700;
    text-transform: uppercase;
    letter-spacing: .2em;
    font-family: 'Poppins', sans-serif;
}
.sidebar-link.active, .sidebar-link:focus {
    text-decoration: none;
    color: #fff!important;
    background: #4650dd;
}
  h6{
    text-align: left;
    font-size: 15px;
    font-family: 'Poppins', sans-serif;
  }
  li a:hover {
    background-color: lightgrey;
    color: #000000;
  }
  li a:active{
    background-color: lightskyblue;
  }
  i{
    width: 20%;
  }
  @media (max-width: 1199.98px){
    .sidebar.show {
    margin-left: 0;
}
    .sidebar{
      transition: all .4s;
      margin-left: -6rem;
      position: absolute;
      height: 100vh;
      background: white;
      z-index: 4;
  }
  .sidebar-menu{
    position: absolute;
    height: 100%;
  }
  .sidebar-link{
    align-items: center;
  }
  .sidebar-heading {
    padding-right: .5rem;
    padding-left: .5rem;
    text-align: center;
  }
  .sidebar.shrink {
    width: 5.5rem;
    text-align: center;
}
.list-inline, .list-unstyled {
    padding-left: 0;
    list-style: none;
}
li {
    display: list-item;
}
.sidebar .sidebar-link {
    display: block;
    padding-right: .2rem;
    padding-left: 0rem;
}
.sidebar .sidebar-link i {
    margin: 0!important;
}
i{
  width: 24px;
    height: 24px;
    vertical-align: text-bottom;
    padding-right: 40px;
}
.sidebar .sidebar-link .sidebar-link-title {
    display: block;
    font-size: .75rem;
    text-align: center;
    padding-left: 0.3rem;
    
}
.sidebar-link-title {
    padding-top: 12px;
    display: block;
    transition: all .3s;
    text-align: center;
    font-weight: lighter;
  }
  }
  @media (max-width: 575.98px){
.sidebar.shrink .sidebar-link .sidebar-link-title {
    font-size: .85rem;
    text-align: center;
    align-items: center;
}
}
</style>