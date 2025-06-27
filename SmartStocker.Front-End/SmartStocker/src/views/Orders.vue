<template>
  <div class="p-6 max-w-6xl mx-auto">
    <!-- Pagina Titel -->
    <section class="mb-8 text-center">
      <h1 class="text-4xl font-bold text-gray-800 mb-2">Bestellingen</h1>
      <p class="text-gray-600 text-lg">
        Beheer en houd overzicht over je bestellingen.
      </p>
    </section>

    <!-- Actieknoppen -->
    <div class="flex justify-end mb-6 space-x-4">
      <button @click="openAddModal" class="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded-md shadow">
        + Nieuwe bestelling
      </button>
    </div>

    <!-- Bestellingen tabel -->
    <div class="overflow-x-auto bg-white rounded-lg shadow">
      <table class="min-w-full divide-y divide-gray-200">
        <thead class="bg-gray-50">
          <tr>
            <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Ordernummer
            </th>
            <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Klantnaam
            </th>
            <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Datum
            </th>
            <th class="px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider">
              Status
            </th>
            <th class="px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider">
              Totaal
            </th>
            <th class="relative px-6 py-3">
              <span class="sr-only">Acties</span>
            </th>
          </tr>
        </thead>
        <tbody class="bg-white divide-y divide-gray-200">
          <tr v-for="order in orders" :key="order.id" class="hover:bg-gray-50 transition-colors">
            <td class="px-6 py-4 whitespace-nowrap font-medium text-gray-900">{{ order.orderNumber }}</td>
            <td class="px-6 py-4 whitespace-nowrap text-gray-700">{{ order.customer }}</td>
            <td class="px-6 py-4 whitespace-nowrap text-gray-500">{{ formatDate(order.date) }}</td>
            <td class="px-6 py-4 whitespace-nowrap text-right font-semibold" :class="statusColor(order.status)">
              {{ order.status }}
            </td>
            <td class="px-6 py-4 whitespace-nowrap text-right font-semibold text-gray-900">
              €{{ order.total.toFixed(2) }}
            </td>
            <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
              <button @click="editOrder(order)" class="text-blue-600 hover:text-blue-900 mr-4">Wijzigen</button>
              <button @click="deleteOrder(order)" class="text-red-600 hover:text-red-900">Verwijderen</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <!-- Modal voor toevoegen / bewerken -->
    <StockModal v-if="modalStore.isOpen" @close="modalStore.closeModal()">
      <template #default>
        <h3 class="text-xl font-semibold mb-4">
          {{ modalStore.editingItem ? 'Bestelling bewerken' : 'Nieuwe bestelling' }}
        </h3>
        <form @submit.prevent="saveOrder" class="space-y-4">
          <StockTextInput label="Ordernummer" v-model="form.orderNumber" required />
          <StockTextInput label="Klantnaam" v-model="form.customer" required />
          <StockTextInput label="Datum" type="date" v-model="form.date" required />
          <select v-model="form.status" class="border rounded-md px-3 py-2 w-full" required>
            <option value="">Selecteer status</option>
            <option value="In behandeling">In behandeling</option>
            <option value="Verzonden">Verzonden</option>
            <option value="Geannuleerd">Geannuleerd</option>
            <option value="Afgerond">Afgerond</option>
          </select>
          <StockTextInput label="Totaal (€)" type="number" min="0" step="0.01" v-model.number="form.total" required />
          <div class="flex justify-end space-x-4 pt-4">
            <StockButton variant="secondary" @click="modalStore.closeModal()">Annuleren</StockButton>
            <StockButton type="submit" variant="primary">
              {{ modalStore.editingItem ? 'Opslaan' : 'Toevoegen' }}
            </StockButton>
          </div>
        </form>
      </template>
    </StockModal>
  </div>
</template>

<script setup>
import { reactive, watch } from 'vue'
import { useModalStore } from '@/store/ModalStore'
import StockModal from '@/components/StockModal.vue'
import StockTextInput from '@/components/input/StockTextInput.vue'
import StockButton from '@/components/input/StockButton.vue'

const modalStore = useModalStore()

const orders = reactive([
  {
    id: 1,
    orderNumber: 'ORD-1001',
    customer: 'Jan Jansen',
    date: '2025-06-20',
    status: 'In behandeling',
    total: 299.99,
  },
  {
    id: 2,
    orderNumber: 'ORD-1002',
    customer: 'Marieke de Vries',
    date: '2025-06-18',
    status: 'Verzonden',
    total: 149.49,
  },
])

const form = reactive({
  id: null,
  orderNumber: '',
  customer: '',
  date: '',
  status: '',
  total: 0,
})

function resetForm() {
  if (modalStore.editingItem) {
    const e = modalStore.editingItem
    form.id = e.id
    form.orderNumber = e.orderNumber
    form.customer = e.customer
    form.date = e.date
    form.status = e.status
    form.total = e.total
  } else {
    form.id = null
    form.orderNumber = ''
    form.customer = ''
    form.date = ''
    form.status = ''
    form.total = 0
  }
}

function openAddModal() {
  modalStore.openModal(null)
}

function editOrder(order) {
  modalStore.editingItem = true;
  modalStore.openModal(order)
}

function saveOrder() {
  if (modalStore.editingItem) {
    const index = orders.findIndex(o => o.id === form.id)
    if (index !== -1) {
      orders[index] = { ...form }
    }
  } else {
    const newId = orders.length ? Math.max(...orders.map(o => o.id)) + 1 : 1
    orders.push({ ...form, id: newId })
  }
  modalStore.closeModal()
  resetForm()
}

function deleteOrder(order) {
  if (confirm(`Weet je zeker dat je bestelling ${order.orderNumber} wilt verwijderen?`)) {
    const index = orders.findIndex(o => o.id === order.id)
    if (index !== -1) orders.splice(index, 1)
  }
}

function formatDate(dateStr) {
  const d = new Date(dateStr)
  return d.toLocaleDateString('nl-NL', { day: '2-digit', month: 'short', year: 'numeric' })
}

function statusColor(status) {
  switch (status) {
    case 'In behandeling':
      return 'text-yellow-600 font-semibold'
    case 'Verzonden':
      return 'text-green-600 font-semibold'
    case 'Geannuleerd':
      return 'text-red-600 font-semibold'
    case 'Afgerond':
      return 'text-blue-600 font-semibold'
    default:
      return 'text-gray-600'
  }
}
</script>
