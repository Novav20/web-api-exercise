namespace WebApiRouteResponses.Services;

public class UserDataService : IUserDataService
{
    private List<string> Elements;
    public UserDataService()
    {
        Elements = [];
        var number = new Random();
        Elements.Add($"Value {number.Next()}");
        Elements.Add($"Value {number.Next()}");
        Elements.Add($"Value {number.Next()}");
    }
    public List<string> GetValues()
    {
        return Elements;
    }
}
