<template>
  <div class="home">
    <h1 class="title">TEGram</h1>
    <photo-container />
  </div>
</template>

<script>
import PhotoContainer from '../components/PhotoContainer'

export default {
  name: "home",
  components: {
    PhotoContainer
  }
};
</script>
