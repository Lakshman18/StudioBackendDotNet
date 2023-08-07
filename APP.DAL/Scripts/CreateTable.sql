CREATE DATABASE StudioDB

--Scaffold-DbContext 'Server=tcp:schoolserver.database.windows.net,1433;Initial Catalog=StudioDB;Persist Security Info=False;User ID=sqlAdmin; Password=root@123; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False;Connection Timeout=30;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -force
--Scaffold-DbContext 'workstation id=StudioDB.mssql.somee.com;packet size=4096;data source=StudioDB.mssql.somee.com;Initial Catalog=StudioDB;Persist Security Info=False;User ID=lsiva2817_SQLLogin_1; Password=w3xcmzgdq6; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=True;Connection Timeout=30;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -force

CREATE TABLE dbo.[User]
( id  INT NOT NULL    IDENTITY(1,1)    PRIMARY KEY,
  email VARCHAR(50) NOT NULL,
  password VARCHAR(50) NOT NULL
);

CREATE TABLE EventType
( id  INT NOT NULL    IDENTITY(1,1)    PRIMARY KEY,
  name VARCHAR(50) NOT NULL,
  description VARCHAR(100) ,
  isActive bit NOT NULL,
  createdBy int,
  createdDate datetime,
  updatedBy int,
  updatedDate datetime,
);

CREATE TABLE EventSubType
( id  INT NOT NULL    IDENTITY(1,1)    PRIMARY KEY,
	eventTypeId INT NOT NULL,
  name VARCHAR(50) NOT NULL,
  description VARCHAR(100) ,
  isActive bit NOT NULL,
  createdBy int,
  createdDate datetime,
  updatedBy int,
  updatedDate datetime,
   FOREIGN KEY (eventTypeId) REFERENCES EventType(id)
);

CREATE TABLE Stage
( id  INT NOT NULL    IDENTITY(1,1)    PRIMARY KEY,
  name VARCHAR(50) NOT NULL,
  description VARCHAR(100) ,
  isActive bit NOT NULL,
  createdBy int,
  createdDate datetime,
  updatedBy int,
  updatedDate datetime,
);

CREATE TABLE Customer
( id  INT NOT NULL    IDENTITY(1,1)    PRIMARY KEY,
  name VARCHAR(50) NOT NULL,
  address VARCHAR(255) ,
  phoneNumber VARCHAR(50) NOT NULL,
  email VARCHAR(50) NOT NULL,
  isActive bit NOT NULL,
  createdBy int,
  createdDate datetime,
  updatedBy int,
  updatedDate datetime,
);