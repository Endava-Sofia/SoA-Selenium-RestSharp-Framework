using System.Text.Json.Serialization;

namespace AutomationFrameworks.Common.Models;

public class UserExtendedModel : UserModel
{
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public new string FirstName { get; set; }

    [JsonPropertyName("is_admin")]
    public int IsAdmin { get; set; }

    [JsonPropertyName("sir_name")]
    public string SirName { get; set; }

    public string Title { get; set; }
}
