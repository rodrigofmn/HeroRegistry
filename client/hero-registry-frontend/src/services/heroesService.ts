import type { CriarHeroiExportDto } from "../models/CriarHeroiExportDto";
import api from "./api";

export async function buscarHerois() {
  const res = await api.get("/herois");
  return res.data;
}

export async function buscarHeroiPorId(id: number) {
  const res = await api.get(`/herois/${id}`);
  return res.data;
}

export async function criarHeroi(heroi: CriarHeroiExportDto) {
  const res = await api.post("/herois", heroi);
  return res.data;
}

export async function buscarSuperPoderes() {
  const res = await api.get("/superpoderes");
  return res.data;
}

export async function atualizarHeroi(id: number, heroi: CriarHeroiExportDto) {
  const res = await api.put(`/herois/${id}`, heroi);
  return res.data;
}

export async function deletarHeroi(id: number) {
  const res = await api.delete(`/herois/${id}`);
  return res.data;
}
