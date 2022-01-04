<div align="center" style="margin-top: 50px">
  <p style="margin-top: 20px;">Library API</p>
</div>

# Descrição
  Api simples criada em NET 6 para criação, atualizações, consutas e deleções de livros (POST, PUT, GET and DELETE).

Libs:

- **Microsoft.AspNetCore.Mvc.Versioning Version 5.0.0**
- **Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer Version 5.0.0"**
- **Microsoft.EntityFrameworkCore.Design Version 6.0.1**
- **Microsoft.EntityFrameworkCore.Relational Version 6.0.1**
- **Microsoft.EntityFrameworkCore.SqlServer Version 6.0.1**
- **Microsoft.EntityFrameworkCore.Tools Version 6.0.1**
- **Swashbuckle.AspNetCore Version 6.2.3**

Banco de dados:
  SQl Server

Docker:
  Dockerfile e docker compose para auxílio na execução local da API.

Scripts:
  Pasta de scripts com arquivo base para criação do banco de dados e da tabela de livros.

Pasta DataAccessLayer:
  Pasta utilizada como uma "camada" de acesso a dados, com a configuração do contexto de banco, modelos e mapeamentos.

Pasta DataAccessLayer:
  Pasta utilizada como uma "camada" serviços, com repositórios, view models, classes bases, classes de extensão e filtros.
