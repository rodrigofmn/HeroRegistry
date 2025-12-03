<template>
  <div class="create-page">
    <div class="card">
      <h2 class="title">Editar Herói</h2>

      <form @submit.prevent="salvarHeroi" class="form">
        <label>Nome</label>
        <input v-model="heroi.nome" required />

        <label>Nome de Herói</label>
        <input v-model="heroi.nomeHeroi" required />

        <label>Data de Nascimento</label>
        <input type="date" v-model="heroi.dataNascimento" required />

        <div class="inline">
          <div>
            <label class="input-heroi">Altura (m)</label>
            <input type="number" v-model="heroi.altura" required step="0.01" />
          </div>

          <div>
            <label class="input-heroi">Peso (kg)</label>
            <input type="number" v-model="heroi.peso" required />
          </div>
        </div>

        <label>Superpoderes</label>

        <div class="multi-select-wrapper" @click="alternarSelecao">
          <div class="selected-tags">
            <span v-if="poderSelecionado.length === 0" class="placeholder">
              Selecione superpoderes...
            </span>

            <div
              v-for="sp in poderSelecionado"
              :key="sp.id"
              class="tag"
            >
              {{ sp.superPoder }}
              <span class="remove" @click.stop="removerPoder(sp.id)">×</span>
            </div>
          </div>

          <div v-if="abrir" class="dropdown">
            <div
              class="option"
              v-for="sp in poderesFiltrados"
              :key="sp.id"
              @click.stop="alternarPoder(sp.id)"
              :class="{ selected: poderEstaSelecionado(sp.id) }"
            >
              {{ sp.superPoder }}
            </div>
          </div>
        </div>

        <button type="submit" class="button">Salvar</button>
      </form>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed, nextTick } from "vue";
import {
  atualizarHeroi,
  buscarHeroiPorId,
  buscarSuperPoderes
} from "../../services/heroesService";

import type { CriarHeroiExportDto } from "../../models/CriarHeroiExportDto";
import { useRoute, useRouter } from "vue-router";

const route = useRoute();
const router = useRouter();
const heroiId = Number(route.params.id);

const heroi = ref<CriarHeroiExportDto>({
  nome: "",
  nomeHeroi: "",
  dataNascimento: "",
  altura: 0,
  peso: 0,
  superPoderesIds: []
});

const todosPoderes = ref<{ id: number; superPoder: string }[]>([]);
const abrir = ref(false);

onMounted(async () => {
  try {
    const [poderesResponse, heroiResponse] = await Promise.all([
      buscarSuperPoderes(),
      buscarHeroiPorId(heroiId)
    ]);

    const poderesValidos = poderesResponse.filter((p: any) => {
      const possuiNome = p.superPoder && p.superPoder.trim() !== "";
      const possuiDescricao = p.superPoder && p.superPoder.trim() !== "";
      return possuiNome || possuiDescricao;
    });

    todosPoderes.value = poderesValidos.map((p: any) => {
      const superPoder = p.superPoder && p.superPoder.trim() !== "" 
        ? p.superPoder 
        : (p.superPoder && p.superPoder.trim() !== "" ? p.superPoder : "Sem nome");
      
      return {
        id: p.id,
        superPoder: superPoder
      };
    });

    let superPoderesIds: number[] = [];
    
    if (heroiResponse.superPoderesIds && Array.isArray(heroiResponse.superPoderesIds)) {
      superPoderesIds = heroiResponse.superPoderesIds;
    }

    const poderesIdsValidos = todosPoderes.value.map(p => p.id);
    const validaSuperPoderesIds = superPoderesIds.filter(id => 
      poderesIdsValidos.includes(id)
    );

    heroi.value = {
      nome: heroiResponse.nome || "",
      nomeHeroi: heroiResponse.nomeHeroi || "",
      altura: heroiResponse.altura || 0,
      peso: heroiResponse.peso || 0,
      dataNascimento: heroiResponse.dataNascimento 
        ? heroiResponse.dataNascimento.split("T")[0]
        : new Date().toISOString().split("T")[0],
      superPoderesIds: validaSuperPoderesIds.map(id => Number(id))
    };

    await nextTick();
  } catch (error) {
    alert("Erro ao carregar dados do herói.");
  }
});

const poderesFiltrados = computed(() => {
  return todosPoderes.value.filter(power => 
    power.superPoder !== "Sem nome" && 
    power.superPoder.trim() !== ""
  );
});

onMounted(() => {
  window.addEventListener("click", () => (abrir.value = false));
});

