namespace WorstMovies.IntegrationTests.Setup;

[CollectionDefinition("WebApplicationFactory", DisableParallelization = true)]
public class WebApplicationTestsCollection: ICollectionFixture<WorstMoviesApplicationFactory> { }