<template>
  <div>
      <div><router-link :to="{name: 'settings'}">Back</router-link></div>
      <form class="userPass" @submit.prevent="changeUserNamePass">
          <div class="alert alert-danger" role="alert" v-if="registrationErrors">
            {{ registrationErrorMsg }}
          </div>
          <!-- <label for="userName">User Name: </label>
          <input type="text" name="userName" id="userName" v-model="user.userName"> -->
          <label for="password">Password: </label>
          <input type="password" name="password" id="password" v-model="user.password">
          <label for="confirmPassword">Confirm Password</label>
          <input
            type="password"
            id="confirmPassword"
            class="form-control"
            placeholder="Confirm Password"
            v-model="user.confirmPassword"
            required
          />
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
        confirmPassword: ''
      },
      error: false,
      noPass: false,
      registrationErrors: false,
      registrationErrorMsg: 'Password & Confirm Password do not match.'
    }
  },
  methods: {
    changeUserNamePass() {
      if (this.user.userName === '' || this.user.password === '') {
        this.noPass = true
      } else {
        if (this.user.password !== this.user.confirmPassword) {
          this.registrationErrors = true;
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
}
</script>

<style>
.userPass {
    display: flex;
    flex-direction: column;
    margin: auto;
    max-width: 200px;
}
</style>