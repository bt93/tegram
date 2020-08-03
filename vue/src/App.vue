<template>
  <div id="app">
    <nav id="nav" v-if="$route.name !== 'login' || $route.name !== 'register'">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link> |
      <router-link v-bind:to="{ name: 'login' }" v-if="$store.state.token === ''">Login | </router-link>
      <router-link v-bind:to="{ name: 'register' }" v-if="$store.state.token === ''">Register</router-link>
      <router-link v-bind:to="{ name: 'user' }" v-if="$store.state.token != ''"> | My Account</router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''"> | Logout</router-link>
    </nav>
    <main>
      <router-view />
    </main>
  </div>
</template>


<style>
@import url('https://fonts.googleapis.com/css2?family=Pacifico&family=Roboto:ital,wght@0,300;0,500;1,400&display=swap');

body {
  font-family: 'Roboto', Arial, sans-serif;
  background: rgba(250,250,250);
}

main {
  margin: 0 0% 0 0%;
  text-align: center;
}

a {
  text-decoration: none;
}

.text-center {
  text-align: center;
  padding: 0 1vh 0 1vh;
  border: 1px solid rgba(250,250,250)
}

.userForm > form {
  display: flex;
  flex-direction: column;
  padding: 10px 0;
}

.userForm > form > input,
.userForm > form > button {
      margin: auto;
}

.title {
  font-family: 'Pacifico', cursive;;
}

@media screen and (max-width: 730px) {
  main {
        margin: 0px 20% 0 20%;
  }

  .userForm {
    margin: 0 220px 0 220px;
  }
}

@media screen and (max-width: 900px) {
  main {
        margin: 0px -15% 0 -15%;
  }
}
</style>