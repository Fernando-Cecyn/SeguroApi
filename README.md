\# 🚀 Seguro API RESTful



\### Clean Architecture com .NET 6



API REST desenvolvida em \*\*.NET 6\*\* para cálculo e gestão de apólices de seguro, utilizando princípios de \*\*Clean Architecture\*\*, boas práticas de engenharia de software e foco em organização, testabilidade e escalabilidade.



\---



\## 📌 Visão Geral



Este projeto foi desenvolvido com o objetivo de demonstrar:



\* 🧠 Organização arquitetural sólida

\* ⚙️ Separação clara de responsabilidades

\* 🧪 Facilidade de testes

\* 🔄 Manutenibilidade e escalabilidade



A aplicação permite:



\* Criar apólices de seguro

\* Consultar apólices por ID

\* Gerar relatórios (média dos valores de seguro)



\---



\## 🏗️ Arquitetura



O projeto segue o padrão \*\*Clean Architecture\*\*, dividido em camadas bem definidas:



```

Domain         → Entidades e regras de negócio

Application    → Casos de uso e orquestração

Infrastructure → Persistência e integrações

API            → Exposição HTTP (Controllers)

Tests          → Testes unitários

```



\### 🔹 Princípios aplicados



\* Inversão de dependência

\* Baixo acoplamento

\* Alta coesão

\* Separação de responsabilidades



\---



\## 🧩 Domínio



Entidades principais:



\* \*\*Apolice\*\* (entidade central)

\* \*\*Segurado\*\* (Value Object)

\* \*\*Veiculo\*\* (Value Object)



📌 \*Segurado e Veiculo foram modelados como \*\*Owned Entities\*\* no Entity Framework, pois não possuem identidade própria fora do contexto da apólice.\*



\---



\## 🧮 Regra de Negócio



O cálculo do seguro é isolado na camada de domínio:



```

Premio = ((valor \* 5) / (2 \* valor)) \* valor \* 1.03 \* 1.05

```



📍 Implementação:



```

Domain/Services/SeguroCalculator.cs

```



\---



\## 🌐 Endpoints



\### ➕ Criar Apólice



```

POST /api/seguros

```



\### 🔍 Buscar por ID



```

GET /api/seguros/{id}

```



\### 📊 Relatório (Média dos Seguros)



```

GET /api/seguros/relatorio

```



\---



\## 🗄️ Persistência



\* Entity Framework Core

\* Banco de dados \*\*InMemory\*\* (para simplicidade e testes)



\---



\## 🧪 Testes



Testes unitários implementados para:



\* ✔️ Cálculo de seguro (camada de domínio)



Framework utilizado:



\* xUnit



\---



\## ▶️ Como Executar



\### 📦 Pré-requisitos



\* .NET 6 SDK

\* Visual Studio 2022 ou VS Code



\---



\### ▶️ Rodando a aplicação



```bash

dotnet restore

dotnet build

dotnet run

```



\---



\### 📄 Swagger



Acesse:



```

https://localhost:{porta}/swagger

```



\---



\## 🚀 Possíveis Melhorias



\* ✔️ Validação de CPF

\* ✔️ Persistência em SQL Server

\* ✔️ Autenticação e autorização

\* ✔️ Logging estruturado

\* ✔️ Testes de integração

\* ✔️ Dockerização

\* ✔️ Deploy em Cloud (Azure / AWS)



\---



\## 🎯 Objetivo do Projeto



Este projeto foi desenvolvido para demonstrar:



\* Arquitetura limpa e organizada

\* Boas práticas em APIs REST com .NET

\* Modelagem de domínio

\* Separação de responsabilidades

\* Qualidade e clareza de código



\---



\## 👨‍💻 Autor



\*\*Fernando H. N. Cecyn\*\*

Software Engineer | Backend | Arquitetura | Automação



\---



\## 💬 Considerações Finais



Mais do que apenas entregar funcionalidade, este projeto busca demonstrar uma abordagem profissional na construção de software, priorizando qualidade, organização e escalabilidade — características essenciais para ambientes corporativos e sistemas críticos.



