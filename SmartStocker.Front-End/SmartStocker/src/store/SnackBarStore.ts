import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useSnackbarStore = defineStore('snackbar', () => {
  const showSnackbar = ref(false)
  const snackbarMessage = ref('')

  function triggerSnackbar(msg: string) {
    snackbarMessage.value = msg
    showSnackbar.value = true
  }

  function closeSnackbar() {
    showSnackbar.value = false
  }

  return { showSnackbar, snackbarMessage, triggerSnackbar, closeSnackbar }
})
