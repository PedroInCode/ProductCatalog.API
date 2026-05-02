# ProductCatalog.API 🚀

> Status do Projeto: :heavy_check_mark: CRUD Base Completo

Esta é uma API RESTful construída com **.NET 9** para gerenciamento de catálogos de produtos, utilizando as melhores práticas de desenvolvimento e persistência em banco de dados real.

## 🛠️ Tecnologias e Ferramentas

* **.NET 9** (C#)
* **Entity Framework Core** (ORM)
* **SQL Server Express** (Banco de Dados Local)
* **SQL Server Management Studio - SSMS** (Gerenciamento)
* **OpenAPI / Scalar** (Documentação Interativa)

## 📌 Funcionalidades Implementadas

- [x] **GET /api/Produtos**: Lista todos os produtos cadastrados.
- [x] **GET /api/Produtos/{id}**: Busca um produto específico pelo ID.
- [x] **POST /api/Produtos**: Cria um novo produto (Com proteção de Identity: o sistema ignora IDs enviados manualmente e gera automaticamente no banco).
- [x] **PUT /api/Produtos/{id}**: Atualiza os dados de um produto existente.
- [x] **DELETE /api/Produtos/{id}**: Remove um produto do catálogo.

## ⚙️ Como Rodar o Projeto

1. **Clone o repositório:**
   ```bash
   git clone [https://github.com/PedroInCode/ProductCatalog.API.git](https://github.com/PedroInCode/ProductCatalog.API.git)