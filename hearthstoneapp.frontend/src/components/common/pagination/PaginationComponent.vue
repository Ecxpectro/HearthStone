<template>
  <div :class="$style.pagination">
    <button :disabled="currentPage === 1 || !Array.isArray(cards) || cards.length === 0" @click="changePage(currentPage - 1)" :class="$style.previousButton">Previous</button>
    <span v-for="page in visiblePages" :key="page" :class="{ [$style.active]: page === currentPage }">
      <button type="button" @click="changePage(page)" :class="$style.numberFilterButton">{{ page }}</button>
    </span>
    <button type="button" :disabled="currentPage === totalPages || !Array.isArray(cards) || cards.length === 0" @click="changePage(currentPage + 1)" :class="$style.nextButton">Next</button>
  </div>
</template>

<script lang="ts">
  import { defineComponent, PropType, computed } from 'vue';

  export default defineComponent({
    name: 'Pagination',
    props: {
      currentPage: {
        type: Number,
        required: true,
      },
      totalRecords: {
        type: Number,
        required: true,
      },
      cards: {
        type: Object as PropType<any>,
        required: true,
      },
      pageSize: {
        type: Number,
        default: 2,
      },
    },
    emits: ['changePage'],
    setup(props, { emit }) {
      const totalPages = computed(() => Math.ceil(props.totalRecords / props.pageSize));
      const visiblePages = computed(() => {
        const start = Math.max(1, props.currentPage - 2);
        const end = Math.min(totalPages.value, start + 4);
        return Array.from({ length: end - start + 1 }, (_, i) => start + i);
      });
      const cards = props.cards;
      console.log(cards);
      const changePage = (page: number) => {
        if (page !== props.currentPage && page > 0 && page <= totalPages.value) {
          emit('changePage', page);
        }
      };

      return { totalPages, visiblePages, changePage };
    },
  });
</script>

<style module>
  @import '../../../assets/styles/pagination.module.css';
</style>
