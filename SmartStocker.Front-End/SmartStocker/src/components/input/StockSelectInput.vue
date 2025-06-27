<template>
  <div class="flex flex-col">
    <label v-if="label" :for="id" class="mb-1 font-medium text-gray-700">{{ label }}</label>
    <select
      :id="id"
      v-model="modelValue"
      :class="selectClasses"
      :disabled="disabled"
      @change="$emit('update:modelValue', $event.target.value)"
    >
      <option value="" disabled selected v-if="placeholder">{{ placeholder }}</option>
      <option v-for="option in options" :key="option.value" :value="option.value">
        {{ option.label }}
      </option>
    </select>
    <p v-if="error" class="mt-1 text-sm text-red-600">{{ error }}</p>
  </div>
</template>

<script setup>
import { computed } from 'vue'

defineProps({
  modelValue: [String, Number],
  label: String,
  id: String,
  options: {
    type: Array,
    required: true,
  },
  placeholder: String,
  error: String,
  disabled: Boolean,
})

const props = defineProps()

const selectClasses = computed(() => {
  const base =
    'border rounded-md px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500 transition appearance-none'

  const errorClasses = props.error
    ? 'border-red-600 focus:ring-red-500'
    : 'border-gray-300 focus:ring-blue-500'

  const disabledClasses = props.disabled ? 'bg-gray-100 cursor-not-allowed' : ''

  return [base, errorClasses, disabledClasses].join(' ')
})
</script>
