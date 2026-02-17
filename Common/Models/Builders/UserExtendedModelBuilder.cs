using AutomationFrameworks.Common.Models;

namespace AutomationFrameworks.Common.Models.Builders;

public class UserExtendedModelBuilder
{
    private UserExtendedModel _userDto;

    public UserExtendedModelBuilder()
    {
        _userDto = new UserExtendedModel();
    }

    public UserExtendedModelBuilder WithDefaultValues()
    {
        _userDto.FirstName = "John";
        _userDto.SirName = "Doe";
        _userDto.Email = $"john.doe{Guid.NewGuid()}@example.com";
        _userDto.Password = "SecureP@ssw0rd";
        _userDto.Country = "USA";
        _userDto.City = "New York";
        _userDto.Title = "Mr.";
        _userDto.IsAdmin = 0;

        return this;
    }

    public UserExtendedModel Build()
    {
        return _userDto;
    }
}