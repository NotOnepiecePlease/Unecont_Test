# Notas Fiscais — Teste Técnico

Sistema de cadastro e listagem de notas fiscais com backend em ASP.NET Core Web API e frontend em Blazor WebAssembly.

---

## Tecnologias

| Camada     | Tecnologia                        |
|------------|-----------------------------------|
| Backend    | ASP.NET Core Web API (.NET 10)    |
| Frontend   | Blazor WebAssembly (.NET 10)      |
| Testes     | xUnit                             |
| Persistência | In-memory (sem banco de dados)  |

---

## Pré-requisitos

- [**.NET 10 SDK**](https://dotnet.microsoft.com/download/dotnet/10.0) instalado
- Qualquer terminal (PowerShell, CMD, bash)

Verifique a instalação:

```bash
dotnet --version
# Esperado: 10.x.x
```

---

## Como executar

O projeto possui dois serviços que precisam rodar simultaneamente. **Abra dois terminais.**

### 1. Clone o repositório

```bash
git clone https://github.com/NotOnepiecePlease/Unecont_Test.git
cd Unecont_Test
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Terminal 1 — API

```bash
cd NotasFiscais.Api
dotnet run --launch-profile http
```

A API ficará disponível em: `http://localhost:5242`

### 4. Terminal 2 — Frontend

```bash
cd NotasFiscais.Web
dotnet run --launch-profile http
```

O navegador abrirá automaticamente em: `http://localhost:5042`

> **Importante:** a API deve estar rodando antes de acessar o frontend.

---

## Executar os testes

```bash
cd NotasFiscais.Tests
dotnet test
```

---

## Estrutura do projeto

```
Unecont_Test/
├── NotasFiscais.Api/           # Backend REST API
│   ├── Controllers/            # Endpoints HTTP
│   ├── Services/               # Regras de negócio
│   ├── Models/                 # Entidades do domínio
│   └── DTOs/                   # Objetos de entrada e saída
│
├── NotasFiscais.Web/           # Frontend Blazor WebAssembly
│   ├── Pages/                  # Páginas da aplicação
│   ├── Services/               # Comunicação com a API
│   └── Models/                 # ViewModels e formulários
│
└── NotasFiscais.Tests/         # Testes unitários (xUnit)
```

---

## Endpoints da API

| Método | Rota          | Descrição                    |
|--------|---------------|------------------------------|
| GET    | `/api/notas`  | Lista todas as notas fiscais |
| POST   | `/api/notas`  | Cadastra uma nova nota fiscal |

### Exemplo — Cadastrar nota (POST `/api/notas`)

**Request body:**
```json
{
  "numero": "NF-001",
  "cliente": "Empresa Exemplo LTDA",
  "valor": 1500.00,
  "dataEmissao": "2025-10-20"
}
```

**Response `201 Created`:**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "numero": "NF-001",
  "cliente": "Empresa Exemplo LTDA",
  "valor": 1500.00,
  "valorFormatado": "R$ 1.500,00",
  "dataEmissao": "20/10/2025",
  "dataHoraCadastro": "20/10/2025 14:30:00"
}
```

---

## Funcionalidades

- Cadastro de notas fiscais com validação de campos
- Listagem de todas as notas cadastradas
- Filtro por cliente em tempo real
- Ordenação por valor (crescente/decrescente)
- Valores formatados em moeda brasileira (R$)
- Armazenamento em memória (os dados são perdidos ao reiniciar a aplicação)

---

## Portas utilizadas

| Serviço  | HTTP                   |
|----------|------------------------|
| API      | http://localhost:5242  |
| Frontend | http://localhost:5042  |

Caso alguma porta esteja ocupada, altere o valor em `Properties/launchSettings.json` do projeto correspondente.
