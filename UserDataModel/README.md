--------------------------User Data Model using Rest API---------------------------------
-------------------------------------------------------------------------------------------------------
This Project called "User Data Model" where I have implemented Rest API using ASP.Net Rest Api.
Tools Used : Docker Desktop, Azure Data Studio, Visual studio 2019, Github, Postman , Bash Terminal
Reference for Documentation : Microsoft 
First i have created a Docker container called "Test-mssql" after pulling MSSQL-2017 images from Docker hub.
Then created database named "UserDataModel" inside the container.
There are 4 tables inside database :Users,roles,units,uRoles
Project containes 4 Controller files : UsersController.cs, UnitController.cs ,RoleController.cs ,URoleController.cs
For Data Models i have used one file "User.cs" where models for the sections are defined
Interface and Service Method details are in the folder "UserData" :IUserData.cs , UserDataService.cs
For DB Context model i have used one file "UserContext.cs" containing the definition of all sections.
On each table based on the HTTP request CRUD operation can be performed followed by some Validation.
Based on request (Get,Post,Patch,Delete) it will interact with the respective Table for the requested Operation.
For Testing I have used Postman tool.
