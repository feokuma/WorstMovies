# Worst Movies
Esta API tem retonar a lista dos indicadores e vencedores da categoria **Pior Filme** do [Golden Raspberry Awards](https://razzies.com).

## Tecnologias
- [.NET 9](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0)
- [EF Core](https://learn.microsoft.com/pt-br/ef/core/)
- [SQLite](https://www.sqlite.org/)
- [Scalar](https://github.com/scalar/scalar?tab=readme-ov-file)

---

## Executando a aplicação
Para executar a aplicação é necessário ter com [.NET 9](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0) instalado.

Sempre que o projeto é executado é feita a leitura de um arquivo CSV localizado no diretório de [Infraestrutura](WorstMovies.API/Infrastructure) chamado `movieslist.csv`. Este arquivo contém a lista de filmes que serão utilizados pela aplicação e é carregado para o banco de dados **SQLite** na inicialização. 

A configuração do path onde a aplicação irá buscar o arquivo csv pode ser alterada no arquivo [appsettings.json](WorstMovies.API/appsettings.json), alterando a configuração **`CsvFilePath`** 


### Executando o projeto

Na raiz do projeto execute o seguinte comando para executar a aplicação:
```shell
dotnet run --project WorstMovies.API
```

### Documentação da API
Este projeto possui uma documentação construída com o [Scalar](https://github.com/scalar/scalar?tab=readme-ov-file) e pode ser acessada na url http://localhost:5202/scalar/v1 onde é possível testar os endpoints.

---

## Executando os testes de integração
Na raiz do projeto execute o seguinte comando para rodar os testes de integração:
```shell
dotnet test
```

---

## Acessando o banco de dados
O banco de dados utilizado nesta aplicação é o [SQLite](https://www.sqlite.org/) e assim que a aplicação é executada um arquivo chamado **WorstMovies.db** é criado na raiz do diretório do projeto da API, o [WorstMovies.API](WorstMovies.API). Para acessar os dados é necessário somente um cliente para abrir este arquivo. 
