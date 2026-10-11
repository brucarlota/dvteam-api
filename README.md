<div align="center">

### Sistema de Gerenciamento de Tarefas (Back & Front)

<img src="https://capsule-render.vercel.app/api?type=rect&color=C587A7&height=2&width=100%" />

![.NET](https://img.shields.io/badge/.NET-10-0f172a?style=flat-square&logo=dotnet&logoColor=FFB3DE)
![C#](https://img.shields.io/badge/C%23-0f172a?style=flat-square&logo=csharp&logoColor=C587A7)
![Angular](https://img.shields.io/badge/Angular-0f172a?style=flat-square&logo=angular&logoColor=FFB3DE)
![TypeScript](https://img.shields.io/badge/TypeScript-0f172a?style=flat-square&logo=typescript&logoColor=C587A7)
![EF Core](https://img.shields.io/badge/EF_Core-0f172a?style=flat-square&logo=dotnet&logoColor=FFB3DE)
![SQLite](https://img.shields.io/badge/SQLite-0f172a?style=flat-square&logo=sqlite&logoColor=C587A7)
![Swagger](https://img.shields.io/badge/Swagger-0f172a?style=flat-square&logo=swagger&logoColor=FFB3DE)

</div>

Projeto desenvolvido em squad como desafio prático final do módulo de **Desenvolvimento de APIs com .NET** durante o bootcamp da **WoMakersCode** 💜.

---

## 👩‍💻 Squad Dorothy Vaughan

Desenvolvido com dedicação por:

- **Bruna Cruz**
- **Josiane Fatima**
- **Maria Luiza**
- **Nayara Francelino**

---

## Apresentação

Este projeto prático tem como objetivo reunir os principais conceitos estudados ao longo do módulo em uma única aplicação funcional.

A aplicação consiste em um **Sistema de Gerenciamento de Tarefas com Cadastro de Usuário**, composto por uma API REST desenvolvida em .NET e uma interface web desenvolvida em Angular.

O sistema permite cadastrar usuários e realizar o gerenciamento completo de tarefas, incluindo criação, visualização, edição, conclusão e exclusão.

## Tecnologias Utilizadas

### Back-end (API .NET)

- **.NET 10**
- **C#**
- **ASP.NET Core Web API**
- **Entity Framework Core** com Migrations
- **SQLite**
- **Data Annotations**
- **Swagger / OpenAPI**
- **PasswordHasher**

### Front-end (Angular)

- **Angular**
- **TypeScript**
- **HttpClient**
- **FormsModule**

### Outras Ferramentas

- **Git e GitHub**

## Funcionalidades da API

- **Cadastro de Usuário:**
  - Nome
  - E-mail
  - Senha
  - Validação dos dados
  - Armazenamento da senha utilizando hash
  - Consulta de usuário sem exposição da senha

- **Gerenciamento de Tarefas:**
  - Listagem de tarefas
  - Consulta de tarefa por ID
  - Cadastro de nova tarefa
  - Título
  - Descrição
  - Data de criação
  - Data de vencimento
  - Data de conclusão
  - Status
  - Atualização de tarefa existente
  - Exclusão de tarefa
  - Marcação de tarefa como concluída

## Funcionalidades do Front-end (Angular)

- Tela de cadastro de usuário
- Tela de listagem de tarefas
- Formulário para criar e editar tarefas
- Campo de data de vencimento
- Filtros de tarefas:
  - Todas
  - Em aberto
  - Concluídas
- Indicadores de tarefas abertas e concluídas
- Botões de ação rápida para editar, concluir ou excluir
- Tratamento de erros de requisição
- Mensagens visuais de sucesso e erro
- Integração com a API através do `HttpClient`

## 📂 Estrutura do Projeto

```text
.
├── backend/
│   ├── Controllers/       # Endpoints HTTP da API
│   ├── Data/              # Configuração do DbContext
│   ├── DTOs/              # Objetos de Transferência de Dados
│   ├── Migrations/        # Migrações do Entity Framework Core
│   ├── Models/            # Entidades do domínio
│   ├── Repositories/      # Camada de acesso a dados
│   ├── Services/          # Regras de negócio
│   ├── Program.cs         # Configuração e inicialização da API
│   ├── appsettings.json   # Configurações
│   └── dvteam-api.http    # Exemplos de requisições HTTP
│
└── frontend/
    ├── src/
    │   └── app/
    │       ├── api.service.ts
    │       ├── app.ts
    │       ├── app.html
    │       └── app.css
    ├── package.json
    └── angular.json
```

## Como Executar o Projeto

1. Clone o repositório em sua máquina local:

```bash
git clone https://github.com/brucarlota/dvteam-api.git
cd dvteam-api
```

2. **Executando o Back-end (.NET):**

Navegue até a pasta do back-end:

```bash
cd backend
```

Restaure as dependências:

```bash
dotnet restore
```

Execute as migrations do banco de dados:

```bash
dotnet ef database update
```

Inicie a aplicação:

```bash
dotnet run
```

A API ficará disponível em:

```text
http://localhost:5274
```

O Swagger pode ser acessado em:

```text
http://localhost:5274/swagger
```

3. **Executando o Front-end (Angular):**

Em outro terminal, a partir da raiz do projeto:

```bash
cd frontend
```

Instale as dependências:

```bash
npm install
```

Inicie o servidor de desenvolvimento:

```bash
npm start
```

Acesse a aplicação no navegador em:

```text
http://localhost:4200
```

## Integração Front-End e Back-End

O projeto está organizado em formato de **monorepo**, mantendo o back-end e o front-end no mesmo repositório.

O front-end consome a API através do `HttpClient`.

O back-end possui configuração de CORS permitindo chamadas do Angular em:

```text
http://localhost:4200
```

## Principais Endpoints

### Tarefas

| Método | Endpoint | Descrição |
|---|---|---|
| `GET` | `/api/Tarefa` | Lista todas as tarefas |
| `GET` | `/api/Tarefa/{id}` | Busca uma tarefa por ID |
| `POST` | `/api/Tarefa` | Cria uma nova tarefa |
| `PUT` | `/api/Tarefa/{id}` | Atualiza uma tarefa |
| `DELETE` | `/api/Tarefa/{id}` | Exclui uma tarefa |

### Usuários

| Método | Endpoint | Descrição |
|---|---|---|
| `GET` | `/api/Usuario/{id}` | Busca um usuário por ID |
| `POST` | `/api/Usuario` | Cadastra um novo usuário |

## Segurança

As senhas dos usuários não são armazenadas em texto puro.

Antes de serem persistidas no banco, as senhas são processadas utilizando `PasswordHasher<Usuario>`, e somente o hash é armazenado.

Além disso, a senha não é retornada nas respostas da API.

## Banco de Dados

O projeto utiliza **SQLite** com **Entity Framework Core**.

As alterações na estrutura do banco são controladas através de migrations.

Entre os dados persistidos estão:

- Usuários
- Tarefas
- Status
- Data de criação
- Data de vencimento
- Data de conclusão

## Testes Realizados

Durante o desenvolvimento foram validados os principais fluxos da aplicação:

- Cadastro de usuário
- Validação de senha
- Persistência do hash da senha
- Consulta de usuário sem exposição da senha
- Criação de tarefa
- Listagem de tarefas
- Edição de tarefa
- Alteração de status
- Marcação de tarefa como concluída
- Exclusão de tarefa
- Persistência da data de vencimento
- Integração entre front-end e back-end

---

<div align="center">

**Squad Dorothy Vaughan**

Projeto desenvolvido durante o bootcamp da **WoMakersCode** 💜.

</div>