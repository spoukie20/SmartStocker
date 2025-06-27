<template>
  <div
    class="fixed inset-0 flex items-center justify-center bg-white/30 backdrop-blur-sm z-50"
    @click.self="$emit('close')"
  >
    <div
      class="bg-white rounded-lg shadow-lg max-w-md w-full p-6 relative"
      role="dialog"
      aria-modal="true"
    >
      <button
        @click="$emit('close')"
        aria-label="Sluit modal"
        class="absolute top-3 right-3 text-gray-400 hover:text-gray-600 focus:outline-none"
      >
        &times;
      </button>
      <div>
        <slot />
      </div>
    </div>
  </div>
</template>

