# Teste Desempenho - Prefeitura
Implementado um CRUD de produtos para o teste de desempenho da Prefeitura de Patos de Minas.

## Tecnologias Usadas
 - Backend: ASP.NET Core 3.1
 - Banco de Dados não relacional: Mongo
 - Frontend: Nuxt.js(Vue + Vuetify.js)
 
## Como executar
 -  Banco de Dados: Usando o utilitario mongod que fica dentro da pasta bin do mongo, execute o seguinte comando: mongod -dbpath "Coloque uma pasta a sua escolha aqui"
Ex.: mongod -dbpath C:\mongo\data
 - Backend: Navegue até a pasta backend do repositório e execute o seguinte comando:
dotnet run
 -  Frontend: Navegue até a pasta frontend do repositório e execute os seguintes comandos: npm i e logo apos npm run dev. Depois basta acessar no navegador o endereço: https://localhost:3000
 - Portas em que os projetos devem rodar: Mongo: 27017, Dotnet: 5001 e Nuxt: 3000
## Qual era o objetivo?
Construir um projeto simples capaz de operar um CRUD com os seguintes atributos para
Produtos:
 - Nome
 - Descrição
 - Preço
 - Categoria

## Observação
Caso o projeto não mostre os itens cadastrados, na pasta do backend execute o seguinte comando:


 - dotnet  dev-certs https --trust

Este comando serve para definir o localhost como uma página segura para requisitar informações ao dotnet.
