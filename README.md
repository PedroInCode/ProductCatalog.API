# ProductCatalog.API 🚀

> Status do Projeto: :heavy_check_mark: CRUD Completo, Relacionamentos & Lógica de Estoque

Esta é uma API RESTful robusta desenvolvida com **.NET 9** para o gerenciamento de catálogos de produtos e controle de pedidos. O projeto evoluiu de uma estrutura simples para uma arquitetura com persistência no **SQL Server Express**, implementando regras de negócio reais como validação de estoque e integridade referencial.

---

## 🛠️ Tecnologias e Ferramentas

* **.NET 9** (C#)
* **Entity Framework Core** (ORM)
* **SQL Server Express** (Banco de Dados Local)
* **SQL Server Management Studio - SSMS** (Gestão do Banco)
* **OpenAPI / Scalar** (Documentação Interativa e Testes)

---

## 📌 Funcionalidades e Endpoints

### 📦 Módulo de Produtos
Gerenciamento completo do catálogo:
* **`GET /api/Produtos`**: Lista todos os produtos cadastrados.
* **`GET /api/Produtos/{id}`**: Detalhes de um produto específico.
* **`POST /api/Produtos`**: Criação de produtos com proteção contra conflitos de ID (`Identity`).
* **`PUT /api/Produtos/{id}`**: Atualização integral de dados do produto.
* **`DELETE /api/Produtos/{id}`**: Remoção permanente do produto.

### 🛒 Módulo de Pedidos (Vendas & Estoque)
Lógica de negócio avançada com interação entre tabelas:
* **`POST /api/Pedidos`**: Realiza uma venda.
    * *Diferencial:* Valida automaticamente se há **estoque disponível**. Se confirmado, subtrai a quantidade do produto no banco de dados.
* **`GET /api/Pedidos`**: Lista todos os pedidos utilizando **Eager Loading (`.Include`)**, trazendo os detalhes do Produto (Nome, Preço) de forma otimizada.
* **`GET /api/Pedidos/{id}`**: Pesquisa detalhada de um pedido específico.
* **`DELETE /api/Pedidos/{id}`**: Cancela um pedido e **restaura automaticamente o estoque** do produto, garantindo a integridade dos dados.

---

## ⚙️ Como Rodar o Projeto

### 1. Pré-requisitos
* **SDK do .NET 9** instalado.
* **SQL Server Express** rodando localmente.

### 2. Configuração do Banco
Certifique-se de atualizar a `ConnectionString` no arquivo `appsettings.json` com as suas credenciais locais do SQL Server.

### 3. Clonar e Executar
```bash
# Clonar o repositório
git clone [https://github.com/PedroInCode/ProductCatalog.API.git](https://github.com/PedroInCode/ProductCatalog.API.git)

# Entrar na pasta
cd MinhaApiProdutos

# Executar o projeto
dotnet run