# Seguro API RESTful

API desenvolvida em .NET 6 para cálculo e gestão de apólices de seguro.


---

## 📌 Sobre o projeto

A API permite:

* Criar uma apólice de seguro
* Consultar uma apólice por ID
* Obter um relatório simples com a média dos valores de seguro

O cálculo do seguro é feito com base no valor do veículo e está isolado na camada de domínio.

---

## 🏗️ Arquitetura

A solução foi estruturada seguindo Clean Architecture, dividida em:

* **Domain** → regras de negócio e entidades
* **Application** → casos de uso
* **Infrastructure** → acesso a dados (EF Core)
* **API** → controllers e exposição HTTP
* **Tests** → testes unitários

A ideia foi manter:

* regras de negócio desacopladas de framework
* dependências apontando sempre para dentro
* código fácil de testar

---

## 🧩 Modelagem

A entidade principal é:

* **Apolice**

E ela é composta por:

* **Segurado**
* **Veiculo**

Esses dois foram modelados como *Value Objects* (Owned Entities no EF), porque não fazem sentido isoladamente — só existem dentro de uma apólice.

---

## 🧮 Regra de cálculo

A lógica de cálculo foi mantida isolada na camada de domínio:

```id="1r1n6c"
Premio = ((valor * 5) / (2 * valor)) * valor * 1.03 * 1.05
```

Implementação em:

```id="7k3b0s"
Domain/Services/SeguroCalculator.cs
```

---

## 🌐 Endpoints

Criar apólice:

```id="g5d1az"
POST /api/seguros
```

Buscar por ID:

```id="2sd7fr"
GET /api/seguros/{id}
```

Relatório (média):

```id="3g8ktt"
GET /api/seguros/relatorio
```

---

## 🗄️ Persistência

Foi utilizado:

* Entity Framework Core
* Banco em memória (InMemory)

A escolha foi intencional para manter o foco no domínio e na arquitetura, sem depender de infraestrutura externa.

---

## 🧪 Testes

Foram implementados testes unitários para a regra de cálculo do seguro, garantindo previsibilidade da lógica central.

---

## ▶️ Como rodar

```bash id="yxt9hb"
dotnet restore
dotnet build
dotnet run
```

Swagger disponível em:

```id="6j7p4m"
https://localhost:{porta}/swagger
```

---

## 🚀 Próximos passos (se evoluir o projeto)

* Persistência em SQL Server
* Validação de dados (ex: CPF)
* Autenticação
* Logs estruturados
* Testes de integração
* Deploy em cloud

---

## 👨‍💻 Autor

Fernando H. N. Cecyn

---

## 💬 Observação final

Esse projeto foi pensado mais como demonstração de organização e tomada de decisão técnica do que apenas entrega de funcionalidade.
A ideia foi manter o código simples, legível e fácil de evoluir — como deveria ser em um ambiente real.
