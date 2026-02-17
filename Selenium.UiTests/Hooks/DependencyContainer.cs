using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using SeleniumFramework.DatabaseOperations.Operations;
using SeleniumFramework.Pages;
using System.Data;
using RestSharp;
using AutomationFrameworks.Common.Utilities;
using RestSharp.ApiTests.Apis;
using AutomationFrameworks.Common.Models.Factories;
using AutomationFrameworks.Common.Models.Builders;
using AutomationFrameworks.Common.Models.SettingsModels;

namespace SeleniumFramework.Hooks;

public class DependencyContainer
{
    [ScenarioDependencies]
    public static IServiceCollection RegisterDependencies()
    {
        var services = new ServiceCollection();
        services.AddSingleton(sp =>
        {
            return ConfigurationManager<UiSettingsModel>.Instance.SettingsModel;
        });
        
        services.AddScoped<IWebDriver>(sp =>
        {
            //new DriverManager().SetUpDriver(new ChromeConfig());

            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            return driver;
        });

        services.AddSingleton<IUserFactory, UserFactory>();
        services.AddScoped<UserModelBuilder>();

        RegisterPages(services);
        RegisterDatabaseOperations(services);
        RegisterApi(services);

        return services;
    }

    private static void RegisterDatabaseOperations(ServiceCollection services)
    {
        services.AddScoped<IDbConnection>(sp =>
        {
            var settings = sp.GetRequiredService<UiSettingsModel>();
            var connectionString = settings.ConnectionString;

            var dbConnection = new MySqlConnection(connectionString);
            return dbConnection;
        });

        services.AddScoped(sp =>
        {
            var dbConnection = sp.GetRequiredService<IDbConnection>();
            return new UserOperations(dbConnection);
        });
    }

    private static void RegisterPages(ServiceCollection services)
    {
        services.AddScoped(sp =>
        {
            var driver = sp.GetRequiredService<IWebDriver>();
            return new LoginPage(driver);
        });

        services.AddScoped(sp =>
        {
            var driver = sp.GetRequiredService<IWebDriver>();
            return new DashboardPage(driver);
        });

        services.AddScoped(sp =>
        {
            var driver = sp.GetRequiredService<IWebDriver>();
            return new RegisterUserPage(driver);
        });
        
        services.AddScoped(sp =>
        {
            var driver = sp.GetRequiredService<IWebDriver>();
            return new UsersPage(driver);
        });
    }

    private static void RegisterApi(ServiceCollection services)
    {
        services.AddSingleton<RestClient>(sp =>
        {
            //TODO - Move the base URL to a configuration file
            var options = new RestClientOptions("http://localhost:5000");
            var client = new RestClient(options);
            client.AddDefaultHeader("Accept", "application/json");
            return client;
        });
    
        services.AddScoped(sp =>
        {
            var client = sp.GetRequiredService<RestClient>();
            return new UsersApi(client);
        });
    }
}
