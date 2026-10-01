# Identity and Access Management (IAM) Provider API

Uma API RESTful de alta performance desenvolvida em ASP.NET Core, estruturada para atuar como um provedor centralizado de **Gestão de Identidade e Acessos (IAM)**. O projeto foi concebido como parte de um portfólio de engenharia de segurança e desenvolvimento backend, demonstrando a implementação prática de autenticação *stateless*, criptografia de credenciais e **Controle de Acesso Baseado em Funções (RBAC)**.

---

## 🛡️ Principais Funcionalidades de Segurança

- **Gestão de Identidades (Identity Core):** Cadastro seguro de usuários com hash robusto de senhas e aplicação de políticas de complexidade.
- **Autenticação Baseada em Tokens (JWT):** Emissão de JSON Web Tokens assinados digitalmente, garantindo a integridade e a confidencialidade das sessões.
- **Controle de Acesso Granular (RBAC):** Mecanismo dinâmico de criação de *roles* (ex: `Admin`, `User`) e associação de privilégios aos perfis de usuários.
- **Proteção de Endpoints:** Segregação rígida de recursos baseada em autorização por escopos e funções, retornando códigos de erro padronizados (`401 Unauthorized` e `403 Forbidden`).
- **Documentação OpenAPI Moderna:** Configuração avançada do Swagger integrada ao esquema de segurança HTTP Bearer para testes interativos de tokens.

---

## 💻 Tecnologias e Arquitetura

- **Linguagem:** C# (.NET Core)
- **Framework:** ASP.NET Core Web API
- **Segurança & Autenticação:** ASP.NET Core Identity & Microsoft.AspNetCore.Authentication.JwtBearer
- **Persistência:** Entity Framework Core (ORM) com SQLite
- **Documentação de API:** Swashbuckle.AspNetCore (OpenAPI)

---

## Como Executar o Projeto

### Pré-requisitos
Certifique-se de ter instalado na sua máquina:
- [.NET SDK](https://dotnet.microsoft.com/download)
- Ferramentas de linha de comando do Entity Framework (`dotnet tool install --global dotnet-ef`)

### Passo a Passo

1. Clone o repositório:
   ```bash
   git clone [https://github.com/seu-usuario/IamProvider.API.git](https://github.com/seu-usuario/IamProvider.API.git)
   cd IamProvider.API

## Mapeamento de Endpoints

| Método | Rota | Descrição | Requer Autenticação? | Restrição de Role |
|---|---|---|:---:|:---:|
| `POST` | `/api/Auth/register` | Cria uma nova conta de usuário no provedor. | Não | Livre |
| `POST` | `/api/Auth/login` | Valida credenciais e emite o Token JWT de acesso. | Não | Livre |
| `POST` | `/api/Auth/create-role` | Cria uma nova regra/permissão no sistema. | Não | Livre |
| `POST` | `/api/Auth/assign-role` | Associa uma *role* a um usuário cadastrado. | Não | Livre |
| `GET` | `/api/ProtectedResource/dados-publicos` | Endpoint aberto para testes de conectividade. | Não | Livre |
| `GET` | `/api/ProtectedResource/dados-usuario` | Retorna dados restritos a usuários autenticados. | **Sim** | `User` ou `Admin` |
| `GET` | `/api/ProtectedResource/dados-admin` | Retorna dados confidenciais de administração. | **Sim** | Somente `Admin` |


## 🛣️ Roadmap e Próximos Passos (Evolução do Projeto)

* **Implementação de Refresh Tokens:** Adição de mecanismo de renovação de tokens de acesso de curta duração, aumentando a segurança da sessão sem fricção para o usuário.
* **Autenticação Multifator (MFA / TOTP):** Integração de códigos de verificação em duas etapas via aplicativos autenticadores (Google Authenticator / Authy).
* **Mecanismo de Account Lockout:** Bloqueio temporário de contas após múltiplas tentativas consecutivas de falha de login, mitigando ataques de força bruta.
* **Trilha de Auditoria (Audit Logging):** Sistema estruturado de logs para rastreabilidade de eventos críticos de segurança (tentativas de intrusão, alterações de privilégios e logins bem-sucedidos).
* **Migração de Banco de Dados de Produção:** Transição arquitetural do SQLite para o PostgreSQL, preparando a aplicação para ambientes concorrentes de alta escalabilidade.
