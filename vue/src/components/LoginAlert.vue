<template>
  <modal name="alert">
      <h3>You must login to like or favorite a photo!</h3>
      <button @click="goToLogin">Login</button>
      <button @click="goToRegister">Register</button>
      <button @click="$modal.hide('alert')">
        ❌
      </button>
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

</style>