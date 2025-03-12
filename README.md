# Programacao Financeira Despesa API

API desenvolvida para gerenciar a programação financeira de despesas, permitindo CRUD de configurações financeiras e cálculo da progressão mensal.
Inclui autenticação JWT com controle de acesso baseado em roles.

## 📖 Índice
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Pré-requisitos](#pré-requisitos)
- [Configuração do Ambiente](#configuração-do-ambiente)
- [Autenticação e Segurança](#autenticação-e-segurança)
- [Endpoints da API](#endpoints-da-api)
- [Execução](#execução)
- [Swagger e Documentação](#swagger-e-documentação)

---

## 🚀 Tecnologias Utilizadas
- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **JWT (Json Web Token)**
- **MediatR**
- **Swagger UI**
- **Docker (Opcional)**

---

## 🔧 Pré-requisitos
Certifique-se de ter os seguintes itens instalados:
- [.NET SDK 8 ou superior](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Postman](https://www.postman.com/downloads/) (Opcional, mas recomendado)
- [Docker](https://www.docker.com/products/docker-desktop) (Opcional para rodar via container)

---

## ⚙️ Configuração do Ambiente

1. **Clone o repositório**
   ```sh
   git clone https://github.com/EduardoMatheus96/Desafio.Net.git
   ```

2. **Configurar o Banco de Dados**
   - Atualize a string de conexão em `appsettings.json`:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=localhost,1433;Database=TESTE;User Id=sa;Password=12345678@Bc;TrustServerCertificate=True"
     }
     ```


---

## 🔐 Autenticação e Segurança

A API usa **JWT (JSON Web Token)** para autenticação.
Para acessar endpoints protegidos, siga os passos:

1. **Gerar Token de Autenticação**
   - Use o endpoint:
     ```
     POST /api/auth/login
     ```
   - Exemplo de Body JSON:
     ```json
     {
       "username": "admin",
       "password": "123456"
     }
     ```
   - Retorno esperado:
     ```json
     {
       "token": "eyJhbGciOiJIUzI1..."
     }
     ```

2. **Usar Token para autenticação**
   - No **Swagger**, clique em "Authorize" e insira apenas o token gerado.
   - No **Postman**, insira o token no **Header** como:
     ```
     Authorization: Bearer <SEU_TOKEN>
     ```

---

## 📌 Endpoints da API

### **🔑 Autenticação**
| Método | Endpoint        | Descrição |
|--------|---------------|-----------|
| POST   | `/api/auth/login` | Gera um token JWT para acesso à API |

### **📊 Programação Financeira**
| Método | Endpoint        | Descrição |
|--------|---------------|-----------|
| GET    | `/api/ProgramacaoFinanceiraDespesaConfig/progressao?ano=2025&unidadeGestoraId=3` | Retorna a progressão mensal calculada |
| POST   | `/api/ProgramacaoFinanceiraDespesaConfig` | Cria uma nova programação financeira |
| PUT    | `/api/ProgramacaoFinanceiraDespesaConfig` | Atualiza uma programação existente |
| DELETE | `/api/ProgramacaoFinanceiraDespesaConfig/{id}` | Remove uma programação |

---

## ▶️ Execução

Para rodar a API localmente:
```sh
 dotnet run
```
A API estará disponível em:
```
https://localhost:7011
```

Para rodar via Docker:
```sh
docker build -t programacao-financeira-api .
docker run -p 7011:7011 programacao-financeira-api
```

---

## 📑 Swagger e Documentação

A documentação da API está disponível no **Swagger**:
```
https://localhost:7011/swagger
```
Aqui você pode testar todos os endpoints interativamente.

---

## 📌 Contato e Suporte
Caso tenha dúvidas ou precise de suporte, entre em contato via:
- 📧 Email: eduardomatheusmsouto@gmail.com
- 🔗 LinkedIn: [Eduardo Matheus de Menezes Souto](https://www.linkedin.com/in/eduardomatheus-dev/)
```

