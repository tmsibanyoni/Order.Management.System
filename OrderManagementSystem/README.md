Steps to get the program running:

----------------------------------------------------------------------------------------
MySql
----------------------------------------------------------------------------------------
Run the following script on MySql:

Create Database
CREATE SCHEMA `ordermanagerdb` ;

CREATE TABLE `ordermanagerdb`.`customerorder` (
  `Id` INT NOT NULL,
  `CustomerSegment` INT NULL,
  `OrderDiscount` DECIMAL(2) NULL,
  PRIMARY KEY (`Id`));
  
  
  CREATE TABLE `ordermanagerdb`.`ordersdetail` (
  `Id` INT NOT NULL,
  `CustomerId` INT NULL,
  `Code` VARCHAR(45) NULL,
  `TotalAmount` DECIMAL(2) NULL,
  `OrderInitiateDateTime` DATETIME NULL,
  `OrderCompletedDateTime` DATETIME NULL,
  `Status` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`));

Microsoft.EntityFrameworkCore, Version=9.0.5.0, 
  
----------------------------------------------------------------------------------------
REDIS
----------------------------------------------------------------------------------------
Please ensure that the lastes Redis has been insalled and that it is running.
You may set the localhost:{DEFAULTPORT} on the appsettings.

----------------------------------------------------------------------------------------
UNIT TEST
----------------------------------------------------------------------------------------

Once all configurations are compelete. You can run the UnitTests in the ProjectName.
ProjectName: Order.Management.Service.Tests

----------------------------------------------------------------------------------------
API Service
----------------------------------------------------------------------------------------
The Api Service has been used to test using Swagger.
Please Restore Nuget Packages before running the application and ensure that the project builds.
You may run the application and test the Endpoints