function alternarSelecao(e: MouseEvent) {
  e.stopPropagation();
  abrir.value = !abrir.value;
}

const poderSelecionado = computed(() => {
  return todosPoderes.value.filter(p => 
    heroi.value.superPoderesIds.includes(p.id)
  );
});

function poderEstaSelecionado(id: number) {
  return heroi.value.superPoderesIds.includes(id);
}

function alternarPoder(id: number) {
  const index = heroi.value.superPoderesIds.indexOf(id);
  if (index > -1) {
    heroi.value.superPoderesIds.splice(index, 1);
  } else {
    heroi.value.superPoderesIds.push(id);
  }
  heroi.value.superPoderesIds = [...heroi.value.superPoderesIds];
}

function removerPoder(id: number) {
  heroi.value.superPoderesIds = heroi.value.superPoderesIds.filter(x => x !== id);
}

async function salvarHeroi() {
  await atualizarHeroi(heroiId, heroi.value)
  .then(() => {
    alert("Herói criado com sucesso!");
    router.push("/heroes");
    heroi.value = new Object() as CriarHeroiExportDto;
  })
  .catch((error) => {
    alert(error?.response?.data ?? "Erro ao criar herói.");
  });
}
</script>


<style scoped>
.create-page {
  display: flex;
  justify-content: center;
}

.card {
  background: #ffffff;
  padding: 0.5rem 1rem;
  width: 100%;
  max-width: 100%;
  border-radius: 16px;
  border: 1px solid #e2e8f0;
  box-shadow: 0 8px 20px rgba(0,0,0,0.05);
}

.title {
  font-size: 1.8rem;
  font-weight: bold;
  margin-bottom: 25px;
  color: #0f172a;
}

.form {
  display: flex;
  flex-direction: column;
  gap: 18px;
}

input,
select {
  padding: 12px;
  border-radius: 10px;
  border: 1px solid #cbd5e1;
  font-size: 1rem;
  background: #f8fafc;
  transition: 0.2s;
}

input:focus,
select:focus {
  border-color: #3282b8;
  box-shadow: 0 0 0 3px rgba(50, 130, 184, 0.25);
  background: #fff;
  outline: none;
}

label {
  color: #475569;
  font-size: 0.95rem;
  font-weight: 500;
}

.inline {
  display: flex;
  gap: 16px;
}

.inline > div {
  flex: 1;
}

.multi-select-wrapper {
  position: relative;
  background: #f8fafc;
  border: 1px solid #cbd5e1;
  border-radius: 12px;
  padding: 10px;
  cursor: pointer;
  transition: 0.2s;
}

.multi-select-wrapper:hover {
  border-color: #1c768f;
}

.selected-tags {
  display: flex;
  flex-wrap: wrap;
  gap: 6px;
}

.placeholder {
  color: #94a3b8;
}

.tag {
  background: #1c768f;
  color: white;
  padding: 6px 10px;
  border-radius: 8px;
  display: flex;
  align-items: center;
  gap: 6px;
  font-size: 0.85rem;
}

.remove {
  cursor: pointer;
  font-weight: bold;
}

.dropdown {
  position: absolute;
  left: 0;
  right: 0;
  background: white;
  border: 1px solid #cbd5e1;
  border-radius: 10px;
  margin-top: 8px;
  max-height: 180px;
  overflow-y: auto;
  box-shadow: 0 6px 15px rgba(0,0,0,0.1);
  z-index: 5;
}

.option {
  padding: 10px 12px;
  cursor: pointer;
  border-radius: 6px;
  transition: 0.15s;
}

.option:hover {
  background: #e2e8f0;
}

.option.selected {
  background: #1c768f;
  color: white;
}

.button {
  margin-top: 10px;
  padding: 0.9rem 2rem;
  border-radius: 14px;
  border: none;
  background: linear-gradient(135deg, #1C768F, #2D93AD);
  color: white;
  cursor: pointer;
  font-size: 1.05rem;
  font-weight: 600;

  box-shadow:
    0 4px 10px rgba(28, 118, 143, 0.4),
    0 0 10px rgba(45, 147, 173, 0.3);

  transition: all 0.25s ease;
  position: relative;
  overflow: hidden;
}

.button:hover {
  background: linear-gradient(135deg, #2289A3, #37AACC);
}

.button::after {
  content: "";
  position: absolute;
  top: 0;
  left: -100%;
  width: 100%;
  height: 100%;
}

.input-heroi {
  margin-right: 1rem;
}
</style>
