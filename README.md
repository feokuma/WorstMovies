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