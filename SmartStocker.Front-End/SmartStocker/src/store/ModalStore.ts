import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useModalStore = defineStore('modal', () => {
  const isOpen = ref(false)
  const modalContent = ref(null)
  const editingProduct = ref(null)
  
  function openModal(payload = null) {
    console.log(payload)
    modalContent.value = payload
    isOpen.value = true
  }

  function closeModal() {
    isOpen.value = false
    modalContent.value = null
    editingProduct.value = null
  }

  return {
    isOpen,
    modalContent,
    editingProduct,
    openModal,
    closeModal,
  }
})