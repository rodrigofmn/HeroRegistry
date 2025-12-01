<template>
  <div>
    <h2>Criar Herói</h2>

    <form @submit.prevent="saveHero" class="form">
      <label>Nome</label>
      <input v-model="nome" required />

      <label>Nome de Herói</label>
      <input v-model="nomeHeroi" required />

      <label>Data de Nascimento</label>
      <input type="date" v-model="dataNascimento" required />

      <label>Altura (m)</label>
      <input type="number" v-model="altura" required step="0.01" />

      <label>Peso (kg)</label>
      <input type="number" v-model="peso" required />

      <label>Superpoderes</label>
      <select v-model="superpoderes" multiple required>
        <option v-for="sp in powers" :key="sp.id" :value="sp.id">
          {{ sp.descricao }}
        </option>
      </select>

      <button type="submit">Salvar</button>
    </form>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import { createHero, getSuperpowers } from "../../services/heroesService";

const nome = ref("");
const nomeHeroi = ref("");
const dataNascimento = ref("");
const altura = ref(0);
const peso = ref(0);
const superpoderes = ref<number[]>([]);

const powers = ref<{ id: number; descricao: string }[]>([]);

onMounted(async () => {
  powers.value = await getSuperpowers();
});

async function saveHero() {
  await createHero({
    nome: nome.value,
    nomeHeroi: nomeHeroi.value,
    dataNascimento: dataNascimento.value,
    altura: altura.value,
    peso: peso.value,
    superpoderes: superpoderes.value,
  });

  alert("Herói criado com sucesso!");
}
</script>

<style scoped>
.form {
  display: flex;
  flex-direction: column;
  gap: 12px;
  max-width: 400px;
}
</style>
