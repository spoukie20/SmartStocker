<template>
  <div>
    <nav>
      <Navbar/>
    </nav>
    <main class="">
      <slot/>
    </main>
  </div>
</template>

<script setup lang="ts">
import Navbar from '@/layouts/Navbar.vue'
</script>
