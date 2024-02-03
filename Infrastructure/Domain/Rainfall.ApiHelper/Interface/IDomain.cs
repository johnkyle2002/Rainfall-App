namespace Rainfall.ApiHelper.Interface
{
    public interface IDomain
    {
        Dictionary<string, string>? Header();
        string BaseUrl();
    }
}
