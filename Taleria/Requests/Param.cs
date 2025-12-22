namespace Taleria.Requests;

/// <summary>
/// Represents a name-value pair parameter, such as for HTTP headers or query parameters.
/// </summary>
/// <param name="name">The parameter name.</param>
/// <param name="value">The parameter value.</param>
/// RestSharp Parameter records are immutable, but we want to populate and modify these in the UI.
public class Param(string name, string value)
{
    public string Name { get; set; } = name;
    public string Value { get; set; } = value;
    
    public bool Segment { get; set; } = false;

    public static implicit operator HeaderParameter(Param p) => new(p.Name, p.Value);
    public static implicit operator Param(HeaderParameter p) => new(p.Name, p.Value);
}