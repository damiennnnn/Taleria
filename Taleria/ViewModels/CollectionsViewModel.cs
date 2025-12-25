using System.Collections.ObjectModel;
using Taleria.Models;

namespace Taleria.ViewModels;

public partial class CollectionsViewModel : ViewModelBase
{
    [ObservableProperty]
    private Collection _selectedCollection;
    
    [ObservableProperty]
    private MainViewModel _selectedViewModel;
    
    [ObservableProperty]
    private ObservableCollection<Collection> _collections;
    
    [ObservableProperty] private RestClient _restClient;

    partial void OnSelectedCollectionChanged(Collection collection)
    {
        // Not root node and has view model
        if (!collection.Children.Any() && collection.MainViewModel is { } vm)
            SelectedViewModel = vm;
    }
    
    public CollectionsViewModel(MainViewModel mainViewModel, RestClient restClient)
    {
        _restClient = restClient;
        _collections = new ObservableCollection<Collection>()
        {
            new Collection()
            {
                Name = "New Collection",
                MainViewModel = mainViewModel,
                Children = new()
                {
                    new Collection()
                    {
                        Name = "New API",
                        MainViewModel = new MainViewModel(restClient),
                    },
                    new Collection()
                    {
                        Name = "New API 2",
                        MainViewModel = new MainViewModel(restClient),
                    }
                }
            }
        };
        SelectedViewModel = mainViewModel;
    }
}