<div align="center">

# Sistema de Gerenciamento de Tarefas (Back & Front)

<img src="https://capsule-render.vercel.app/api?type=rect&amp;color=C587A7&amp;height=2&amp;width=100%" />

![.NET](https://img.shields.io/badge/.NET-6%2B-0f172a?style=flat-square&logo=dotnet&logoColor=FFB3DE)
![C#](https://img.shields.io/badge/C%23-0f172a?style=flat-square&logo=csharp&logoColor=C587A7)
![Angular](https://img.shields.io/badge/Angular-15%2B-0f172a?style=flat-square&logo=angular&logoColor=FFB3DE)
![TypeScript](https://img.shields.io/badge/TypeScript-0f172a?style=flat-square&logo=typescript&logoColor=C587A7)
![EF Core](https://img.shields.io/badge/EF_Core-0f172a?style=flat-square&logo=dotnet&logoColor=FFB3DE)
![SQLite](https://img.shields.io/badge/SQLite-0f172a?style=flat-square&logo=sqlite&logoColor=C587A7)
![Swagger](https://img.shields.io/badge/Swagger-0f172a?style=flat-square&logo=swagger&logoColor=FFB3DE)

</div>

Projeto desenvolvido em squad como desafio prático final do módulo de **Desenvolvimento de APIs com .NET** durante o bootcamp da **WoMakersCode** 💜.

## Apresentação

Este projeto prático tem como objetivo reunir tudo o que foi estudado ao longo do módulo em uma única aplicação funcional.

A aplicação consiste em um **Sistema de Gerenciamento de Tarefas com Cadastro de Usuária**, permitindo que uma usuária se cadastre, acesse o sistema e gerencie suas próprias tarefas.

## Tecnologias Utilizadas

### Back-end (API .NET)
- **.NET** (Versão 6 ou superior)
- **C#**
- **Entity Framework Core** (com Migrations)
- **SQLite** (ou SQL Server / MySQL)
- **Data Annotations** (validação de dados)
- **Swagger** (documentação de endpoints)

### Front-end (Angular)
- **Angular** (Versão 15 ou superior)
- **TypeScript**
- **HttpClient** (consumo da API)

### Outras Ferramentas
- **Git e GitHub**

## Funcionalidades da API

- **Cadastro de Usuária:** Nome, e-mail e senha.
- **Gerenciamento de Tarefas:**
  - Listagem de todas as tarefas de uma usuária.
  - Cadastro de nova tarefa (título, descrição, data de vencimento e status).
  - Atualização de tarefa existente.
  - Exclusão de tarefa.
  - Marcação de tarefa como concluída.

## Funcionalidades do Front-end (Angular)

- Tela de cadastro de usuária.
- Tela de listagem de tarefas.
- Formulário para criar e editar tarefas.
- Botões de ação rápida para marcar como concluída ou excluir.
- Tratamento de erros de requisição e confirmações visuais.

## Como Executar o Projeto

1. Clone o repositório em sua máquina local:
   ```bash
   git clone <url-do-repositorio>
   ```

2. **Executando o Back-end (.NET):**
   - Navegue até a pasta do projeto da API.
   - Restaure as dependências e execute as migrações do banco de dados:
     ```bash
     dotnet restore
     dotnet ef database update
     ```
   - Inicie a aplicação:
     ```bash
     dotnet run
     ```
   - Acesse o Swagger para testar os endpoints em `https://localhost:<porta>/swagger`.

3. **Executando o Front-end (Angular):**
   - Navegue até a pasta do projeto Angular.
   - Instale as dependências:
     ```bash
     npm install
     ```
   - Inicie o servidor de desenvolvimento:
     ```bash
     ng serve
     ```
   - Acesse a aplicação no navegador em `http://localhost:4200`.

## Squad Dorothy Vaughan

- Bruna Cruz
- Josiane Fatima
- Maria Luiza
- Nayara Francelino