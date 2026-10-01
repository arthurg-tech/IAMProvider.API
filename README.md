# 🛡️🫆🪪 Identity and Access Management (IAM) Provider API

Uma API RESTful de alta performance desenvolvida em ASP.NET Core, estruturada para atuar como um provedor centralizado de **Gestão de Identidade e Acessos (IAM)**. O projeto foi concebido como parte de um portfólio de engenharia de segurança e desenvolvimento backend, demonstrando a implementação prática de autenticação *stateless*, criptografia de credenciais e **Controle de Acesso Baseado em Funções (RBAC)**.

## Tecnologias e Arquitetura

- **Linguagem:** C# (.NET Core)
- **Framework:** ASP.NET Core Web API
- **Segurança & Autenticação:** ASP.NET Core Identity & Microsoft.AspNetCore.Authentication.JwtBearer
- **Persistência:** Entity Framework Core (ORM) com SQLite
- **Documentação de API:** Swashbuckle.AspNetCore (OpenAPI)

## Principais Funcionalidades de Segurança

- **Gestão de Identidades (Identity Core):** Cadastro seguro de usuários com hash robusto de senhas e aplicação de políticas de complexidade.
- **Autenticação Baseada em Tokens (JWT):** Emissão de JSON Web Tokens assinados digitalmente, garantindo a integridade e a confidencialidade das sessões.
- **Controle de Acesso Granular (RBAC):** Mecanismo dinâmico de criação de *roles* (ex: `Admin`, `User`) e associação de privilégios aos perfis de usuários.
- **Proteção de Endpoints:** Segregação rígida de recursos baseada em autorização por escopos e funções, retornando códigos de erro padronizados (`401 Unauthorized` e `403 Forbidden`).
- **Documentação OpenAPI Moderna:** Configuração avançada do Swagger integrada ao esquema de segurança HTTP Bearer para testes interativos de tokens.

## Como Executar o Projeto

### Pré-requisitos
Certifique-se de ter instalado na sua máquina:
- [.NET SDK](https://dotnet.microsoft.com/download)
- Ferramentas de linha de comando do Entity Framework (`dotnet tool install --global dotnet-ef`)

### Passo a Passo

1. Clone o repositório:
   
   ```bash
   git clone https://github.com/seu-usuario/IamProvider.API.git
   cd IamProvider.API

3. Restaure as dependênicas do projeto
   
   ```bash
   dotnet restore

5. Inicie a execução da aplicação
   
   ```bash
   dotnet run

7. Acesse a interface interativa do Swagger no navegador através do endereço gerado no terminal (geralmente `https://localhost:<porta>/swagger`).
