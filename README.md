# TheFoodParliament-CSharp

Um ferramenta que auxilia a tomada de desição mais importante do dia para um time... aonde almoçar.

## Requisitos

O back-end do projeto foi desenvolvido em Asp.net core portanto é necessário tem o [runtime](https://dotnet.microsoft.com/download/dotnet-core/3.0) instalado. Também é necessário ter um banco de dados instalado e configurado em "./Server/TheFoodParliament/appsetings.json".

Já para o front-end é necessário ter o [NPM](https://www.npmjs.com/get-npm) instalado.

## Utilização

Na primeira utilização é necessario rodar os seguintes comandos:

- No server (assumindo que o diretorio atual seja o folder 'server'):
```bash
dotnet restore
dotnet build    
```
  e para rodar as migrations, a migration criara uma serie de usuários para teste:
```bash
dotnet ef database update --project TheFoodParliament.Infrastructure/TheFoodParliament.Infrastructure.csproj --startup-project TheFoodParliament/TheFoodParliament.csproj
```
e finalment rodando o projeto:
```bash
dotnet run
```

- No client (assumindo que o diretorio atual seja o folder 'client')
```bash
npm install
npm run start
```

## Destaques

Os principais pontos que gostaria de destacar no projeto são:
- Um dos fatores que quero destacar é a organização e a clareza do código, embora longe de perfeito, creio que este seja um ponto de destaque.
- Separação em client e server, sendo que o back-end funciona como uma API, isso garante que o app pode ser facilmente migrado para outras plataformas.
- A cobertura de teste unitário está um bom nível, podendo facilmente ser incrementada devido ao extenso uso de mocks no projeto.
- No front-end a utilização do React garante um desenvolvimento simples acelerado de novas funcionalidades, sendo tudo ja devidamente componentizado.

## Melhorias
Dentre as várias melhorias que não tive tempo de implementar estão:
- Usar alguma API para buscar os restaurantes pela localização do usuário em tempo real.
- Adicionar o HangFire para dispara os eventos que são diário e dependentes de horários no projeto.
- Usar o socket.io para atualizar o front-end quando temos abertura/fechamento de votação.
- Dar uma incrementada no front-end.