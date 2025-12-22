namespace Taleria.ViewModels;

public partial class TabbedViewModel : ViewModelBase
{
    [ObservableProperty]
    private MainViewModel _mainViewModel;
    
    [ObservableProperty] private RestClient _restClient;
    
    public TabbedViewModel(MainViewModel mainViewModel, RestClient restClient)
    {
        _restClient = restClient;
        _mainViewModel = mainViewModel;
    }
}