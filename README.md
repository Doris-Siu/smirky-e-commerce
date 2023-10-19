# E-Commerce website
This is an e-commerce application using Blazor Web Assembly and Blazor Server, consuming .NET 6 API. All the data involved will be linked and stored in the database. 

On the front-end, customers can browse products, add products to the cart, and pay with Stripe integrated with the website.
https://github.com/Doris-Siu/smirky-e-commerce/assets/107772913/500d5a93-ca2b-473c-ba62-aa8c26f22c14

On the back-end, Authentication is applied where only Admin can access and manage the contents, including product information displayed on the front-end, customer details, and order information.
https://github.com/Doris-Siu/smirky-e-commerce/assets/107772913/a7c7cbac-309d-42b9-a94f-4d351dc05b4e

The front-end consumes .NET 6 API to perform CRUD operations.
<img width="1440" alt="api" src="https://github.com/Doris-Siu/smirky-e-commerce/assets/107772913/ae937740-6d49-4fc4-908f-65d0f9820356">


## Technologies
- Blazor
- .NET 6 API
- EF
- C#
- .NET
- Javascript
- CSS
- Radzen
- Stripe Payment
- Postgresql


## Opening in Visual Studio
Prerequisites:
- Follow the steps [here](https://github.com/dotnet/aspnetcore/blob/main/docs/BuildFromSource.md) to set up a local copy of dotnet
- Visual Studio 2017 15.7 latest preview - [download](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?ch=pre&sku=Enterprise&rel=15)

We recommend getting the latest preview version of Visual Studio and updating it frequently. The Blazor editing experience in Visual Studio depends on new features of the Razor language tooling and will be updated frequently.

When installing Visual Studio choose the following workloads:

- ASP.NET and Web Development
- Visual Studio extension development features

If you have problems using Visual Studio with Blazor.sln please refer to the [developer documentation](https://github.com/dotnet/aspnetcore/blob/main/docs/BuildFromSource.md).

## Developing the Blazor VS Tooling
To do local development of the Blazor tooling experience in VS, select the Microsoft.VisualStudio.BlazorExtension project and launch the debugger.

The Blazor Visual Studio tooling will build as part of the command line build when on Windows.

## Usage (on macOS)
### Add a DB migration 
```
cd TangyWeb_Server
dotnet ef migrations list --project ../Tangy_DataAccess
dotnet ef migrations add <migration_name> --project ../Tangy_DataAccess
dotnet ef database update
```

### Remove last DB migration
```
cd TangyWeb_Server
dotnet ef migrations list --project ../Tangy_DataAccess
dotnet ef migrations remove
dotnet ef database update
```

### Email Sender using personal Google account
A personal Gmail address is used as an SMTP server in C# .NET using SmtpClient. There are some steps to follow:

1. Enable two-factor authentication (2FA) on your Gmail account. This is a security measure that will help to protect your account from unauthorized access.
2. Create an app password for your Gmail account. This is a unique password that you will use to authenticate with the SMTP server.
3. Configure your C# code to use the following SMTP settings: Host: smtp.gmail.com Port: 587 EnableSsl: true Credentials: new NetworkCredential("your_gmail_address", "your_app_password")

### Others
- For postgresql, use DateTime.UtcNow instead of DateTime.Now
- Add Scaffold Identity in ASP.NET Core projects, [learn more](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-7.0&tabs=netcore-cli)


## License

This project is licensed under the [MIT](https://choosealicense.com/licenses/mit/)
