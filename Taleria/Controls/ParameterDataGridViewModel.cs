using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Taleria.Requests;

namespace Taleria.Controls;

public partial class ParameterDataGridViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<Param> _parameters;
    [ObservableProperty] private ICommand? _deleteCommand;
    [ObservableProperty] private ICommand? _addCommand;
}