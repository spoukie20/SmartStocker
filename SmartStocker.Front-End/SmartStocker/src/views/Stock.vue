<template>
  <div class="p-6 max-w-6xl mx-auto">
    <!-- Pagina Titel -->
    <section class="mb-8 text-center">
      <h1 class="text-4xl font-bold text-gray-800 mb-2">Voorraadbeheer</h1>
      <p class="text-gray-600 text-lg">
        Beheer eenvoudig je producten en houd je voorraad up-to-date.
      </p>
    </section>

    <!-- Actieknoppen -->
    <div class="flex justify-end mb-6 space-x-4">
      <button @click="openAddModal" class="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded-md shadow">
        + Nieuw product
      </button>
    </div>

    <!-- Producten tabel -->
    <div class="overflow-x-auto bg-white rounded-lg shadow">
      <table class="min-w-full divide-y divide-gray-200">
        <thead class="bg-gray-50">
          <tr>
            <th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Productnaam
            </th>
            <th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Categorie
            </th>
            <th scope="col" class="px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider">
              Voorraad
            </th>
            <th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Leverancier
            </th>
            <th scope="col" class="relative px-6 py-3">
              <span class="sr-only">Acties</span>
            </th>
          </tr>
        </thead>
        <tbody class="bg-white divide-y divide-gray-200">
          <tr v-for="product in products" :key="product.id" class="hover:bg-gray-50 transition-colors">
            <td class="px-6 py-4 whitespace-nowrap text-gray-900 font-medium">{{ product.name }}</td>
            <td class="px-6 py-4 whitespace-nowrap text-gray-500">{{ product.category }}</td>
            <td class="px-6 py-4 whitespace-nowrap text-right font-semibold" :class="{
              'text-red-600': product.stock <= 5,
              'text-green-600': product.stock > 5,
            }">
              {{ product.stock }}
            </td>
            <td class="px-6 py-4 whitespace-nowrap text-gray-500">{{ product.supplier }}</td>
            <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
              <button @click="editProduct(product)" class="text-blue-600 hover:text-blue-900 mr-4">
                Wijzigen
              </button>
              <button @click="deleteProduct(product)" class="text-red-600 hover:text-red-900">
                Verwijderen
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <!-- Modal voor toevoegen / bewerken -->
    <StockModal v-if="modalStore.isOpen" @close="modalStore.closeModal">
      <template #default>
        <h3 class="text-xl font-semibold mb-4">
          {{ modalStore.editingProduct ? 'Product bewerken' : 'Nieuw product toevoegen' }}
        </h3>
        <form @submit.prevent="saveProduct" class="space-y-4">
          <StockTextInput label="Productnaam" v-model="form.name" required />
          <StockTextInput label="Categorie" v-model="form.category" required />
          <StockTextInput label="Voorraad" type="number" v-model.number="form.stock" min="0" required />
          <StockTextInput label="Leverancier" v-model="form.supplier" />
          <div class="flex justify-end space-x-4 pt-4">
            <StockButton variant="secondary" @click="modalStore.closeModal">Annuleren</StockButton>
            <StockButton type="submit" variant="primary">
              {{ modalStore.editingProduct ? 'Opslaan' : 'Toevoegen' }}
            </StockButton>
          </div>
        </form>
      </template>
    </StockModal>
  </div>
</template>

<script setup>
import { reactive } from 'vue'
import { useModalStore } from '@/store/modalStore.ts'
import StockModal from '@/components/StockModal.vue'
import StockTextInput from '@/components/input/StockTextInput.vue'
import StockButton from '@/components/input/StockButton.vue'

const modalStore = useModalStore()

const products = reactive([
  {
    id: 1,
    name: 'Printerpapier A4',
    category: 'Kantoor',
    stock: 134,
    supplier: 'Staples',
  },
  {
    id: 2,
    name: 'Inktcartridge Zwart',
    category: 'Kantoor',
    stock: 3,
    supplier: 'Office Supplies',
  },
  {
    id: 3,
    name: 'Laptop Stand',
    category: 'Accessoires',
    stock: 12,
    supplier: 'TechWorld',
  },
])

const form = reactive({
  id: null,
  name: '',
  category: '',
  stock: 0,
  supplier: '',
})

function openAddModal() {
  modalStore.editingProduct = null
  resetForm()
  modalStore.openModal()
}

function editProduct(product) {
  modalStore.editingProduct = product
  form.id = product.id
  form.name = product.name
  form.category = product.category
  form.stock = product.stock
  form.supplier = product.supplier
  modalStore.openModal()
}

function resetForm() {
  form.id = null
  form.name = ''
  form.category = ''
  form.stock = 0
  form.supplier = ''
}

function saveProduct() {
  if (modalStore.editingProduct) {
    // Update bestaand product
    const index = products.findIndex((p) => p.id === form.id)
    if (index !== -1) {
      products[index] = { ...form }
    }
  } else {
    // Nieuw product toevoegen
    const newId = Math.max(...products.map((p) => p.id)) + 1
    products.push({ ...form, id: newId })
  }
  modalStore.closeModal()
  resetForm()
}

function deleteProduct(product) {
  if (confirm(`Weet je zeker dat je ${product.name} wilt verwijderen?`)) {
    const index = products.findIndex((p) => p.id === product.id)
    if (index !== -1) {
      products.splice(index, 1)
    }
  }
}

</script>
