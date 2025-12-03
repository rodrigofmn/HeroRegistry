# 🦸‍♂️ Hero Registry – Full Stack Hero Management System

Sistema completo para gerenciamento de super-heróis, desenvolvido em **.NET 8**, **Vue 3**, **Clean Architecture**, **Entity Framework**, **MediatR**, **FluentValidation**, **AutoMapper** e **XUnit**.

---

## 🚀 Tecnologias Utilizadas

### 🟦 Backend
- .NET 8  
- Clean Architecture  
- Entity Framework Core  
- MediatR (CQRS)  
- FluentValidation  
- AutoMapper  
- Swagger  
- XUnit  

### 🟩 Frontend
- Vue 3  
- Vite  
- Axios  

---

## 📂 Estrutura do Projeto

```txt
/
├── server/
│   └── src/
│       ├── HeroRegistry.Api/          # API (.NET 8)
│       ├── HeroRegistry.Domain/       # Entidades e regras de domínio
│       ├── HeroRegistry.Application/  # Handlers, Commands, Validations
│       ├── HeroRegistry.Repository/   # EF Core
│       └── HeroRegistry.Tests/        # XUnit Tests
│
└── client/
    └── hero-registry-frontend/        # Vue 3 + Vite frontend
```

---

## ✨ Funcionalidades
- Cadastro de herói  
- Consulta de heróis com paginação  
- Consulta por ID  
- Atualização de herói  
- Exclusão de herói  
- Associação de superpoderes  
- Validação de dados  
- Garantia de nome de herói único  
- Documentação automática via Swagger  
- Testes unitários  

---

## 🛠️ Como Rodar o Projeto

### 📌 1️⃣ Rodando o Backend (.NET 8)
**Requisitos:**  
- .NET 8 SDK instalado  

**Passo a passo:**
```bash
cd server/src/HeroRegistry.Api
dotnet run

Acesse a documentação do Swagger no link gerado ao rodar o sistema:
-ex.:http://localhost:5001/swagger
```
### 📌 2️⃣ Rodando o Frontend (Vue 3 + Vite)

**Requisitos:**
- Node.js (versão 18+ recomendada)
- NPM ou Yarn

**Passo a passo:**
```bash
cd client/hero-registry-frontend
npm install
npm run dev
```
🔌 Configurando a String de Conexão (appsettings.json)

No backend, configure sua conexão com o banco de dados editando o arquivo appsettings.json:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=RODRIGO\\SQL;Database=HeroRegistryNovoaa;User ID=sa;Password=123qwe;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },

  "AllowedHosts": "*"
}
```
🧪 Testes Unitários (XUnit)

Para rodar os testes do backend:
```
cd server/src/HeroRegistry.Tests
dotnet test
```

🏗️ Arquitetura – Clean Architecture + CQRS

O backend segue princípios de arquitetura limpa:

Domain: Entidades e regras de negócio

Application: Commands, Handlers, validações (FluentValidation), DTOs

Repository: Implementações do EF Core

Api: Controllers, rotas, Swagger, DI

Comunicação entre camadas via MediatR, seguindo o padrão CQRS.

📘 Endpoints Principais
```
GET /api/herois?pagina=1&tamanhoPagina=10 → Lista heróis paginados

GET /api/herois/{id} → Busca um herói por ID

POST /api/herois → Cria um herói

PUT /api/herois/{id} → Atualiza um herói

DELETE /api/herois/{id} → Remove um herói
```
📄 Observações Importantes

Nome de herói é único (não permite duplicação)

Superpoderes são associados via tabela de relação

Respostas seguem boas práticas HTTP

Swagger documenta todos os endpoints

Repositório modular e organizado
