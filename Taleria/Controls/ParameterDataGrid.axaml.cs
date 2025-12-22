using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using CommunityToolkit.Mvvm.Input;
using Taleria.Requests;

namespace Taleria.Controls;

public class ParameterDataGrid : TemplatedControl
{
    public static readonly StyledProperty<ObservableCollection<Param>> ParametersProperty =
        AvaloniaProperty.Register<ParameterDataGrid, ObservableCollection<Param>>(nameof(Parameters));
    
    public static readonly StyledProperty<ICommand> DeleteCommandProperty =
        AvaloniaProperty.Register<ParameterDataGrid, ICommand>(nameof(DeleteCommand));
    
    public static readonly StyledProperty<ICommand> AddCommandProperty =
        AvaloniaProperty.Register<ParameterDataGrid, ICommand>(nameof(AddCommand));
    
    public ObservableCollection<Param> Parameters
    {
        get => GetValue(ParametersProperty);
        set => SetValue(ParametersProperty, value);
    }
    
    public ICommand DeleteCommand
    {
        get => GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }
    
    public ICommand AddCommand
    {
        get => GetValue(AddCommandProperty);
        set => SetValue(AddCommandProperty, value);
    }
}