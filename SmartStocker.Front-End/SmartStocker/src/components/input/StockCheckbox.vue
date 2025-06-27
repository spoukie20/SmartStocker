<template>
  <label class="inline-flex items-center cursor-pointer select-none">
    <input
      type="checkbox"
      :checked="modelValue"
      @change="$emit('update:modelValue', $event.target.checked)"
      :disabled="disabled"
      class="form-checkbox h-5 w-5 text-blue-600 transition duration-150"
    />
    <span class="ml-2 text-gray-700">{{ label }}</span>
  </label>
</template>

<script setup>
defineProps({
  modelValue: Boolean,
  label: String,
  disabled: Boolean,
})
</script>
