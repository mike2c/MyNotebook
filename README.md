# MyNotebook Application
 A simple asp.net aplication developed using C# asp.net core, mvc, entity framework core.
 This application doesn't need to be connected to a database server because the data is saved using sqlite.

## Requirements
- Visual Studio Community 2019
- .NET 5.0

# Installations steps
- Open Visual Studio 2019
- clone the repository https://github.com/mike2c/MyNotebook.git
- Build the solution
- Open Package Manager Console
- Run command: **update-database**
- Press F5 to run the application

# Configuring TinyMCE Control (OPTIONAL)
This application uses a WYSIWYG control called **TinyMCE**, it's a control that allows you to write text and modify its format. 
This control doesn't need to be bought but uses an api key that removes a message asking for the **Apikey**, but without the Apikey the control will continue working normally.

1. To get an **Apikey** of this control, you just need to create an account in its official site https://www.tiny.cloud/.

![image](https://user-images.githubusercontent.com/8660882/152703289-cba13cc9-e38d-4573-bad5-2b1ea7ecf490.png)

2. Once you have created the account and logged in, you will see the Apikey in the dashboard or main section of your account.

![image](https://user-images.githubusercontent.com/8660882/152703527-dbec5a9d-5fc2-4992-8aa0-8374728ca737.png)

3. Copy the **Apikey** and go to the **appsettings.json** located in the **Web** project of the solution and replace the existing one.

![image](https://user-images.githubusercontent.com/8660882/152703592-5ce60ecd-b3ce-481e-8fb3-6052f1ce7935.png)


Any improvement you want to do to the project please feel free to create a pull request.

**Regards.**
