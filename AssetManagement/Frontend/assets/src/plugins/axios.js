import Vue from 'vue'
import axios from 'axios'

const request = axios.create({
    baseURL : 'https://internship2021-api.mss.ba/api',
    headers: {
        "access-control-allow-origin": "*",
        "Content-Type" : "application/json"
    }
})

Vue.prototype.$request = request;

export { request };