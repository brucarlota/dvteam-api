# Rotina — front-end

Aplicação Angular 20 para cadastro de usuárias e gerenciamento de tarefas da DVTeam API. As chamadas HTTP são feitas com o `HttpClient` do Angular.

## Executar localmente

1. Inicie a API na raiz do repositório. O front-end espera a API em `http://localhost:5274`, origem configurada na política CORS `PermitirAngular`.
2. Em outro terminal, dentro de `frontend`, instale as dependências e inicie a aplicação:

   ```bash
   npm install
   npm start
   ```

3. Acesse `http://localhost:4200`.

## Funcionalidades

- Cadastro de usuária pela rota `POST /api/Usuario`.
- Listagem de tarefas pela rota `GET /api/Tarefa`, com filtros por status.
- Criação e edição pelas rotas `POST /api/Tarefa` e `PUT /api/Tarefa/{id}`.
- Conclusão de tarefas pela rota `PUT /api/Tarefa/{id}`.
- Exclusão pela rota `DELETE /api/Tarefa/{id}`, com confirmação antes da ação.
- Mensagens de sucesso e mensagens de erro retornadas pela API.

## Build

```bash
npm run build
```
