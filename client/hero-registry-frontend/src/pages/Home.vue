<template>
  <div class="home-container">
    <div class="card">
      <h2 class="title">Bem-vindo ao HeroRegistry</h2>
      <p class="subtitle">Gerencie seus super-heróis com facilidade!</p>
    </div>
  </div>
</template>

<script setup lang="ts"></script>

<style scoped>
.home-container {
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 60px 20px;
  width: 100%;
}

.card {
  background: #ffffff;
  padding: 40px 50px;
  border-radius: 18px;
  border: 1px solid #e2e8f0;
  box-shadow: 0 10px 25px rgba(0,0,0,0.06);
  min-width: 80%;
  max-width: 90%;
  text-align: center;
}

.title {
  font-size: 2.2rem;
  font-weight: 700;
  color: #0f172a;
  margin-bottom: 12px;
}

.subtitle {
  font-size: 1.2rem;
  color: #475569;
}
</style>
