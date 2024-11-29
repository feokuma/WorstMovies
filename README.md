# Worst Movies
Esta API tem retonar a lista dos indicadores e vencedores da categoria **Pior Filme** do [Golden Raspberry Awards](https://razzies.com).

## Tecnologias
- [.NET 9](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0)
- [EF Core](https://learn.microsoft.com/pt-br/ef/core/)
- [SQLite](https://www.sqlite.org/)

---

## Executando a aplicação
Para executar a aplicação é necessário ter com [.NET 9](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0) instalado.
Antes de executar o projeto é necessário executar as migrations para garantir que o banco de dados está preparado para a aplicação.
    
### Restaurando as ferramentas do dotnet
O seguinte comando vai garantir que as ferramentas necessárias estarão disponíveis
```shell
dotnet tool restore
```

### Executando as migrations
Para garantir que o banco de dados estará preparado para a aplicação é necessário executar as migrations com o seguinte comando
```shell
dotnet ef database update --project WorstMovies.API
```
Este comando deverá criar arquivo chamado `WorstMovies.db` na raiz do projeto [WorstMovies.API](WorstMovies.API) que é basicamente o nosso banco de dados.

### Executando o projeto

Na raiz do projeto execute o seguinte comando para executar a aplicação:
```shell
dotnet run --project WorstMovies.API
```

---

## Executando os testes de integração
Na raiz do projeto execute o seguinte comando para rodar os testes de integração:
```shell
dotnet test
```

---

## Criando novas migrations
Ao fazer modificações nas configurações dos modelos do banco de dados é necessário criar novas migrations para permitir a atualização das tabelas. Assim que finalizar os ajustes, execute o seguinte comando, no diretório raiz do projeto, para gerar uma nova migration

```shell
dotnet ef migrations add <nome da migration> --project WorstMovies.API
```
Ao final da execução deste comando uma nova migration deve ser criada no diretório [Migrations](WorstMovies.API/Migrations)

🤚 Para que este comando funcione é importante garantir que as ferramentas foram restauradas com o comando descrito em [Restaurando as ferramentas do dotnet](#restaurando-as-ferramentas-do-dotnet)