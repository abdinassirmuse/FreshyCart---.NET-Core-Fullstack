# Simple Login and Register
**Brief Description:** A simple login and register form that lets users input information and store that information into a database. After successful login/register, it will navigate the user to a homepage. The homepage has a logout button as one of the links in the navbar. This form has no validation on it, except the name and the email which have a pattern validation but that is it. The **goal** of this specific project was to showcase my ability to be able to use .NET Core with AngularJS and Typescript. 

This project is a simple login and register form that uses .NET Core with AngularJS.
The data access layer and the API was created using .NET Core while the frontend was done using AngularJS with TypeScript. 
The database that was used in this project is SQL.

## How to launch: 
### Things that need to be setup before launching. 

1. Install node_module into the FreshyCartApp folder. 
    1. Launch Command Prompt
    2. Navigate to the location of the FreshyCartApp folder. 
    3. run 'npm install'
2. Create a local database called FreshyCartDB. *the sql script is already included in the FreshyCart folder*
3. Update the appsettings.json file
"ConnectionStrings": {
    "FreshyCartDBConnectionString": "data source=[server name];initial catalog=FreshyCartDB;Integrated Security=true"
  }

### Launch Data Access Layer and Web API Project

1. Open the solution in Visual Studio (I used Visual Studio 2019 community edition.)
2. Set the FreshyCartWebAPI as the starter project.
3. Build solution
4. Start project without debugging. (It going to launch a web browser and print a message saying 'This localhost page can’t be found' but don't worry about it).  

### Launch Angular Project
1. Launch Command Prompt
2. Navigate to the location of the FreshyCartApp folder. 
3. Type 'ng serve --open' and press ENTER.
4. It should launch your default web browser and display the frontend. 


## Frontend pictures 

### Register page
![alt text](https://github.com/abdinassirmuse/FreshyCart---.NET-Core-Fullstack/blob/master/Login%20and%20Register/FreshyCart/frontend%20images/register.PNG)

### Login page
![alt text](https://github.com/abdinassirmuse/FreshyCart---.NET-Core-Fullstack/blob/master/Login%20and%20Register/FreshyCart/frontend%20images/login.PNG)

*background image by travis blessing from Pexels*
