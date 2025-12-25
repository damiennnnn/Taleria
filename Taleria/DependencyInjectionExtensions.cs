using RestSharp.Serializers.Json;

namespace Taleria;

public static class DependencyInjectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<RestClient>(_ => new RestClient(configureSerialization: config 
            => config.UseSystemTextJson(new JsonSerializerOptions()
        {
            WriteIndented = true
        })));
    }
    public static void AddViewModels(this IServiceCollection collection)
    {
        collection.AddTransient<MainViewModel>();
        collection.AddTransient<TabbedViewModel>();
        collection.AddTransient<CollectionsViewModel>();
    }
}