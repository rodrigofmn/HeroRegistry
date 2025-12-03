<template>
  <div class="heroes-page">

    <div class="header">
      <h2 class="title">Lista de Heróis</h2>
      <button @click="openHeroCreate" class="button">
        <b>Adicionar Herói</b>
      </button>
    </div>

    <div v-if="loading" class="loading">
      Carregando heróis...
    </div>

    <div v-else-if="heroes.length === 0" class="empty">
      <p>Nenhum herói cadastrado ainda.</p>
    </div>

    <ul class="hero-list">
    <li class="hero-card" v-for="heroi in heroes" :key="heroi.id">
      <div class="hero-info" @click="openHero(heroi.id)">
        <strong class="hero-name">{{ heroi.nomeHeroi }}</strong>
        <span class="hero-real">{{ heroi.nome }}</span>
      </div>
      <div class="actions">
        <button class="edit-btn" @click="editHero(heroi.id)">Editar</button>
        <button class="delete-btn" @click="deleteHero(heroi.id)">Excluir</button>
      </div>
    </li>

    </ul>

  </div>
</template>


<script setup lang="ts">
import { onMounted, ref } from "vue";
import { deletarHeroi, buscarHerois } from "../../services/heroesService";
import { useRouter } from "vue-router";

interface Heroi {
  id: number;
  nome: string;
  nomeHeroi: string;
}

const heroes = ref<Heroi[]>([]);
const loading = ref(true);
const router = useRouter();

onMounted(async () => {
  heroes.value = await buscarHerois();
  loading.value = false;
});

function openHero(id: number) {
  router.push(`/heroes/${id}`);
}

function openHeroCreate() {
  router.push("/heroes/create");
}

function editHero(id: number) {
  router.push(`/heroes/${id}`);
}

function deleteHero(id: number) {
  if (confirm("Tem certeza que deseja excluir este herói?")) {
    deletarHeroi(id);
    heroes.value = heroes.value.filter(h => h.id !== id);
  }
}
</script>

<style scoped>
.heroes-page {
  width: 100%;
  max-width: 100%;
  padding: 0 20px;
}

.header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 25px;
}

.title {
  font-size: 2rem;
  font-weight: 600;
  color: #1e293b;
}

.loading,
.empty {
  font-size: 1.1rem;
  color: #475569;
  margin-top: 20px;
}

.hero-list {
  margin-top: 20px;
  padding: 0;
  list-style: none;
}

.hero-card {
  background: white;
  padding: 18px;
  margin-bottom: 15px;
  border-radius: 12px;
  cursor: pointer;
  display: flex;
  justify-content: space-between;
  align-items: center;

  border: 1px solid #e2e8f0;
  transition: 0.25s;
}

.hero-card:hover {
  transform: translateY(-3px);
  background: #f8fafc;
  box-shadow: 0 6px 18px rgba(0,0,0,0.07);
}

.hero-name {
  font-size: 1.1rem;
  color: #0f172a;
  font-weight: 600;
}

.hero-real {
  font-size: 0.95rem;
  color: #64748b;
}

.button {
  padding: 0.9rem 2rem;
  border-radius: 12px;
  border: none;
  background: linear-gradient(135deg, #2D93AD, #1C768F);
  color: white;
  cursor: pointer;
  font-size: 15px;
  font-weight: 500;
  transition: 0.25s;
  box-shadow: 0 4px 14px rgba(0, 140, 160, 0.25);
}

.button:hover {
  background: linear-gradient(135deg, #37AACC, #2289A3);
  transform: translateY(-2px);
}

.hero-info {
  display: flex;
  flex-direction: column;
  cursor: pointer;
}

.actions {
  display: flex;
  gap: 10px;
}

.edit-btn,
.delete-btn {
  padding: 6px 12px;
  font-size: 0.85rem;
  border-radius: 8px;
  border: none;
  cursor: pointer;
  font-weight: 600;
  transition: 0.2s;
}

.edit-btn {
  background: #2563eb;
  color: white;
}

.edit-btn:hover {
  background: #1d4ed8;
}

.delete-btn {
  background: #dc2626;
  color: white;
}

.delete-btn:hover {
  background: #b91c1c;
}
</style>
