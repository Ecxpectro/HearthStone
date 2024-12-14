<template>
  <tr>
    <td>
      <img :src="card.img || 'https://via.placeholder.com/50'" alt="Card Image" height="120" />
    </td>
    <td :class="$style.columnName">{{ card.name || 'N/A' }}</td>
    <td>{{ card.type || 'N/A' }}</td>
    <td :class="$style.columnFlavor">{{ card.flavor || 'N/A' }}</td>
    <td>{{ card.cardSetDto?.name || 'N/A' }}</td>
    <td>{{ card.playerClassDto?.name || 'N/A' }}</td>
    <td>{{ card.rarityDto?.name || 'N/A' }}</td>
    <td>{{ card.artistDto?.name || 'N/A' }}</td>
    <td :class="$style.cost">{{ card.cost || 'N/A' }}</td>
  </tr>
</template>

<script lang="ts">
  import { defineComponent, PropType } from 'vue';

  export default defineComponent({
    name: 'CardTableRow',
    props: {
      card: {
        type: Object as PropType<any>,
        required: true,
      },
    },
  });
</script>

<style module>
  @import '../../assets/styles/cardTableRow.module.css';
</style>

