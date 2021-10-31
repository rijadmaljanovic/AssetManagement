<template>
    <div class="d-flex align-items-stretch">
        <div class="page-holder page-holder align-items-center py-4 bg-gray-100 vh-100">
            <div class="container">
                <div class="align-items-center">
                    <div class="px-lg-4 col-lg-6">
                        <div class="card">
                            <div class="px-lg-5 card-header">
                                <div class="card-heading text-primary">Asset management login</div>
                            </div>
                            <div class="p-lg-5 card-body">
                                <h3>Hi, welcome back! 👋👋</h3>
                                <p class="text-muted text-sm mb-5">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.
                                </p>
                                <span class="error-msg">{{submitStatus}}</span>
                                <form @submit.prevent="login()" class="row" action="/Login" method="post">
                                <div class="form-floating mb-3">
                                    <input type="text" id="username" class="form-control" placeholder="Username" 
                                    v-model.trim="$v.userName.$model" :class="{'is-invalid':$v.userName.$error, 'is-valid':!$v.userName.$invalid }">
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.userName.required">Username is required.</span>
                                    </div>
                                    <label class="form-label" for="username">&nbsp;&nbsp;&nbsp;&nbsp;Username
                                        <span class="text-danger">*</span>
                                    </label>
                                </div>
                                <div class="form-floating mb-3">
                                    <input type="password" id="password" class="form-control" placeholder="Password"
                                    v-model.trim="$v.password.$model" :class="{'is-invalid':$v.password.$error, 'is-valid':!$v.password.$invalid }">
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.password.required">Password is required.</span>
                                    </div>
                                    <label class="form-label" for="password">&nbsp;&nbsp;&nbsp;&nbsp;Password
                                        <span class="text-danger">*</span>
                                    </label>
                                </div>
                                <div class="mb-3 form-check">
                                    <input type="checkbox" id="agree" v-model="checked">
                                    <label for="agree" class="form-check-label">&nbsp;Remember me</label>
                                </div>
                                <button id="login" type="submit" class="btn btn-primary btn-lg">Login</button>
                                </form>
                            </div>
                            <div class="px-lg-5 py-lg-4 card-footer">
                                <div class="text-sm text-muted">
                                    Don't have an account?
                                    <a href="/register">Register</a>
                                    .
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {required} from 'vuelidate/lib/validators'

export default {
    data() {
        return{
            userName: '',
            password: '',
            checked: '',
            submitStatus: null,
            error:[]
        }
    },
    validations: {
        userName: {
            required,
        },
        password:{
            required,
        },
    },
    methods: {
        async login() {
            console.log("logging in")
            var body= {
                "username":this.userName, 
                "password":this.password
            }

            this.$v.$touch()
            if(!this.$v.$invalid){
                

            this.$request
            .post('/Login', JSON.stringify(body))
            .then((res) => {
                if (res.data && res.data.length > 0) {
                    let tokenData = this.parseJwt(res.data);
                    let userId = tokenData.id.replace(/-/g, '');
                    let date = new Date(tokenData.exp * 1000);

                    localStorage.setItem("userToken", res.data);
                    localStorage.setItem("userId", userId);
                    localStorage.setItem("expirationToken", date)

                    this.$router.push({name: 'home'});
                }
            })
            .catch((error) => {
                if (error.status) {
                    if(error.status === 401){
                        this.submitStatus = "Incorrect password or username"
                    }
                }
                else {
                    console.log(error);
                }
            })
            } else{
                this.submitStatus = "Incorrect password or e-mail!"
            }
        },
        parseJwt (token) {
            var base64Url = token.split('.')[1];
            var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
            }).join(''));

            return JSON.parse(jsonPayload);
        }
        
    }
}

</script>

<style scoped>
*{
    box-sizing: border-box;
    margin: auto;
}
.mb-4 {
    margin-bottom: 1.5rem!important;
}
.h3, h3 {
    font-size: calc(1.2825rem + .39vw);
    font-family: 'Poppins', sans-serif;
    font-weight: bold;
}
.container{
    width: 100%;
    padding-right: var(--bs-gutter-x,1rem);
    padding-left: var(--bs-gutter-x,1rem);
    position: relative;
    margin-left: 2%;
}
.error-msg{
    color: rgb(238, 0, 0);
}
.text-sm {
    font-size: .7875rem!important;
}
.text-muted {
    --bs-text-opacity: 1;
    color: #6c757d!important;
}
.fa-eye{
    float: right;
}
.mb-5 {
    margin-bottom: 3rem!important;
    margin-left: 0;
}
p {
    margin-top: 0;
    margin-bottom: 1rem;
    font-family: 'Poppins', sans-serif;
}
.page-holder{
    display: flex;
    overflow-x: hidden;
    width: 100%;
    min-height: calc(100vh - 72px);
}

.bg-gray-100{
    background-color: #f8f9fa!important;
}

.py-4{
    padding-top: 1.5rem!important;
    padding-bottom: 1.5rem!important;
}

.align-items-center{
    align-items: center!important;
}

.row{
    display: flex;
    flex-wrap: wrap;
    margin-top: calc(var(--bs-gutter-y) * -1);
    margin-right: calc(var(--bs-gutter-x) * -.5);
    margin-left: calc(var(--bs-gutter-x) * -.5);
}

.vh-100{
    height: 100vh!important;
}
.card{
    position: relative;
    display: flex;
    flex-direction: column;
    min-width: 0;
    word-wrap: break-word;
    background-color: #fff;
    background-clip: border-box;
    border-radius: 1rem;
    border: none;
    box-shadow: 0 0.5rem 1rem rgb(0 0 0 / 15%);
}
.card-header:first-child{
    border-radius: calc(1rem - 1px) calc(1rem - 1px) 0 0;
}

.card-header{
    position: relative;
    padding: 2rem;
    border-bottom: none;
    background-color: #fff;
    box-shadow: 0 0.125rem 0.25rem rgb(0 0 0 / 8%);
    z-index: 2;
}

.card-heading{
    margin-bottom: 0;
    font-size: .9rem;
    font-weight: 400;
    text-transform: uppercase;
    letter-spacing: .2em;
}

.text-primary{
    color: #4650dd!important;
    --bs-text-opacity: 1;
}

.card-body{
    flex: 1 1 auto;
}

h3{
    font-weight: 700;
    line-height: 1.2;
    margin-bottom: 30px;
}

.mb-3{
    margin-bottom: 1rem!important;
}

.form-floating{
    position: relative;
}

.form-control{
    display: inline;
    width: 100%;
    font-size: .9rem;
    font-weight: 400;
    color: #343a40;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid #ced4da;
    appearance: none;
    border-radius: .25rem;
    padding: 25px;
}

.form-check{
    display: block;
    min-height: 1.35rem;
}

.form-check .form-check-input{
    float: left;
}

.form-check-input{
    width: 1em;
    height: 1em;
    margin-top: .25em;
    vertical-align: top;
    background-color: #fff;
    background-repeat: no-repeat;
    background-position: 50%;
    background-size: contain;
    border: 1px solid rgba(0,0,0,.25);
}

.btn-primary{
    color: #fff;
    background-color: #4650dd;
    border-color: #4650dd;
}

.btn-lg {
    padding: .5rem 1rem;
    font-size: 1.125rem;
    border-radius: .4rem;
}

a{
    color: #4650dd;
}

.text-center{
    text-align: center!important;
}



</style>
