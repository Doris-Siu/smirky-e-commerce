-- how to add a migration
1. cd TangyWeb_Server
2. dotnet ef migrations list --project ../Tangy_DataAccess
3. dotnet ef migrations add <migration_name> --project ../Tangy_DataAccess
4. dotnet ef database update

-- how to remove last migration
1. cd TangyWeb_Server
2. dotnet ef migrations list --project ../Tangy_DataAccess
3. dotnet ef migrations remove
4. dotnet ef database update

--add identity by asp.net scaffolding
https://learn.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-7.0&tabs=netcore-cli

-For postgresql,
use `DateTime.UtcNow` instead of `DateTime.Now`

-For email sender
I am using personal Gmail address as an SMTP server to send email in C# .NET using SmtpClient. There are some steps to follow:

1. Enable two-factor authentication (2FA) on your Gmail account.
    This is a security measure that will help to protect your account from unauthorized access.
2. Create an app password for your Gmail account.
    This is a unique password that you will use to authenticate with the SMTP server.
3. Configure your C# code to use the following SMTP settings:
    Host: smtp.gmail.com
    Port: 587
    EnableSsl: true
    Credentials: new NetworkCredential("your_gmail_address", "your_app_password")