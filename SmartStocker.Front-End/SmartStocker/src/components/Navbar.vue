<template>
    <nav
  class="fixed top-0 left-0 right-0 bg-white/90 backdrop-blur-sm border-b border-gray-200 shadow-sm z-50"
  aria-label="Hoofdnavigatie"
>
  <div class="max-w-7xl mx-auto px-6 sm:px-8 lg:px-10">
    <div class="flex justify-between h-16 items-center">
      <!-- Logo -->
      <a href="/" class="flex items-center space-x-2 select-none" aria-label="InventoryFlow Home">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          class="h-8 w-8 text-blue-600"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
          stroke-width="2"
          aria-hidden="true"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            d="M3 7v4a1 1 0 001 1h3m10-6v4a1 1 0 01-1 1h-3m0 0v8m0-8H8m6 0H8"
          />
        </svg>
        <span class="text-xl font-semibold tracking-wide text-gray-900 hover:text-blue-600 transition"
          >InventoryFlow</span
        >
      </a>

      <!-- Desktop nav -->
      <div class="hidden md:flex space-x-10">
        <a
          href="/dashboard"
          class="relative inline-flex items-center px-1 pt-1 text-blue-600 font-semibold tracking-wide transition after:block after:absolute after:-bottom-1 after:left-0 after:right-0 after:h-0.5 after:bg-blue-600"
          >Dashboard</a
        >
        <a
          href="/products"
          class="relative inline-flex items-center px-1 pt-1 text-gray-700 hover:text-blue-600 font-medium tracking-wide transition"
          >Producten</a
        >
        <a
          href="/orders"
          class="relative inline-flex items-center px-1 pt-1 text-gray-700 hover:text-blue-600 font-medium tracking-wide transition"
          >Bestellingen</a
        >
        <a
          href="/suppliers"
          class="relative inline-flex items-center px-1 pt-1 text-gray-700 hover:text-blue-600 font-medium tracking-wide transition"
          >Leveranciers</a
        >
      </div>

      <!-- User & Logout desktop -->
      <div class="hidden md:flex items-center space-x-6">
        <span
          class="inline-flex items-center px-3 py-1 rounded-full bg-blue-100 text-blue-800 text-sm font-semibold tracking-wide select-none"
          >Admin</span
        >
        <button
          type="button"
          class="inline-flex items-center px-4 py-1 rounded-md bg-red-600 text-white text-sm font-semibold hover:bg-red-700 focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-offset-1 transition"
        >
          Uitloggen
        </button>
      </div>

      <!-- Mobile menu button (niet functioneel zonder JS) -->
      <button
        type="button"
        aria-expanded="false"
        aria-label="Open menu"
        class="md:hidden inline-flex items-center justify-center p-2 rounded-md text-gray-700 hover:text-blue-600 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-blue-500 transition"
      >
        <span class="sr-only">Open hoofdmenu</span>

        <!-- Hamburger icon -->
        <svg
          class="block h-6 w-6"
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
          stroke-width="2"
          aria-hidden="true"
        >
          <path stroke-linecap="round" stroke-linejoin="round" d="M4 6h16M4 12h16M4 18h16" />
        </svg>
      </button>
    </div>
  </div>

  <!-- Mobile menu placeholder (zorg zelf voor toggle via JS) -->
  
  <div class="md:hidden bg-white border-t border-gray-200 shadow-md px-6 pt-4 pb-6 space-y-4">
    <a href="/dashboard" class="block text-gray-700 hover:text-blue-600 font-medium tracking-wide transition">Dashboard</a>
    <a href="/products" class="block text-gray-700 hover:text-blue-600 font-medium tracking-wide transition">Producten</a>
    <a href="/orders" class="block text-gray-700 hover:text-blue-600 font-medium tracking-wide transition">Bestellingen</a>
    <a href="/suppliers" class="block text-gray-700 hover:text-blue-600 font-medium tracking-wide transition">Leveranciers</a>
    <div class="flex items-center justify-between pt-2 border-t border-gray-100">
      <span class="inline-flex items-center px-3 py-1 rounded-full bg-blue-100 text-blue-800 text-sm font-semibold tracking-wide select-none">Admin</span>
      <button type="button" class="inline-flex items-center px-4 py-1 rounded-md bg-red-600 text-white text-sm font-semibold hover:bg-red-700 focus:outline-none focus:ring-2 focus:ring-red-500 focus:ring-offset-1 transition">Uitloggen</button>
    </div>
  </div>
 
</nav>

</template>