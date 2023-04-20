<template>
  <div>
    <div style="margin-top: 30px; margin-bottom: 50px">
      <Paginator
        class="container col-md-7"
        v-model="currentPage"
        :totalRecords="totalRows"
        :rows="pageSize"
        :paginatorTemplate="paginatorTemplate"
        :rowsPerPageOptions="[10, 20, 30]"
        @page="handlePageSizeChange"
      >
        <template #start="slotProps">
          <b>Page: </b> {{ slotProps.state.page + 1 }} <b>Rows per Page: </b>
          {{ slotProps.state.rows }}
        </template>
      </Paginator>
    </div>

    <div class="container col-md-6">
      <div class="card-container">
        <div v-for="product in products" :key="product.id" class="card">
          <img
            :src="product.imageUrl"
            class="card-img-top"
            alt="Product Image"
          />
          <div class="card-body">
            <h5 class="card-title">{{ product.name }}</h5>
            <p class="card-text">{{ product.description }}</p>
            <p class="card-text" style="font-weight: bold; color: gray">
              {{ product.brand }}
            </p>
            <p class="card-text" style="font-weight: bold; color: gray">
              {{ product.category }}
            </p>
            <p class="card-text">{{ Math.floor(product.price) }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import Paginator from "primevue/paginator";
export default {
  name: "ProductList",
  components: {
    Paginator,
  },
  data() {
    return {
      products: [],
      currentPage: 1,
      pageSize: 10,
      totalRows: 0,
      paginatorTemplate:
        "CurrentPageReport FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink RowsPerPageDropdown",
    };
  },
  methods: {
    fetchProducts() {
      axios
        .get(
          `https://localhost:7079/Pagination?page=${this.currentPage}&pageSize=${this.pageSize}`
        )
        .then((response) => {
          console.log(response.data.items);
          this.products = response.data.items;
          this.totalRows = response.data.totalRecord;
        })
        .catch((error) => {
          console.error(error);
        });
    },

    handlePageSizeChange(event) {
      console.log(event.page);
      this.currentPage = event.page + 1;
      this.pageSize = event.rows;
      this.fetchProducts();
    },
  },
  created() {
    this.fetchProducts();
  },
};
</script>

<style scoped>
.card-container {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  grid-gap: 1rem;
}
</style>
