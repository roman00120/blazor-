using Microsoft.Extensions.DependencyInjection;
using BerriesParadise.Content.Catalogs;

namespace BerriesParadise.Content;

public static class ContentServiceCollectionExtensions
{
    public static IServiceCollection AddBerriesContentServices(this IServiceCollection services)
    {
        services.AddSingleton<BerryCatalog>();
        services.AddSingleton<ProductCatalog>();
        services.AddSingleton<GeneticsCatalog>();
        services.AddSingleton<QualityCatalog>();
        services.AddSingleton<RecipeCatalog>();
        services.AddSingleton<CompanyInformation>();
        services.AddSingleton<LocalizationService>();
        return services;
    }
}
