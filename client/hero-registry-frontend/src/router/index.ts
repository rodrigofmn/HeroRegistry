import { createRouter, createWebHistory } from "vue-router";

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: "/",
      name: "home",
      component: () => import("../pages/Home.vue"),
    },
    {
      path: "/heroes",
      name: "heroes",
      component: () => import("../pages/Heroes/HeroesList.vue"),
    },
    {
      path: "/heroes/create",
      name: "heroes-create",
      component: () => import("../pages/Heroes/HeroesCreate.vue"),
    },
    {
      path: "/heroes/:id",
      name: "hero-details",
      component: () => import("../pages/Heroes/HeroesDetails.vue"),
      props: true,
    },
  ],
});

export default router;
