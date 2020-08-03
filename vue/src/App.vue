<template>
  <div id="app">
    <div id="nav" v-if="$route.name !== 'login' || $route.name !== 'register'">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    <router-view />
  </div>
</template>


<style>
@import url('https://fonts.googleapis.com/css2?family=Pacifico&family=Roboto:ital,wght@0,300;0,500;1,400&display=swap');

body {
  font-family: 'Roboto', Arial, sans-serif;
}

.text-center {
  text-align: center;
  padding: 0 1vh 0 1vh;
  border: 1px solid rgba(var(--b6a,219,219,219),1);
}

.userForm > form {
  display: flex;
  flex-direction: column;
  padding: 10px 0;
}

.userForm > form > h1 {
  font-family: 'Pacifico', cursive;;
}

@media screen and (min-width: 545px) {
  .userForm {
    margin: 0 220px 0 220px;
  }
}
</style>