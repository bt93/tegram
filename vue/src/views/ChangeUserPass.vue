<template>
  <div>
      <router-link :to="{name: 'settings'}">Back</router-link>
      <form>
          <label for="userName">User Name: </label>
          <input type="text" name="userName" id="userName">
          <label for="pass">Password: </label>
          <input type="password" name="password" id="password">
          <input type="submit">
      </form>
  </div>
</template>

<script>
export default {

}
</script>

<style>

</style>