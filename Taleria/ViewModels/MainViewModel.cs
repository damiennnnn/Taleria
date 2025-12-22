using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using AvaloniaEdit.Document;
using CommunityToolkit.Mvvm.Input;
using Taleria.Extensions;
using Taleria.Requests;

namespace Taleria.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly RestClient _client;

    [ObservableProperty] private Method _selectedMethod;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Request URL is required")]
    [Url(ErrorMessage = "Provided URL is not valid")]
    private string? _requestUri;

    [ObservableProperty] private ObservableCollection<Param> _requestParameters = [];

    [ObservableProperty] private ObservableCollection<Param> _requestHeaders = [];

    public ObservableCollection<Method> Methods { get; set; } = new(Enum.GetValues<Method>());

    [ObservableProperty] private TextDocument _requestDocument = new(initialText: """
        {
          "example": "body"
        }
        """);

    [ObservableProperty] private TextDocument _responseDocument;

    [ObservableProperty] private HttpStatusCode _statusCode;

    [ObservableProperty] private bool _isSuccess;

    [ObservableProperty] private bool _hasResponse;
    
    [ObservableProperty] private string _elapsedMilliseconds;

    [ObservableProperty] private ObservableCollection<Param> _responseHeaders = [];

    public MainViewModel(RestClient client)
    {
        _client = client;
        _responseDocument = new TextDocument();
        _requestHeaders = new(new Param[]
        {
            new("Accept", "*/*"),
            new("Connection", "keep-alive"),
            new("User-Agent", "Taleria-Client")
        });
    }

    public MainViewModel()
    {
        
    }

    partial void OnRequestUriChanging(string? value)
    {
        if (value is null)
            return;
        
        string pattern = @"\{([^}]*)\}";
        RegexOptions options = RegexOptions.Multiline;
        
        foreach (Match m in Regex.Matches(value, pattern, options))
        {
            var name = m.Groups.Values.FirstOrDefault(g => g is not Match)?.Value;
            if (name is null)
                continue;

            if (RequestParameters.Any(p => p.Name == name && p.Segment))
                continue;
            
            RequestParameters.Add(new (name, "") {Segment = true});
        }
    }
    
    [RelayCommand]
    private async Task SendRequestAsync()
    {
        ClearErrors();

        ValidateAllProperties();
        if (HasErrors)
            return;

        var request = new RestRequest(RequestUri, SelectedMethod);
        
        foreach (var param in RequestParameters)
        {
            if (param.Segment)
                request.AddUrlSegment(param.Name, param.Value);
            else
                request.AddParameter(param.Name, param.Value);
        }
        
        var watch = Stopwatch.StartNew();
        var response = await _client.ExecuteAsync(request);
        watch.Stop();

        ElapsedMilliseconds = $"{watch.ElapsedMilliseconds} ms";
        
        StatusCode = response.StatusCode;
        IsSuccess = response.IsSuccessStatusCode;

        if (response.Headers is not null)
            ResponseHeaders = new(response.Headers.Select<HeaderParameter, Param>(h => h));

        ResponseDocument.Text = response.Content?.AsIndentedJson();
        HasResponse = true;
    }

    [RelayCommand]
    private async Task AddParameterRow()
    {
        RequestParameters.Add(new ($"Parameter {RequestParameters.Count}", ""));
    }
    
    [RelayCommand]
    private async Task AddHeaderRow()
    {
        RequestHeaders.Add(new ($"Header {RequestHeaders.Count}", ""));
    }

    [RelayCommand]
    private async Task RemoveHeader(Param param)
    {
        RequestHeaders
            .Remove(param);
    }
    
    [RelayCommand]
    private async Task RemoveParameter(Param param)
    {
        if (param.Segment && RequestUri is not null)
        {
            RequestUri = Regex.Replace(RequestUri, $"/\\{{({param.Name})\\}}", string.Empty);
        }
        
        RequestParameters
            .Remove(param);
    }
}