<template>
  <Dropdown v-model="selectedPaginationType" :options="paginationTypes" optionLabel="label" placeholder="Select a Pagination Type" class="w-full md:w-14rem" />
  <Pagination v-if="selectedPaginationType.value === '2'"/>
  <InfiniteScrolling v-if="selectedPaginationType.value === '1'"></InfiniteScrolling>
</template>

<script>
import Pagination from './components/Pagination.vue'
import InfiniteScrolling from './components/InfiniteScrolling.vue';
import Dropdown from 'primevue/dropdown';

export default {
  name: 'App',
  components: {
    Pagination,
    Dropdown,
    InfiniteScrolling
  },
  data() {
    return {
      paginationTypes : [
        { label: 'Infinite Scrolling', value: '1' },
        { label: 'Pagination', value: '2' },
      ],
      selectedPaginationType : ""
    };
  },
  methods: {
    
  },
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
