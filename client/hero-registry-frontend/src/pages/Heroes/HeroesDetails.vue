<template>
  <div>
    <h2>Detalhes do Herói</h2>

    <div v-if="loading">Carregando...</div>

    <div v-else>
      <p><strong>Nome:</strong> {{ hero?.nome }}</p>
      <p><strong>Nome de Herói:</strong> {{ hero?.nomeHeroi }}</p>
      <p><strong>Peso:</strong> {{ hero?.peso }} kg</p>
      <p><strong>Altura:</strong> {{ hero?.altura }} m</p>
      <p><strong>Superpoderes:</strong></p>

      <ul>
        <li v-for="sp in hero?.superpoderes" :key="sp.id">{{ sp.descricao }}</li>
      </ul>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import { getHeroById } from "../../services/heroesService";
import { useRoute } from "vue-router";

const hero = ref<any>(null);
const loading = ref(true);

const route = useRoute();
const id = Number(route.params.id);

onMounted(async () => {
  hero.value = await getHeroById(id);
  loading.value = false;
});
</script>
