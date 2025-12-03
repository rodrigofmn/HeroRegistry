🦸‍♂️ Hero Registry – Full Stack Hero Management System

Aplicação Full Stack para gerenciamento de super-heróis, desenvolvida como desafio técnico utilizando .NET 8, Vue 3, Clean Architecture, Entity Framework, Fluent Validation, MediatR, AutoMapper e XUnit.

🚀 Tecnologias Utilizadas
Backend (Server)

.NET 8

C#

Clean Architecture

Entity Framework Core

EF InMemory ou Banco relacional

MediatR (Padrão CQRS)

FluentValidation

AutoMapper

Swagger

XUnit (Testes unitários)

Frontend (Client)

Vue 3

Vite

TypeScript (opcional, caso você tenha usado)

Axios

📂 Estrutura do Projeto
/
├── server/
│   ├── src/
│   │   ├── HeroRegistry.Api/          # API (.NET 8)
│   │   ├── HeroRegistry.Domain/       # Entidades e regras de domínio
│   │   ├── HeroRegistry.Application/  # Handlers, comandos, validações
│   │   ├── HeroRegistry.Repository/   # Implementação do EF Core
│   │   └── HeroRegistry.Tests/        # Testes com XUnit
│   └── README.md (este arquivo)
│
└── client/
    └── hero-registry-frontend/        # Aplicação Vue 3 + Vite

✨ Funcionalidades

Cadastro de herói

Consulta de heróis com paginação

Consulta por ID

Atualização de herói

Exclusão de herói

Associação de superpoderes

Validação de dados

Garantia de nome de herói único

Documentação automática via Swagger

Testes unitários

🛠️ Como Rodar o Projeto

Abaixo estão as instruções completas para rodar backend e frontend.

📌 1️⃣ Rodando o Backend (.NET 8)
📍 Requisitos

.NET 8 SDK instalado

▶️ Passo a passo

Abra um terminal na raiz do projeto:

cd server/src/HeroRegistry.Api


Execute o backend:

dotnet run


A API estará disponível em:

https://localhost:5001
http://localhost:5000


Acesse o Swagger em:

https://localhost:5001/swagger

📌 2️⃣ Rodando o Frontend (Vue 3 + Vite)
📍 Requisitos

Node.js (versão 18+ recomendada)

NPM ou Yarn

▶️ Passo a passo

Abra um terminal:

cd client/hero-registry-frontend


Instale as dependências:

npm install


Rode o servidor de desenvolvimento:

npm run dev

🔌 Como configurar a string de conexão no appsettings.json

No arquivo appsettings.json, adicione ou edite a seção ConnectionStrings:

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


Acesse:

http://localhost:5173

🧪 Testes Unitários (XUnit)

Para rodar os testes:

cd server/src/HeroRegistry.Tests
dotnet test

🏗️ Arquitetura – Clean Architecture + CQRS

O backend segue princípios de arquitetura limpa:

Domain → Entidades, regras de negócio

Application → Commands, Handlers, validações (FluentValidation), DTOs

Repository → Implementações do EF Core

Api → Controllers, rotas, Swagger, DI

Comunicação entre camadas via MediatR, seguindo CQRS.

📘 Endpoints Principais
GET /api/herois?pagina=1&tamanhoPagina=10

Lista heróis paginados.

GET /api/herois/{id}

Busca um herói por ID.

POST /api/herois

Cria um herói.

PUT /api/herois/{id}

Atualiza um herói.

DELETE /api/herois/{id}

Remove um herói.

📄 Observações Importantes

Nome de herói é único (não permite duplicação).

Superpoderes são associados via tabela de relação.

Respostas seguem boas práticas HTTP.

Swagger documenta todos os endpoints.

Repositório dividido de forma limpa e modular.

🎯 Conclusão

Este projeto demonstra:

Implementação completa de CRUD

Arquitetura robusta e escalável

Boas práticas de desenvolvimento

Testes unitários

Integração de frontend e backend
