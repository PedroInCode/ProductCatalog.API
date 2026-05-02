# ProductCatalog.API 🚀

> Status do Projeto: :heavy_check_mark: CRUD Completo & Persistência em Banco Real

Esta é uma API RESTful robusta desenvolvida com **.NET 9** para o gerenciamento de catálogos de produtos. O projeto foi evoluído de uma estrutura em memória para uma arquitetura com persistência no **SQL Server Express**, focando em boas práticas de desenvolvimento backend.

---

## 🛠️ Tecnologias e Ferramentas

* **.NET 9** (C#)
* **Entity Framework Core** (ORM)
* **SQL Server Express** (Banco de Dados Local)
* **SQL Server Management Studio - SSMS** (Gestão do Banco)
* **OpenAPI / Scalar** (Documentação Interativa e Testes)

---

## 📌 Funcionalidades e Endpoints

A API permite gerenciar o ciclo de vida completo de um produto através dos seguintes endpoints:

* **`GET /api/Produtos`**: Retorna a lista completa de produtos cadastrados no banco.
* **`GET /api/Produtos/{id}`**: Retorna os detalhes de um produto específico baseado no seu ID.
* **`POST /api/Produtos`**: Cria um novo produto. 
    * *Diferencial:* Possui lógica de proteção onde o sistema ignora qualquer ID enviado no corpo da requisição (`Id = 0`), garantindo que o SQL Server gerencie a identidade (`IDENTITY`) de forma automática e segura.
* **`PUT /api/Produtos/{id}`**: Atualiza todos os dados de um produto existente. Exige que o ID da URL coincida com o ID do objeto enviado no corpo.
* **`DELETE /api/Produtos/{id}`**: Remove permanentemente um produto do banco de dados.

---

## ⚙️ Como Rodar o Projeto em sua Máquina

### 1. Pré-requisitos
* **SDK do .NET 9** instalado.
* **SQL Server Express** instalado e rodando.
* **Visual Studio 2022** (recomendado).

### 2. Clonar o Repositório
```bash
git clone [https://github.com/PedroInCode/ProductCatalog.API.git](https://github.com/PedroInCode/ProductCatalog.API.git)