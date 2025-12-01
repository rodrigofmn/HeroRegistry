<template>
  <div>
    <h2>Lista de Heróis</h2>

    <div v-if="loading">Carregando heróis...</div>

    <div v-else-if="heroes.length === 0">
      <p>Nenhum herói cadastrado ainda.</p>
    </div>

    <ul class="hero-list">
      <li
        v-for="hero in heroes"
        :key="hero.id"
        @click="openHero(hero.id)"
        class="hero-item"
      >
        <strong>{{ hero.nomeHeroi }}</strong> — {{ hero.nome }}
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import { getHeroes } from "../../services/heroesService";
import { useRouter } from "vue-router";

interface Hero {
  id: number;
  nome: string;
  nomeHeroi: string;
}

const heroes = ref<Hero[]>([]);
const loading = ref(true);
const router = useRouter();

onMounted(async () => {
  heroes.value = await getHeroes();
  loading.value = false;
});

function openHero(id: number) {
  router.push(`/heroes/${id}`);
}
</script>

<style scoped>
.hero-list {
  margin-top: 20px;
  padding: 0;
  list-style: none;
}

.hero-item {
  background: #fff;
  padding: 12px;
  margin-bottom: 10px;
  border-radius: 8px;
  cursor: pointer;
  transition: 0.2s;
}

.hero-item:hover {
  background: #f1f5f9;
}
</style>
