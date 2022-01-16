<template>
  <q-layout view="lHh Lpr lFf">
    <q-header bordered class="main-header text-center">
      <q-toolbar class="text-center">
        <p class="p-title col-12">E-Book</p>
      </q-toolbar>
    </q-header>
    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'MainLayout',
})
</script>

<style scoped>
.p-title{
  color: red;
  font-weight: 700;
  margin: 0;
}
.main-header{
  background-color: white !important;
}
</style>
