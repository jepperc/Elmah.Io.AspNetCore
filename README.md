# Elmah.Io.Extensions.Logging[![Build status](https://ci.appveyor.com/api/projects/status/eiw9tpstm67t02v6?svg=true)](https://ci.appveyor.com/project/ThomasArdal/elmah-io-extensions-logging)Log to [elmah.io](https://elmah.io/) from [Microsoft.Extensions.Logging](https://github.com/aspnet/Logging).## InstallationElmah.Io.Extensions.Logging installs through NuGet:```PS> Install-Package Elmah.Io.Extensions.Logging```Configure the elmah.io provider through code:```csharpvar factory = new LoggerFactory();factory.AddElmahIo("API_KEY", new Guid("LOG_ID"));var logger = factory.CreateLogger("MyLog");```In the example we create a new `LoggerFactory` and add the elmah.io provider using the `AddElmahIo` extension method. You will need to replace `API_KEY` with your elmah.io API key (found on your profile) as well as the log ID of the elmah.io log you want to log to. Finally, we create a new logger which is used later in this example to log messages to elmah.io.## UsageThe logger automatically logs all warnings and errors happening in your web application. You can log exceptions manually like this:```csharplogger.LogError(1, new Exception(), "Unexpected error");```