<template>
    <div class="d-flex align-items-stretch">
        <div class="page-holder page-holder align-items-center py-4 bg-gray-100 vh-100">
            <div class="container">
                <div class="align-items-center">
                    <div class="px-lg-4 col-lg-7">
                        <div class="card">
                            <div class="px-lg-5 card-header">
                                <div class="card-heading text-primary">Asset management register</div>
                            </div>
                            <div class="p-lg-5 card-body">
                                <h3 class="mb-4">Hi, ready to get started?</h3>
                                <p class="text-muted text-sm mb-5">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.
                                </p>
                                <span class="error-msg">{{submitStatus}}</span>
                                <form @submit.prevent="register()" class="row" action="/User" method="post">
                                <div class="col-sm-6 form-floating mb-3">
                                    <input class="form-control" placeholder="First name" type="text" id="name" 
                                    v-model.trim="$v.name.$model" :class="{'is-invalid':$v.name.$error, 'is-valid':!$v.name.$invalid }">
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.name.required">First name is required.</span>
                                        <span v-if="!$v.name.minLength">First name must have at least {{$v.name.$params.minLength.min}} letters.</span>
                                    </div>
                                    <label class="form-label" for="name">&nbsp;&nbsp;&nbsp;&nbsp;First name
                                        <span class="text-danger">*</span>
                                    </label> 
                                </div> 
                                <div class="col-sm-6 form-floating mb-3">
                                    <input placeholder="Last name" type="text" id="lastName" class="form-control" 
                                    v-model.trim="$v.lastName.$model" :class="{'is-invalid':$v.lastName.$error, 'is-valid':!$v.lastName.$invalid }">
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.lastName.required">Last name is required.</span>
                                        <span v-if="!$v.lastName.minLength">Last name must have at least {{$v.lastName.$params.minLength.min}} letters.</span>
                                    </div>
                                    <label class="form-label" for="lastName">&nbsp;&nbsp;&nbsp;&nbsp;Last name
                                        <span class="text-danger">*</span>
                                    </label> 
                                </div>
                                <div class="form-floating mb-3">
                                    <input type="text" id="username" class="form-control" placeholder="Username" 
                                    v-model.trim="$v.username.$model" :class="{'is-invalid':$v.username.$error, 'is-valid':!$v.username.$invalid }">
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.username.required">Username is required.</span>
                                        <span v-if="!$v.username.isUnique">This username is already in use.</span>
                                    </div>
                                    <label class="form-label" for="username">&nbsp;&nbsp;&nbsp;&nbsp;Username
                                        <span class="text-danger">*</span>
                                    </label>
                                </div>
                                <div class="col-sm-6 form-floating mb-3">
                                    <input type="password" id="password" class="form-control" placeholder="Password"
                                    v-model.trim="$v.password.$model" :class="{'is-invalid':$v.password.$error, 'is-valid':!$v.password.$invalid }">
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.password.required">Password is required.</span>
                                        <span v-if="!$v.password.minLength">Password must have at least {{$v.password.$params.minLength.min}} characters.</span>
                                    </div>
                                    <label class="form-label" for="password">&nbsp;&nbsp;&nbsp;&nbsp;Password
                                        <span class="text-danger">*</span>
                                    </label>
                                </div>
                                <div class="col-sm-6 form-floating mb-3">
                                    <input type="password" id="confirmPW" class="form-control" placeholder="Confirm password" 
                                    v-model.trim="$v.confirmPw.$model" :class="{'is-invalid':$v.confirmPw.$error, 
                                    'is-valid':(password != '') ? !$v.confirmPw.$invalid:''}">
                                    <div class="valid-feedback">Your passwords match!</div>
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.confirmPw.sameAsPassword">Passwords must be identical</span>
                                    </div>
                                    <label class="form-label" for="confirmPW">&nbsp;&nbsp;&nbsp;&nbsp;Confirm password
                                        <span class="text-danger">*</span>
                                    </label>
                                </div>
                                <div class="form-floating mb-3">
                                    <input placeholder="name@example.com" type="text" id="email" class="form-control" 
                                    v-model.trim="$v.email.$model" :class="{'is-invalid':$v.email.$error, 'is-valid':!$v.email.$invalid }">
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.email.required">Email is required.</span>
                                        <span v-if="!$v.email.isUnique">This email is wrong or it's already in use.</span>
                                    </div>
                                    <label class="form-label" for="email">&nbsp;&nbsp;&nbsp;&nbsp;E-mail
                                        <span class="text-danger">*</span>
                                    </label> 
                                </div>
                                <div class="form-floating mb-3">
                                    <input placeholder="Address" type="text" id="address" class="form-control" 
                                    v-model.trim="$v.address.$model" :class="{'is-invalid':$v.address.$error, 'is-valid':!$v.address.$invalid }">
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.address.required">Address is required.</span>
                                    </div>
                                    <label class="form-label" for="address">&nbsp;&nbsp;&nbsp;&nbsp;Address
                                        <span class="text-danger">*</span>    
                                    </label> 
                                </div>
                                <div class="col-sm-6 form-floating mb-3">
                                    <input placeholder="City" type="text" id="city" class="form-control" 
                                    v-model.trim="$v.city.$model" :class="{'is-invalid':$v.city.$error, 'is-valid':!$v.city.$invalid }">
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.city.required">City is required.</span>
                                    </div>
                                    <label class="form-label" for="city">&nbsp;&nbsp;&nbsp;&nbsp;City
                                        <span class="text-danger">*</span>
                                    </label> 
                                </div>
                                <div class="col-sm-6 form-floating mb-3">
                                    <input placeholder="Zip Code" type="text" id="zipCode" class="form-control" 
                                    v-model.number.trim="$v.zipCode.$model" :class="{'is-invalid':$v.zipCode.$error, 'is-valid':!$v.zipCode.$invalid }">
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.zipCode.required">Zip code is required.</span>
                                        <span v-if="!$v.zipCode.numeric">Zip code must be with numbers only.</span>
                                    </div>
                                    <label class="form-label" for="zipCode">&nbsp;&nbsp;&nbsp;&nbsp;Zip code
                                        <span class="text-danger">*</span>
                                    </label> 
                                </div>
                                <div class="mb-4">
                                    <input type="checkbox" id="registerAgree" 
                                    v-model.trim="$v.checked.model" 
                                    :class="{'is-invalid':$v.checked.$error, 'is-valid':!$v.checked.$invalid }">
                                    <label for="agree" class="form-check-label">&nbsp; I agree with the 
                                        <a href="#">Terms & Conditions</a>
                                    </label>
                                    <div class="invalid-feedback">
                                        <span v-if="!$v.checked.required">You must accept the Terms.</span>
                                    </div>
                                </div>
                                <button id="register" type="submit" class="btn btn-primary btn-lg">Register</button>
                                </form>
                            </div>
                            <div class="px-lg-5 py-lg-4 card-footer">
                                <div class="text-sm text-muted">
                                    Already have an account?
                                    <a href="/login">Login</a>
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
import {required, minLength, email, sameAs, numeric} from 'vuelidate/lib/validators'

