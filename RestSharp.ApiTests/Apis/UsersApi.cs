using AutomationFrameworks.Common.Models;

namespace RestSharp.ApiTests.Apis;

public class UsersApi
{
    private readonly RestClient _client;
    private readonly string _uri;

    public UsersApi(RestClient restClient)
    {
        _client = restClient;
        _uri = "/users";
    }

    public RestResponse<UserExtendedModel> GetUserById(int id)
    {
        var request = new RestRequest($"{_uri}/{id}", Method.Get);
        return _client.Execute<UserExtendedModel>(request);
    }

    public RestResponse<T> CreateUser<T>(object expectedUser) where T : notnull
    {
        var request = new RestRequest(_uri, Method.Post);
        request.AddJsonBody(expectedUser);

        return _client.Execute<T>(request);
    }
}