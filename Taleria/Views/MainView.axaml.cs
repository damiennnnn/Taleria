using AvaloniaEdit;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace Taleria.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        Initialized += OnInitialized;
    }

    private void OnInitialized(object? sender, EventArgs e)
    {
        var registryOptions = new RegistryOptions(ThemeName.Abbys);
        
        //var textMateInstallation = ResponseEditor.InstallTextMate(registryOptions);
        
        //textMateInstallation.SetGrammar(
        //    registryOptions.GetScopeByLanguageId(registryOptions.GetScopeByExtension(".json")));
    }
}