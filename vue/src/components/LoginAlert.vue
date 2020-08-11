<template>
  <modal name="alert" :adaptive="true">
      <div class="alert">
            <h3>
                You must login to like, favorite, or comment on a photo!
                <span>
                    <button @click="$modal.hide('alert')">
                    ❌
                    </button>
                </span>
            </h3>
            <button @click="goToLogin">Login</button>
            <button @click="goToRegister">Register</button>
      </div>
  </modal>
</template>

<script>
export default {
    name: 'login-alert',
    methods: {
        goToLogin() {
            this.$router.push({name: 'login'});
        },
        goToRegister() {
            this.$router.push({name: 'register'});
        },
    }
}
</script>

<style>
.alert {
    text-align: center;
}
</style>