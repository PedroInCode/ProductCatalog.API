# ProductCatalog.API 🚀

> Status do Projeto: :construction: Em Desenvolvimento

Esta é uma API RESTful construída com **.NET 9** voltada para o gerenciamento de catálogos de produtos. O projeto foca em boas práticas de mercado, utilizando Entity Framework Core para persistência de dados.

## 🛠️ Tecnologias Utilizadas

* **.NET 9** (C#)
* **Entity Framework Core** (ORM)
* **SQL Server** (Database)
* **Git/GitHub** (Versionamento)

## 📌 Funcionalidades em Implementação

- [x] Configuração inicial do projeto e arquitetura.
- [x] Modelagem da entidade Produto.
- [x] Configuração do Contexto de Banco de Dados (DbContext).
- [x] Criação do Banco via Migrations.
- [ ] Implementação do ProductsController (CRUD).
- [ ] Testes de integração via Postman/Swagger.

## ⚙️ Como rodar o projeto

1. Clone o repositório:
   `git clone https://github.com/PedroInCode/ProductCatalog.API.git`

2. Atualize a Connection String no `appsettings.json` para o seu servidor local.

3. Execute o comando no Console do Gerenciador de Pacotes:
   `Update-Database`

4. Rode a aplicação com `F5`.

---
Desenvolvido por [Pedro Gustavo](https://github.com/PedroInCode)