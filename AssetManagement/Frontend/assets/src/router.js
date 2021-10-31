import Vue from 'vue'
import Router from 'vue-router'
import Login from './views/Login.vue'
import Home from './views/Home.vue'
import Vendor from './views/Vendor.vue'
import Assets from './views/Assets.vue'
import Products from './views/Products.vue'
import Register from './views/Register.vue'
import Reports from './views/Reports.vue'
import ReportAsset from './views/reports/ReportAsset.vue'
import ReportAssignedAssets from './views/reports/ReportAssignedAssets.vue'
import ReportVendor from './views/reports/ReportVendor.vue'
import ReportEmployees from './views/reports/ReportEmployees.vue'
import ReportDepartments from './views/reports/ReportDepartments.vue'
import ReportLocations from './views/reports/ReportLocations.vue'
import ReportProducts from './views/reports/ReportProducts.vue'
import ReportProductTypes from './views/reports/ReportProductTypes.vue'
import Database from './views/Database.vue'


Vue.use(Router)

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            redirect: '/login',
        },
        {
            path: '/login',
            name: 'login',
            component: Login,
        },
        {
            path: '/home',
            name: 'home',
            component: Home,
        },
        {
            path: '/vendor',
            name: 'vendor',
            component: Vendor
        },
        {
            path: '/assets',
            name: 'assets',
            component: Assets
        },
        {
            path: '/products',
            name: 'products',
            component: Products
        },
        {
            path: '/register',
            name: 'register',
            component: Register
        },
        {
            path: '/reports',
            name: 'reports',
            component: Reports
        },
        {
            path: '/database',
            name: 'database',
            component: Database
        },
        {
            path: '/reportasset',
            name: 'reportasset',
            component: ReportAsset
        },
        {
            path: '/reportassignedassets',
            name: 'reportassignedassets',
            component: ReportAssignedAssets
        },
        {
            path: '/reportvendor',
            name: 'reportvendor',
            component: ReportVendor
        },
        {
            path: '/reportemployees',
            name: 'reportemployees',
            component: ReportEmployees
        },
        {
            path: '/reportdepartments',
            name: 'reportdepartments',
            component: ReportDepartments
        },
        {
            path: '/reportlocations',
            name: 'reportlocations',
            component: ReportLocations
        },
        {
            path: '/reportproducts',
            name: 'reportproducts',
            component: ReportProducts
        },
        {
            path: '/reportproducttypes',
            name: 'reportproducttypes',
            component: ReportProductTypes
        },
    ]
})

