# DevFreela

Projeto desenvolvido durante o curso ***Formação ASP.NET Core*** do **LuisDev**.

O projeto foi desenvolvido como uma WebAPI em .NET 7, utilizando tecnologias como:

- 🛠️ Swagger
- 🛠️ Clean Architecture
- 🛠️ Entity Framework Core
- 🛠️ Repository Pattern
- 🛠️ Dapper 
- 🛠️ CQRS
- 🛠️ MediatR
- 🛠️ JWT (Json Web Token)

A API é o backend de uma aplicação gerenciamento de projetos. Contendo as seguintes funções:

- Criação, exclusão e atualização de projetos;
- Criação e atualização de skills para os freelancers e clientes;
- Criação, exclusão, atualização, ativação, adição e remoção de skills e login de usuários;

### 📀 Swagger

O Swagger é um framework composto por diversas ferramentas que, independente da linguagem, auxilia a descrição, consumo e visualização de serviços de uma API REST. Através dessa ferramenta é possível executar os métodos implementados nos controllers da API assim como obter uma documentação completa da API.

---
### 📀 Clean Architecture

***Clean Architecture*** é uma arquitetura de software com o objetivo de padronizar e organizar o código desenvolvido, favorecendo reusabilidade e separação de responsabilidades. Sendo bem utilizada com DDD, devido a ser centrada no domínio, onde o seu acoplamento direcionado preza que o núcleo não dependa de nada, aumenta a testabilidade.

---

### 📀 Entity Framework Core

O Entity Framework é um ORM (Object-relational mapping) que permite trabalhar diretamente com dados na forma de objetos de domínio, ou entidades. O Entity permite que façamos um mapeamento dos elementos de nossa base de dados para os elementos de nossa aplicação.

---

### 📀 Dapper

O Dapper é um "mini" ORM, não sendo tão poderoso quanto o Entity Framework em recursos, mas possuindo um ótimo desempenho de consultas ao banco de dados e ainda mantendo a função de auto mapeamento das entidades.

--- 

### 📀 CQRS

**C**ommand **Q**uery **R**esponsibility **S**egregation, o **CQRS**, é um padrão de arquitetura que busca a separação da leitura e da escrita em dois modelos: query e command, respectivamente.

- **Query model**: responsável pela leitura dos dados do banco e pela atualização da interface gráfica.
- **Command model**: responsável pela escrita de dados no banco e pela validação dos dados.

---

### 📀 MediatR

O Mediator é um padrão de projeto Comportamental criado pelo GoF, que nos ajuda a garantir um baixo acoplamento entre os objetos de nossa aplicação. Ele permite que um objeto se comunique com outros sem saber suas estruturas. Em outras palavras podemos dizer que o Mediator Pattern gerencia as interações de diferentes objetos. Através de uma classe mediadora, centraliza todas as interações entre os objetos, visando diminuir o acoplamento e a dependência entre eles. Desta forma, neste padrão, os objetos não conversam diretamente entre eles, toda comunicação precisa passar pela classe mediadora.

---

### 📀 Json Web Token - JWT

JWT (JSON Web Token) é um método padrão da indústria para realizar autenticação entre duas partes por meio de um token assinado que autentica uma requisição web. Esse token é um código em Base64 que armazena objetos JSON com os dados que permitem a autenticação da requisição.
