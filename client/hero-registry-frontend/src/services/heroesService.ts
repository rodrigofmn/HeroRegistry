import type { CriarHeroiExportDto } from "../models/CriarHeroiExportDto";
import api from "./api";

export async function getHeroes() {
  const res = await api.get("/herois");
  return res.data;
}

export async function getHeroById(id: number) {
  const res = await api.get(`/herois/${id}`);
  return res.data;
}

export async function createHero(heroi: CriarHeroiExportDto) {
  const res = await api.post("/herois", heroi);
  return res.data;
}

export async function getSuperpowers() {
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
