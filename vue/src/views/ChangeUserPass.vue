<template>
  <div>
      <router-link :to="{name: 'settings'}">Back</router-link>
      <form @submit.prevent="changeUserNamePass">
          <label for="userName">User Name: </label>
          <input type="text" name="userName" id="userName" v-model="user.userName">
          <label for="pass">Password: </label>
          <input type="password" name="password" id="password" v-model="user.password">
          <input type="submit">
      </form>
      <h1 v-if="noPass">Must give a username and password.</h1>
      <Error v-if="error" />
  </div>
</template>

<script>
import authService from '../services/AuthService'
import Error from '../components/Error'

export default {
  components: {
    Error
  },
  data() {
    return {
      user: {
        userName: this.$store.state.user.username,
        userId: this.$store.state.user.userId,
        password: '',
      },
      error: false,
      noPass: false
    }
  },
  methods: {
    changeUserNamePass() {
      if (this.user.userName === '' || this.user.password === '') {
        this.noPass = true
      } else {
        authService.changeUserPassword(this.user)
          .then(res => {
            if (res.status === 201) {
              this.$router.push('/');
            }
          })
          .catch(err => {
            console.log(err);
            this.error = true;
          })
      }
    }
  }
}
</script>

<style>
form {
    display: flex;
    flex-direction: column;
    margin: auto;
    max-width: 200px;
}
</style>