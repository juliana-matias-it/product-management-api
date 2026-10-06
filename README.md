# API de Gerenciamento de Produtos

API REST desenvolvida com **ASP.NET Core** para gerenciamento de produtos.

O projeto implementa operações completas de CRUD e utiliza **Entity Framework Core** para persistência de dados em um banco **SQLite**.

A API também é consumida por uma aplicação front-end desenvolvida em Angular.

## Funcionalidades

- Listagem de todos os produtos
- Busca de produto por ID
- Cadastro de novos produtos
- Atualização de produtos existentes
- Remoção de produtos
- Persistência de dados com SQLite
- Migrations com Entity Framework Core
- Documentação e testes de endpoints com Swagger
- Configuração de CORS para comunicação com o front-end Angular

## Tecnologias utilizadas

- C#
- .NET / ASP.NET Core
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

## Front-end

Esta API é consumida por uma aplicação Angular que implementa a interface do Gerenciador de Produtos.

Repositório:

[product-management-frontend](https://github.com/juliana-matias-it/product-management-frontend)

## Arquitetura da aplicação

O fluxo principal da aplicação é:

```text
Angular
   │
   │ HTTP
   ▼
ASP.NET Core API
   │
   ▼
Entity Framework Core
   │
   ▼
SQLite
```

No back-end, as requisições são recebidas pelo controller de produtos, que utiliza o contexto do Entity Framework Core para acessar e alterar os dados.

```text
ProdutosController
        │
        ▼
AppDbContext
        │
        ▼
Entity Framework Core
        │
        ▼
SQLite
```

## Estrutura do projeto

```text
MinhaPrimeiraApi/
│
├── Controllers/
│   └── ProdutosController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│
├── Models/
│   └── Produto.cs
│
├── Properties/
│
├── Program.cs
├── appsettings.json
└── MinhaPrimeiraApi.csproj
```

## Modelo de Produto

Cada produto possui as seguintes informações:

```json
{
  "id": 1,
  "nome": "Canetinha",
  "preco": 12.30
}
```

## Endpoints

A API disponibiliza as cinco operações principais de CRUD.

| Operação | Método | Endpoint |
|---|---|---|
| Listar todos os produtos | GET | `/api/Produtos` |
| Buscar produto por ID | GET | `/api/Produtos/{id}` |
| Criar produto | POST | `/api/Produtos` |
| Atualizar produto | PUT | `/api/Produtos/{id}` |
| Remover produto | DELETE | `/api/Produtos/{id}` |

### Listar produtos

```http
GET /api/Produtos
```

Exemplo de resposta:

```json
[
  {
    "id": 1,
    "nome": "Canetinha",
    "preco": 12.3
  },
  {
    "id": 2,
    "nome": "Mochila Feminina",
    "preco": 100.9
  }
]
```

### Buscar produto por ID

```http
GET /api/Produtos/1
```

Exemplo de resposta:

```json
{
  "id": 1,
  "nome": "Canetinha",
  "preco": 12.3
}
```

### Criar produto

```http
POST /api/Produtos
```

Exemplo de body:

```json
{
  "nome": "Caderno",
  "preco": 25.90
}
```

### Atualizar produto

```http
PUT /api/Produtos/1
```

Exemplo de body:

```json
{
  "nome": "Canetinha Colorida",
  "preco": 15.90
}
```

### Remover produto

```http
DELETE /api/Produtos/1
```

## Executando o projeto

### Pré-requisitos

Antes de executar o projeto, é necessário ter instalado:

- .NET SDK
- Git

Opcionalmente, para visualizar o banco de dados:

- DBeaver ou outro cliente compatível com SQLite

### 1. Clone o repositório

```bash
git clone https://github.com/juliana-matias-it/product-management-api.git
```

### 2. Entre na pasta do projeto

```bash
cd product-management-api
```

### 3. Restaure as dependências

```bash
dotnet restore
```

### 4. Crie o banco de dados

O arquivo SQLite não é versionado no repositório.

As migrations do Entity Framework Core estão incluídas no projeto. Para criar o banco e aplicar as migrations:

```bash
dotnet ef database update
```

Caso o comando `dotnet ef` não esteja disponível, instale a ferramenta:

```bash
dotnet tool install --global dotnet-ef
```

### 5. Execute a API

```bash
dotnet run
```

O terminal exibirá o endereço em que a aplicação está sendo executada.

Por exemplo:

```text
http://localhost:5220
```

A porta pode variar de acordo com o ambiente.

## Swagger

Com a API em execução, a documentação interativa pode ser acessada pelo Swagger.

Exemplo:

```text
http://localhost:5220/swagger/index.html
```

A porta deve ser ajustada conforme o endereço informado pelo `dotnet run`.

O Swagger permite testar os endpoints diretamente pelo navegador.

## Banco de dados

O projeto utiliza **SQLite**.

O banco é criado no arquivo:

```text
minhaapi.db
```

A configuração do Entity Framework Core é feita através do `AppDbContext`.

Os dados também podem ser consultados utilizando o DBeaver.

Exemplo:

```sql
SELECT * FROM Produtos;
```

## Integração com Angular

A API possui uma política de CORS configurada para permitir requisições da aplicação Angular executada em:

```text
http://localhost:4200
```

Dessa forma, o fluxo completo da aplicação fica:

```text
Usuário
   │
   ▼
Angular
   │
   │ GET / POST / PUT / DELETE
   ▼
ASP.NET Core API
   │
   ▼
Entity Framework Core
   │
   ▼
SQLite
```

## Projeto completo

O projeto é dividido em dois repositórios:

### Back-end

**ASP.NET Core + Entity Framework Core + SQLite**

[product-management-api](https://github.com/juliana-matias-it/product-management-api)

### Front-end

**Angular + TypeScript**

[product-management-frontend](https://github.com/juliana-matias-it/product-management-frontend)

## Sobre o projeto

Este projeto foi desenvolvido durante um exercício prático de desenvolvimento e integração de aplicações com **.NET e Angular**.

O back-end foi construído como uma API REST responsável pelas operações de CRUD e persistência dos produtos.

Posteriormente, a API foi integrada a uma aplicação Angular responsável pela interface com o usuário, permitindo executar todas as operações do CRUD de ponta a ponta.

O projeto foi mantido e aprimorado para compor meu portfólio de desenvolvimento de software.

## Autora

**Juliana Matias**

GitHub: [juliana-matias-it](https://github.com/juliana-matias-it)