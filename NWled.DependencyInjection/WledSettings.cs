namespace NWLED;

public class WledSettings
{
    public string Url { get; set; } = string.Empty;
    public HttpMessageHandler HttpMessageHandler { get; set; } = new HttpClientHandler();
}