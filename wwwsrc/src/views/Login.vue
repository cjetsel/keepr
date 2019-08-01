<template>
    <div class="login mt-5">
        <form class="form-row justify-content-center mt-5" v-if="loginForm" @submit.prevent="loginUser">
            <div class="col-6">
                <input class="form-control mb-1" type="email" v-model="creds.email" placeholder="email">
                <input class="form-control mb-1" type="password" v-model="creds.password" placeholder="password">
                <button class="btn btn-info" type="submit">Login</button>
            </div>
        </form>
        <form class="form-row mt-5 justify-content-center" v-else @submit.prevent="register">
            <div class="col-6">
                <input class="form-control mb-1" type="text" v-model="newUser.username" placeholder="name">
                <input class="form-control mb-1" type="email" v-model="newUser.email" placeholder="email">
                <input class="form-control mb-1" type="password" v-model="newUser.password" placeholder="password">
                <button class="btn btn-info" type="submit">Create Account</button>
            </div>
        </form>
        <div @click="loginForm = !loginForm" class="mt-3">
            <p v-if="loginForm">No account? Click to Register</p>
            <p v-else>Already have an account click to Login</p>
        </div>
    </div>
</template>

<script>
    export default {
        name: "login",
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        beforeCreate() {
            if (this.$store.state.user.id) {
                this.$router.push({ name: "home" })
            }
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        }
    };
</script>