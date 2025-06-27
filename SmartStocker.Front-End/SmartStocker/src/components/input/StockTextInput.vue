<template>
  <div class="flex flex-col">
    <label
      v-if="label"
      :for="id"
      class="mb-1 font-medium text-gray-700"
    >
      {{ label }}
    </label>
    <input
      :id="id"
      :type="type"
      :placeholder="placeholder"
      v-model="inputValue"
      :class="inputClasses"
      :disabled="disabled"
      @input="$emit('update:modelValue', $event.target.value)"
    />
    <p v-if="error" class="mt-1 text-sm text-red-600">{{ error }}</p>
  </div>
</template>

<script setup>
import { computed, toRef } from 'vue'

const props = defineProps({
  modelValue: String,
  label: String,
  id: String,
  type: {
    type: String,
    default: 'text',
  },
  placeholder: String,
  error: String,
  disabled: {
    type: Boolean,
    default: false,
  },
})

// We gebruiken een lokale referentie zodat `v-model` goed werkt
const inputValue = toRef(props, 'modelValue')

const inputClasses = computed(() => {
  const base =
    'border rounded-md px-3 py-2 focus:outline-none focus:ring-2 transition'

  const errorClasses = props.error
    ? 'border-red-600 focus:ring-red-500'
    : 'border-gray-300 focus:ring-blue-500'

  const disabledClasses = props.disabled ? 'bg-gray-100 cursor-not-allowed' : ''

  return [base, errorClasses, disabledClasses].join(' ')
})
</script>
