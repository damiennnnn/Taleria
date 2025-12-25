using System.Collections.ObjectModel;
using Taleria.Views;

namespace Taleria.Models;

public partial class Collection : ObservableObject
{
    [ObservableProperty] private string _name = "New Collection";
    [ObservableProperty] private MainViewModel? _mainViewModel;
    [ObservableProperty] private ObservableCollection<Collection> _children = new();
}