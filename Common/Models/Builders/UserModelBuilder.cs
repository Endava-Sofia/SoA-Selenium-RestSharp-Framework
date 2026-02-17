using AutomationFrameworks.Common.Models;

namespace AutomationFrameworks.Common.Models.Builders;

public class UserModelBuilder
{
    private UserModel _userModel;

    public UserModelBuilder()
    {
        _userModel = new UserModel();
    }

    public UserModelBuilder WithDefaultValues()
    {
        _userModel.FirstName = "John";
        _userModel.Surname = "Doe";
        _userModel.Email = $"john.doe{Guid.NewGuid()}@example.com";
        _userModel.Password = "SecureP@ssw0rd";
        _userModel.Country = "USA";
        _userModel.City = "New York";

        return this;
    }

    public UserModelBuilder WithFirstName(string firstName)
    {
        _userModel.FirstName = firstName;

        return this;
    }

    public UserModelBuilder WithSurname(string surname)
    {
        _userModel.Surname = surname;

        return this;
    }

    public UserModelBuilder WithEmail(string email)
    {
        _userModel.Email = email;

        return this;
    }

    public UserModelBuilder WithPassword(string password)
    {
        _userModel.Password = password;

        return this;
    }   

    public UserModelBuilder WithCountry(string country)
    {
        _userModel.Country = country;

        return this;
    }

    public UserModelBuilder WithCity(string city)
    {
        _userModel.City = city;

        return this;
    }

    public UserModel Build()
    {
        return _userModel;
    }
}
