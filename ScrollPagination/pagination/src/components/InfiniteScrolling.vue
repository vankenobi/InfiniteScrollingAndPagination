<template>
  <div class="container" style="margin-top: 30px; margin-bottom: 50px">
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
            <p class="card-text">{{ Math.floor(product.price) }}</p>
          </div>
        </div>
      </div>
    </div>
    <div ref="observer"></div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "App",
  components: {
  },
  data() {
    return {
      products: [],
      currentPage: 1,
      pageSize: 10,
      loading : false,
      observer : null,
    };
  },
  mounted() {
    this.observer = new IntersectionObserver(this.loadMore, {
      rootMargin: '100px'
    });
    this.observer.observe(this.$refs.observer);
  },
  methods: {
    async loadMore(entries) {
      console.log(entries);
      const entry = entries[0];
      if (entry.isIntersecting && !this.loading) {
        this.loading = true;
        axios
          .get(`https://localhost:7079/Pagination?page=${this.currentPage}&pageSize=${this.pageSize}`)
          .then((response) => {
            const newProducts = response.data.items;
            this.products = [...this.products, ...newProducts];
            this.currentPage++;
            this.loading = false;
          })
          .catch((error) => {
            console.error(error);
          });
        
      }
    }
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