export default {
    name: 'Register',
    data() {
        return{
            name: '',
            lastName: '',
            username: '',
            password: '',
            confirmPw: '',
            showPw: false,
            email: '',
            address: '',
            city: '',
            zipCode: '',
            checked: '',
            submitStatus: null,
        }
    },
    validations:{
        name: {
            required,
            minLength : minLength(3),
        },
        lastName: {
            required,
            minLength : minLength(5),
        },
        username: {
            required,
            isUnique(value){
                if(value === '') {return true;}

                return new Promise((resolve) =>{
                    setTimeout(() =>{
                        resolve(typeof value === 'string' && value.length % 2 !== 0)
                    }, 350 + Math.random() * 300)
                })
            }
        },
        password:{
            required,
            minLength : minLength(8),
        },
        confirmPw:{
            sameAsPassword: sameAs('password')
        },
        email:{
            required,
            email,
            isUnique(value){
                if(value === '') {return true;}

                var email_regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

                return new Promise((resolve) =>{
                    setTimeout(() =>{
                        resolve(email_regex.test(value))
                    }, 350 + Math.random() * 300)
                })
            }
        },
        address:{
            required,
        },
        city:{
            required,
        },
        zipCode:{
            required,
            numeric
        },
        checked: {
            required
        }
    },
    methods: {
        async register() {
            console.log("registering")
            var body= {
                "name":this.name,
                "lastName":this.lastName,
                "username":this.username, 
                "password":this.password,
                "email":this.email,
                "address":this.address,
                "city":this.city,
                "zipCode":this.zipCode
            }
            this.$v.$touch()
            if(!this.$v.$invalid){
                this.submitStatus = "Registration failed."
            }

            this.$request
            .post('/User', JSON.stringify(body))
            .then(() => {
                // this.msg = "You have been succesfully registered!";
                // this.classAlert = "success";
                this.$router.push({name: 'login'});
            })
            .catch(err => {
                // this.msg = err.response.data.messages.error;
                console.log(err);
            })
        },
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
    margin-left:0;
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