# ProductCatalog.API 🚀

> Status do Projeto: :construction: Em Desenvolvimento

Esta é uma API RESTful construída com **.NET 9** voltada para o gerenciamento de catálogos de produtos. O projeto foca em boas práticas de mercado, utilizando Entity Framework Core para persistência de dados e documentação moderna com Scalar.

## 🛠️ Tecnologias Utilizadas

* **.NET 9** (C#)
* **Entity Framework Core** (ORM)
* **SQL Server** (Database)
* **OpenAPI / Scalar** (Documentação e Testes)
* **Git/GitHub** (Versionamento)

## 📌 Funcionalidades em Implementação

- [x] Configuração inicial do projeto e arquitetura.
- [x] Modelagem da entidade Produto.
- [x] Configuração do Contexto de Banco de Dados (DbContext).
- [x] Criação do Banco via Migrations.
- [x] Implementação do `ProdutosController` (Base e Injeção de Dependência).
- [x] Implementação de Métodos de Leitura (GET All e GET by ID).
- [x] Configuração de Documentação Interativa com **Scalar**.
- [ ] Implementação do Método de Criação (POST).
- [ ] Implementação de Update (PUT) e Delete (DELETE).

## ⚙️ Como rodar o projeto

1. Clone o repositório:
   `git clone https://github.com/PedroInCode/ProductCatalog.API.git`

2. Atualize a Connection String no `appsettings.json` para o seu servidor local.

3. Execute o comando no Console do Gerenciador de Pacotes:
   `Update-Database`

4. Rode a aplicação com `F5`.

5. **Acesse a documentação:** Para testar os endpoints, navegue até `/scalar/v1` após iniciar a aplicação.

---
Desenvolvido por [Pedro Gustavo](https://github.com/PedroInCode)