# FreshyCart Cart Page

**Brief Description:** This project is the last part of the FreshyCart project. After this, the Complete Project will be uploaded. 

This projec uses .NET Core with Angular.
The data access layer and the API was created using .NET Core while the frontend was done using AngularJS with TypeScript. 
The database that was used in this project is SQL.

## How to launch: 
### Few things you need to do before you launch this project. 
### I am assuming you already the tools to use for .NET Project.

Database Setup:
1. Once you download the project, find the **SQL Script** folder.
2. Open the folder and you will find FreshyCart.sql file and COPY the script.
3. Before we create the database and create the table, we need to do couple of things. 
	1. We need to host the images for the application in your local server.
	2. Go to your **C:\** drive  and create a Folder called FreshyCartImages.
	3. Find the FreshyCartImages folder that is included in the project. 
	4. Copy the **Products**, ***FeaturedProducts*, and ***SlideShow* folder and paste them in the FreshyCartImages you created in your **C:\** drive. 
	5. Type IIS in the window search bar and launch Internet 	Information Services(IIS).
	6. Once IIS launches, find the connections panel on the left side and expand it. You will see **Applications Pools** and **Sites**.
	7. Right-click on **Sites** and click on **Add Website...**
	8. Once you click it, a new window will pop up. 
		1. Write FreshyCartImages in the **Site name:** field.
		2. Paste the FreshyCartImages folder path in the **Physical path:** field.
		3. Type **21621** in the **Port:** field.
		4. Make sure the **Start Website immediately** checkbox is checked. 
		5. Click Ok.
		6. test that via this *http://localhost:21621/Products/tomatoes-ct.jpg* on your web browser, you shoud see a picture of a tomatoes if the steps were followed correctly. 
4. Now you can execute the database script. 

### Launch Data Access Layer(DAL) and Web API Project

1. Double click the **FreshyCart.sln** file. It should launch Visual Studio and open the two project.
2. Find the **appsettings.json** file on both projects and update it the following:
	1. "ConnectionStrings": {
    		"FreshyCartDBConnectionString": "data source=[your server name];initial catalog=FreshyCartDB;Integrated Security=true"
  		}
	2. **[your server name]** in this connection string should be the server name in your own machine that you saved the FreshyCartDB database.
3. Build the solution.
4. Start project without debugging. (It is going to launch a web browser and display all the products in the Product table in Json format).

### Launch Angular Project
1. Launch Command Prompt
2. Navigate to the location of the FreshyCartApp folder **....\FreshyCart\FreshyCartApp**
3. Type **npm install** and press Enter. This is going to download all the necessary packages for the project. 
4. Type **ng serve --open** and press ENTER.
5. It should launch your default web browser and display the frontend picture below. 


## Frontend 

### Cart page 
![alt text](https://github.com/abdinassirmuse/FreshyCart---.NET-Core-Fullstack/blob/master/Cart/FreshyCart/FreshyCartImages/cart.PNG)


The credit for the images used in the project are all available in the *../FreshyCartImages/Credit for Images* folder. 

## License:
You may use the projects in the repository for personal, academic, or educational use but not commercial use.