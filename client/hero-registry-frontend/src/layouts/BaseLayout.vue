<template>
  <div class="layout-container">
    <aside class="sidebar">
      <div class="logo">HeroRegistry</div>

      <nav class="menu">
        <RouterLink
          v-for="item in menuItems"
          :key="item.path"
          :to="item.path"
          class="menu-item"
          active-class="active"
        >
          {{ item.label }}
        </RouterLink>
      </nav>
    </aside>

    <main class="content">
      <header class="header">
        <h1>{{ title }}</h1>
      </header>

      <section class="page-body">
        <RouterView />
      </section>
    </main>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';

const title = ref("Dashboard");

const menuItems = [
  { label: "Home", path: "/" },
  { label: "Heróis", path: "/heroes" },
  { label: "Criar Herói", path: "/heroes/create" },
];
</script>

<style scoped>
.layout-container {
  display: flex;
  height: 100vh;
  width: 100vw;
  overflow: hidden;
  background: #f3f4f6;
}

.sidebar {
  width: 240px;
  background: #1e293b;
  color: #fff;
  display: flex;
  flex-direction: column;
  padding: 20px;
}

.logo {
  font-size: 1.4rem;
  font-weight: bold;
  margin-bottom: 30px;
}

.menu {
  display: flex;
  flex-direction: column;
  gap: 12px;
}

.menu-item {
  padding: 10px 14px;
  border-radius: 8px;
  text-decoration: none;
  color: #cbd5e1;
  font-size: 0.97rem;
  transition: 0.2s;
}

.menu-item:hover {
  background: #334155;
  color: #fff;
}

.active {
  background: #475569;
  color: #fff;
}

.content {
  flex: 1;
  display: flex;
  flex-direction: column;
}

.header {
  padding: 20px;
  background: #fff;
  box-shadow: 0 1px 4px rgba(0,0,0,0.1);
}

.page-body {
  padding: 20px;
  overflow-y: auto;
  height: calc(100vh - 70px);
}
</style>
