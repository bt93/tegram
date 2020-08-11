<template>
  <div>
      <router-link :to="{name: 'settings'}">Back</router-link>
      <h1>Delete User</h1>
      <div @click="deleteUser" class="button">DELETE USER</div>
  </div>
</template>

<script>
import authService from '../services/AuthService'

export default {
    methods: {
        deleteUser() {
            if (confirm("Are you sure you want to delete your account?")) {
                authService.deleteUser()
                    .then(res => {
                        if (res.status === 200) {
                            this.$router.push('/logout');
                        }
                    })
            } else {
                this.$router.push('/');
            }
        }
    }
}
</script>

<style>
.button {
    border: 2px solid red;
    margin: 8px auto;
    padding: 20px;
    border-radius: 30px;
    background-color: red
}

.button:hover {
    color: white;
    background-color: black;
    cursor: pointer;
}

</style>