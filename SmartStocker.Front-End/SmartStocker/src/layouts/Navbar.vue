<template>
  <nav class="bg-white border-b border-gray-200 w-full z-50">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 h-16 flex items-center justify-between">

      <div class="flex items-center space-x-2">
        <img src="../assets/Logo.svg" alt="Smart Stocker logo" class="h-15 w-15">
        <h1 class="text-xl font-bold text-gray-900">Smart Stocker</h1>
      </div>

      <!-- Hamburger button -->
      <button @click="toggleMenu" class="text-2xl md:hidden focus:outline-none" aria-label="Toggle menu">
        <span v-if="!isMenuOpen">&#9776;</span> <!-- ☰ -->
        <span v-else>&times;</span> <!-- × -->
      </button>

      <!-- Menu -->
      <ul :class="[
        'absolute md:static top-16 left-0 w-full md:w-auto bg-white md:bg-transparent flex flex-col md:flex-row md:items-center md:space-x-8 border-t md:border-0 shadow md:shadow-none transition-all duration-200',
        isMenuOpen ? 'flex' : 'hidden md:flex'
      ]">
        <li><a href="/" @click="closeMenu" class="block px-4 py-3 md:py-0 text-gray-700 hover:text-blue-600">Home</a>
        </li>
        <li><a href="/Stock" @click="closeMenu"
            class="block px-4 py-3 md:py-0 text-gray-700 hover:text-blue-600">Voorraad</a></li>
        <li><a href="/Orders" @click="closeMenu"
            class="block px-4 py-3 md:py-0 text-gray-700 hover:text-blue-600">Bestellingen</a></li>
        <li><a href="/Supplier" @click="closeMenu"
            class="block px-4 py-3 md:py-0 text-gray-700 hover:text-blue-600">Leveranciers</a></li>
      </ul>
    </div>
  </nav>
</template>

<script setup>
import { ref } from 'vue'

const isMenuOpen = ref(false)

function toggleMenu() {
  isMenuOpen.value = !isMenuOpen.value
}

function closeMenu() {
  isMenuOpen.value = false
}
</script>

<style scoped>
@media (min-width: 768px) {
  ul {
    top: auto !important;
    left: auto !important;
  }
}
</style>
