import api from "./api";

export async function getHeroes() {
  const res = await api.get("/heroes");
  return res.data;
}

export async function getHeroById(id: number) {
  const res = await api.get(`/heroes/${id}`);
  return res.data;
}

export async function createHero(hero: any) {
  const res = await api.post("/heroes", hero);
  return res.data;
}

export async function getSuperpowers() {
  const res = await api.get("/superpoderes");
  return res.data;
}
