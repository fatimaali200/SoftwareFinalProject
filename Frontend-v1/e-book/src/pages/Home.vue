<template>
  <q-page class="q-ma-xl">
    <h5 class="header-1">Books List</h5>
    <hr class="q-my-lg">
    <q-table
      flat
      :rows="rows1"
      :columns="columns"
      row-key="id"
      :filter="filter"
      :loading="loading"
    >
      <template v-slot:body-cell-actions="props">
        <q-td :props="props">
          <div class="q-gutter-xs">
            <q-btn
              color="primary"
              label="Buy"
              :to="'/payment/' + props.row.id"
            />
          </div>
        </q-td>
      </template>
      <template v-slot:top>
        <q-input borderless dense debounce="300" maxlength="50" color="primary" v-model="filter" placeholder="Search...">
          <template v-slot:append>
            <q-icon name="search" />
          </template>
        </q-input>
      </template>

    </q-table>
    
  </q-page>
</template>

<script>
const columns = [
  {
    name: 'name',
    required: true,
    label: 'name',
    align: 'center',
    field: row => row.name,
    format: val => `${val}`,
    sortable: true
  },
  { name: 'edition', align: 'center', label: 'Edition', field: row => row.edition, sortable: true },
  { name: 'amount', label: 'Amount', field: row => row.amount, sortable: true },
  { name: 'author', label: 'Author', field: row => row.author, sortable: true },
  { name: 'price', label: 'Price', field: row => row.price, sortable: true },
  {
    name: "actions",
    align: "center",
    label: "Actions",
    field: "actions"
  },
]
/*
const originalRows = [
  {
    name: 'Frozen Yogurt',
    calories: 159,
    fat: 6.0,
    carbs: 24,
    protein: 4.0,
    sodium: 87,
    calcium: '14%',
    iron: '1%'
    
  },
  {
    name: 'Ice cream sandwich',
    calories: 237,
    fat: 9.0,
    carbs: 37,
    protein: 4.3,
    sodium: 129,
    calcium: '8%',
    iron: '1%'
  },
  {
    name: 'Eclair',
    calories: 262,
    fat: 16.0,
    carbs: 23,
    protein: 6.0,
    sodium: 337,
    calcium: '6%',
    iron: '7%'
  },
  {
    name: 'Cupcake',
    calories: 305,
    fat: 3.7,
    carbs: 67,
    protein: 4.3,
    sodium: 413,
    calcium: '3%',
    iron: '8%'
  },
  {
    name: 'Gingerbread',
    calories: 356,
    fat: 16.0,
    carbs: 49,
    protein: 3.9,
    sodium: 327,
    calcium: '7%',
    iron: '16%'
  },
  {
    name: 'Jelly bean',
    calories: 375,
    fat: 0.0,
    carbs: 94,
    protein: 0.0,
    sodium: 50,
    calcium: '0%',
    iron: '0%'
  },
  {
    name: 'Lollipop',
    calories: 392,
    fat: 0.2,
    carbs: 98,
    protein: 0,
    sodium: 38,
    calcium: '0%',
    iron: '2%'
  },
  {
    name: 'Honeycomb',
    calories: 408,
    fat: 3.2,
    carbs: 87,
    protein: 6.5,
    sodium: 562,
    calcium: '0%',
    iron: '45%'
  },
  {
    name: 'Donut',
    calories: 452,
    fat: 25.0,
    carbs: 51,
    protein: 4.9,
    sodium: 326,
    calcium: '2%',
    iron: '22%'
  },
  {
    name: 'KitKat',
    calories: 518,
    fat: 26.0,
    carbs: 65,
    protein: 7,
    sodium: 54,
    calcium: '12%',
    iron: '6%'
  }
]*/

import { defineComponent  , ref} from 'vue';
import axios from 'axios';

export default defineComponent({
  name: 'PageIndex',
  setup () {
    const loading = ref(false)
    const filter = ref('')
    const rowCount = ref(10)
    //const rows = ref([...originalRows])
    const rows1 = ref([]);
    const getBooks = () => {
      axios({
        url: "http://localhost:4000/api/book", 
        method: "GET"
      }).then((res) => {
        rows1.value = res.data
        console.log(rows1.value)
      })
    };
    getBooks();

    return {
      columns,
      rows1,

      loading,
      filter,
      rowCount,
    }
  }
})
</script>

<style scoped>
.header-1{
  margin: 0;
}
</style>