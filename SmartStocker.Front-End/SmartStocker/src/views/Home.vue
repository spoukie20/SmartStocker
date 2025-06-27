<template>
  <div class="p-6 max-w-6xl mx-auto">
    <!-- Banner -->
    <section
      class="bg-blue-50 border border-blue-200 rounded-lg p-5 mb-8 text-center text-blue-900"
    >
      <h2 class="text-3xl font-semibold">Welkom terug, Jan!</h2>
      <p class="mt-1 text-lg font-light">
        Hier is een overzicht van je voorraad en bestellingen vandaag.
      </p>
    </section>

    <!-- Dashboard Cards -->
    <div class="grid grid-cols-1 md:grid-cols-3 gap-6 mb-12">
      <div
        class="bg-white p-6 shadow rounded-xl flex flex-col items-center"
      >
        <h3 class="text-gray-700 text-sm font-medium mb-2">Producten op voorraad</h3>
        <p class="text-4xl font-extrabold text-blue-600">134</p>
      </div>
      <div
        class="bg-white p-6 shadow rounded-xl flex flex-col items-center"
      >
        <h3 class="text-gray-700 text-sm font-medium mb-2">Open bestellingen</h3>
        <p class="text-4xl font-extrabold text-blue-600">6</p>
      </div>
      <div
        class="bg-white p-6 shadow rounded-xl flex flex-col items-center"
      >
        <h3 class="text-gray-700 text-sm font-medium mb-2">Actieve leveranciers</h3>
        <p class="text-4xl font-extrabold text-blue-600">12</p>
      </div>
    </div>

    <!-- Laatste Activiteit: Timeline stijl -->
    <section class="max-w-3xl mx-auto">
      <h3 class="text-xl font-semibold text-gray-800 mb-6 text-center">
        Laatste activiteit
      </h3>
      <ul class="relative border-l border-gray-300 ml-6">
        <li class="mb-8 ml-6">
          <span
            class="absolute -left-3 top-1 w-6 h-6 rounded-full bg-blue-600 flex items-center justify-center text-white text-sm"
            >📦</span
          >
          <p class="text-gray-700 text-sm font-medium">Product “Printerpapier” toegevoegd</p>
          <p class="text-gray-500 text-xs">2 uur geleden</p>
        </li>
        <li class="mb-8 ml-6">
          <span
            class="absolute -left-3 top-1 w-6 h-6 rounded-full bg-blue-600 flex items-center justify-center text-white text-sm"
            >🛒</span
          >
          <p class="text-gray-700 text-sm font-medium">Bestelling #2025 geplaatst</p>
          <p class="text-gray-500 text-xs">gisteren</p>
        </li>
        <li class="mb-8 ml-6">
          <span
            class="absolute -left-3 top-1 w-6 h-6 rounded-full bg-blue-600 flex items-center justify-center text-white text-sm"
            >👤</span
          >
          <p class="text-gray-700 text-sm font-medium">Ingelogd als Jan</p>
          <p class="text-gray-500 text-xs">3 dagen geleden</p>
        </li>
      </ul>
    </section>
  </div>
</template>
