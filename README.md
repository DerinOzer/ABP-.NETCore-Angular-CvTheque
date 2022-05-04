## CvTheque: A C# Web Application Using The ABP Framework

This web app allows recruiters to keep track of candidates.

### Install the ABP Command Line Input (CLI):
> dotnet tool install -g Volo.Abp.Cli


### Run the solution:
Set the two following projects as "StartUp Project":

*Simphonis.CvTheque.IndentityServer* 

*Simphonis.CvTheque.HttpApi.Host*


Hit F5 (or Ctrl+F5) to run the application.


### Run the Angular project:

While your solution is still running, open a terminal inside Visual Studio(or Visual Studio Code) and type the following commands:

> npm install
> 
> npm start

The application should now be running on http://localhost:4200/
