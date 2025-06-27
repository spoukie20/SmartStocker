<template>
  <transition
    enter-active-class="transition transform duration-300 ease-out"
    enter-from-class="opacity-0 translate-y-6"
    enter-to-class="opacity-100 translate-y-0"
    leave-active-class="transition transform duration-300 ease-in"
    leave-from-class="opacity-100 translate-y-0"
    leave-to-class="opacity-0 translate-y-6"
  >
    <div
      v-if="visible"
      class="fixed bottom-6 left-1/2 transform -translate-x-1/2 bg-gray-800 text-white px-4 py-2 rounded-md shadow-lg max-w-sm w-full text-center"
      role="alert"
      aria-live="assertive"
    >
      {{ message }}
    </div>
  </transition>
</template>

<script setup>
import { ref, watch, onUnmounted } from 'vue'

defineProps({
  modelValue: Boolean,
  message: String,
  duration: {
    type: Number,
    default: 3000,
  },
})

const props = defineProps()

const visible = ref(props.modelValue)
let timeoutId = null

watch(
  () => props.modelValue,
  (newVal) => {
    visible.value = newVal
    if (newVal) {
      clearTimeout(timeoutId)
      timeoutId = setTimeout(() => {
        visible.value = false
        // Emit update to parent to sync v-model
        emit('update:modelValue', false)
      }, props.duration)
    }
  }
)

onUnmounted(() => {
  clearTimeout(timeoutId)
})

const emit = defineEmits(['update:modelValue'])
</script>
