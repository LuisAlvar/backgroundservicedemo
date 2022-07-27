# .NET 6.0 Worker Serivce Publish as A Windows Service
Main Source: [Create a Windows Service Using Background Service](https://docs.microsoft.com/en-us/dotnet/core/extensions/windows-service)

.NET Framework developers are probably familiar with Windows Service apps. Before .NET Core and .NET 5+, developers who relied on .NET Framework could create Windows Services to perform background tasks or execute long-running processes. This functionality is still available and you can create Worker Services that run as a Windows Service.

We start first by creating the solution file for the 
```bash 
dotnet new sln --name BackgroundServiceDemo
```
Next, we get the template for the Worker Service 
```bash 
dotnet new worker --name BackgroundServiceDemo --framework "net6.0"
```
Next, add the woker service to the solution file 
```bash 
dotnet sln add **/*.csproj BackgroundServiceDemo.sln
```

Add the following NuGet Packages: 
* Microsoft.Extensions.Hosting.WindowsServices
* Microsoft.Extensions.Http 
```bash
dotnet add package Microsoft.Extensions.Http --version 6.0.0
```

### Publish the app 
**Important Information**

To create the .NET Worker Servicen as a Windows Service, it's recommended that you publish the app as a single file executable. **It's less error-prone to have a self-contained executable, as there aren't any dependent files lying around the file system**. 

In this case, I will publish as an .exe. 

```xml
    <OutputType>exe</OutputType>
    <PublishSingleFile Condition="'$(Configuration)' == 'Release'">true</PublishSingleFile>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <PlatformTarget>x64</PlatformTarget>
```

The project file now contains the following information
* create a console application 
* Enable single-file publishing 
* Runtime Id as windows x64 
* target platform CPU of 64-bit


