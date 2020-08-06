<template>
  <modal name="detail">
      <p>Hello</p>
  </modal>
</template>

<script>
export default {
    name: 'photo-detail',
    mounted() {
        this.$modal.show('detail')
    }
}
</script>

<style>

</style>