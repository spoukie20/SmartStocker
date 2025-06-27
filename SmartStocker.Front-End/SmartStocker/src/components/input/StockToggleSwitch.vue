<template>
  <button
    @click="$emit('update:modelValue', !modelValue)"
    :aria-pressed="modelValue.toString()"
    :disabled="disabled"
    class="relative inline-flex items-center h-6 rounded-full w-11 transition-colors focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
    :class="modelValue ? 'bg-blue-600' : 'bg-gray-300 cursor-pointer'"
  >
    <span
      class="inline-block w-4 h-4 transform bg-white rounded-full transition-transform"
      :class="modelValue ? 'translate-x-6' : 'translate-x-1'"
    ></span>
  </button>
</template>

<script setup>
defineProps({
  modelValue: Boolean,
  disabled: Boolean,
})
</script>
