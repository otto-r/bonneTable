<template>
  <div id="app">
    <router-view></router-view>
  </div>
</template>

<script>
import Admin from './components/admin/Admin.vue'
import Book from './components/Book.vue'

export default {
  name: 'app',
  components: {
    Admin,
    Book
  }
}
</script>

<style>

</style>
