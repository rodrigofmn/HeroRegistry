<template>
  <div class="layout-container">
    <sidebar style="height: 100%;"/>
    <main class="content">
      <section class="page-body">
        <RouterView />
      </section>
    </main>
  </div>
</template>

<script lang="ts" setup>
import Sidebar from "../components/Sidebar.vue";
</script>

<style scoped>
.layout-container {
  display: flex;
  height: 100vh;
  width: 100%;
  overflow: hidden;
  background: #f3f4f6;
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
  overflow-y: auto;
  height: 100%;
  padding: 1rem 3rem;
}
</style>
