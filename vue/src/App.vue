<template>
  <div id="app">
    <nav id="nav" v-if="$route.name !== 'login' || $route.name !== 'register'">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link> 
      <router-link v-bind:to="{ name: 'login' }" v-if="$store.state.token === ''"> | Login | </router-link>
      <router-link v-bind:to="{ name: 'register' }" v-if="$store.state.token === ''">Register</router-link>
      <router-link v-bind:to="{ name: 'user', params: {id: $store.state.user.userId} }" v-if="$store.state.token != ''"> | {{$store.state.user.username.charAt(0).toUpperCase() + $store.state.user.username.slice(1)}} </router-link>
      <router-link v-bind:to="{name: 'settings'}" v-if="$store.state.token != ''">| Settings</router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''"> | Logout</router-link>
    </nav>
    <main>
      <h2  v-if="$store.state.token != ''">Welcome, {{$store.state.user.username.charAt(0).toUpperCase() + $store.state.user.username.slice(1)}}!</h2>
      <router-view />
    </main>
    <footer>&copy; TEGram {{date.getFullYear()}}</footer>
  </div>
</template>

<script>
export default {
  data() {
    return {
      date: new Date()
    }
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Pacifico&family=Roboto:ital,wght@0,300;0,500;1,400&display=swap');

body {
  font-family: 'Roboto', Arial, sans-serif;
  background: rgba(250,250,250);
  position: relative;
  min-height: 100vh;
}

main {
  margin: 0 0% 0 0%;
  text-align: center;
  padding: 0 135px;
  padding-bottom: 2.5rem; 
}

a {
  text-decoration: none;
}

.header {
  display: flex;
  justify-content: center;
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
  max-width: 300px;
  margin: 45px auto;
  background-color: rgba(255,255,255);
  border: 1px solid rgba(219,219,219);
}

.userForm > form > input,
.userForm > form > button {
      margin: auto;
}

.small-logo {
  max-width: 80px;
  padding-right: 20px;
}
.title {
  font-family: 'Pacifico', cursive;;
}

.error {
  color: red;
  text-emphasis: bold;
}

footer {
  position: absolute;
  bottom: 0;
  width: 100%;
  height: 2.5rem;            /* Footer height */
}

@media screen and (max-width: 730px) {
  main {
      margin: auto;
  }
}

@media screen and (max-width: 900px) {
  main {
        margin: auto;
  }
}
</style>