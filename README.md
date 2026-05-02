# ProductCatalog.API 🚀

> Status do Projeto: :construction: Em Desenvolvimento

Esta é uma API RESTful construída com **.NET 9** voltada para o gerenciamento de catálogos de produtos. O projeto utiliza Entity Framework Core para persistência de dados e SQL Server Express.

## 🛠️ Tecnologias Utilizadas

* **.NET 9** (C#)
* **Entity Framework Core** (ORM)
* **SQL Server Express** (Banco de Dados Local)
* **SQL Server Management Studio - SSMS** (Gerenciamento do Banco)
* **OpenAPI / Scalar** (Documentação e Testes)
* **Git/GitHub** (Versionamento)

## 📌 Funcionalidades em Implementação

- [x] Configuração inicial do projeto e arquitetura.
- [x] Modelagem da entidade Produto.
- [x] Configuração do Contexto de Banco de Dados (DbContext).
- [x] Criação do Banco via Migrations no SQL Express.
- [x] Implementação do `ProdutosController` (Leitura - GET).
- [x] Configuração de Documentação com Scalar.
- [ ] Implementação do Método de Criação (POST).
- [ ] Implementação de Update (PUT) e Delete (DELETE).

## ⚙️ Como rodar o projeto

1. Clone o repositório:
   `git clone https://github.com/PedroInCode/ProductCatalog.API.git`

2. **Configuração do Banco:** Certifique-se de ter o **SQL Server Express** instalado. No arquivo `appsettings.json`, a Connection String está configurada para:
   `"Server=.\\SQLEXPRESS;Database=DbProdutosPedro;..."`

3. Execute o comando no Console do Gerenciador de Pacotes para criar as tabelas:
   `Update-Database`

4. Rode a aplicação com `F5`.

5. **Documentação:** Acesse `/scalar/v1` para testar os endpoints.

---
Desenvolvido por [Pedro Gustavo](https://github.com/PedroInCode)