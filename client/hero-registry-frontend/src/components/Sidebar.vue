<template>
  <div>
    <aside class="sidebar">
      <div class="logo">HeroRegistry</div>

      <div class="divider"></div>

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
  </div>
</template>

<script lang="ts" setup>

const menuItems = [
    { label: "Home", path: "/" },
    { label: "Heróis", path: "/heroes" },
    { label: "Criar Herói", path: "/heroes/create" },
];
</script>

<style scoped>
.sidebar {
  width: 250px;
  height: 100vh;
  background: linear-gradient(180deg, #0f172a, #1e293b);
  color: #fff;

  display: flex;
  flex-direction: column;
  padding: 30px 22px;
  border-radius: 0 20px 20px 0;
  box-shadow: 4px 0 20px rgba(0, 0, 0, 0.15);
}

.logo {
  font-size: 1.6rem;
  font-weight: 800;
  margin-bottom: 25px;
  letter-spacing: 1px;
  color: #f8fafc;
  text-transform: uppercase;
}

.divider {
  width: 100%;
  height: 1px;
  background: rgba(255, 255, 255, 0.15);
  margin-bottom: 25px;
}

.menu {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.menu-item {
  padding: 12px 16px;
  border-radius: 10px;
  text-decoration: none;
  color: #cbd5e1;
  font-size: 1rem;
  font-weight: 500;

  display: block;
  transition: 0.25s ease;
}

.menu-item:hover {
  background: rgba(57, 242, 255, 0.822);
  color: #fff;
}

.active {
  background: #38bdf8;
  color: #0f172a !important;
  font-weight: 700;
  box-shadow: 0 0 10px rgba(56, 189, 248, 0.4);
}
</style>