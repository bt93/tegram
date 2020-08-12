<template>
  <div id="app">
    <nav id="nav">
      <span><router-link v-bind:to="{ name: 'home' }"><i title="Home" class="fas fa-home"></i></router-link></span>
      <span v-if="$store.state.token === ''"> | <router-link v-bind:to="{ name: 'login' }"><i title="Login" class="fas fa-sign-in-alt"></i></router-link></span>
      <span v-if="$store.state.token === ''"> | <router-link v-bind:to="{ name: 'register' }">Register</router-link></span>
      <span v-if="$store.state.token != ''"> | <router-link v-bind:to="{ name: 'user', params: {id: $store.state.user.userId}}"><i title="My Page" class="fas fa-user"></i></router-link></span>
      <span v-if="$store.state.token != ''"> | <router-link v-bind:to="{name: 'upload'}"><i title="Upload Photo" class="fas fa-camera"></i></router-link></span>
      <span v-if="$store.state.token != ''"> | <router-link v-bind:to="{name: 'favorites'}"><i title="Favorites" class="fas fa-bookmark"></i></router-link></span>
      <span v-if="$store.state.token != ''"> | <router-link v-bind:to="{name: 'settings'}"><i title="Settings" class="fas fa-cog"></i></router-link></span>
      <span v-if="$store.state.token != ''"> | <router-link v-bind:to="{ name: 'logout' }"><i title="Logout" class="fas fa-sign-out-alt"></i></router-link></span>
    </nav>
    <main>
      <h2  v-if="$store.state.token != ''">Welcome, {{$store.state.user.username.charAt(0).toUpperCase() + $store.state.user.username.slice(1)}}!</h2>
      <div class="header">
        <!-- <router-link :to="{name: 'home'}"> -->
          <span><img src=".\images\TEGram_Smaller_Rounded.png" class="small-logo" alt="TeGram" title="Go Home" @click="goHome"></span>
        <!-- </router-link> -->
        <h1 class="title">TEGram</h1>
      </div>
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
  },
  methods: {
    goHome() {
      if (this.$route.name === 'home') {
        window.location.reload();
      } else {
        this.$router.push('/');
      }
    }
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Pacifico&family=Roboto:wght@100;300;400;500&display=swap');

body {
  font-family: 'Roboto', Helvetica, Arial, sans-serif;
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
  color: #12A3D8;
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
  cursor: pointer;
}

.router-link-exact-active {
  color: goldenrod;
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
  bottom: -80px;
  width: 100%;
  height: 2.5rem;            /* Footer height */
}

textarea,
input[type="submit"] {
  margin: auto;
}

input[type="submit"] {
  margin-top: 20px;
  padding: 10px 30px;
  z-index: 2000;
  cursor: pointer;
}

@media screen and (max-width: 730px) {
  main {
      margin: auto;
      padding: 0;
  }

  .text-center {
    min-width: 250px;
  }

  .header {
    padding-top: 30px;
  }
}

@media screen and (max-width: 900px) {
  main {
        margin: auto;
  }
}
</style>