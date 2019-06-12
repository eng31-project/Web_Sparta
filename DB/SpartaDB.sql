Use Northwind; 
drop database IF EXISTS SpartaDB
go

create database SpartaDB
go

use SpartaDB
go

CREATE TABLE Roles(
	RoleID INT NOT NULL IDENTITY PRIMARY KEY, 
	RoleName NVARCHAR(50) NOT NULL
);  

CREATE TABLE Specialisations(
	SpecialisationID INT NOT NULL IDENTITY PRIMARY KEY, 
	SpecialisationName NVARCHAR(50) NOT NULL
);
 
CREATE TABLE Cohorts(
	CohortID INT NOT NULL IDENTITY PRIMARY KEY, 
	CohortName NVARCHAR(50) NOT NULL, 
	SpecialisationID INT NULL FOREIGN KEY REFERENCES Specialisations(SpecialisationID)
);  
CREATE TABLE Users (
	UserID INT NOT NULL IDENTITY PRIMARY KEY, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	Email NVARCHAR(50) NOT NULL, 
	Password NVARCHAR(MAX) NOT NULL, 
	CohortID INT NULL FOREIGN KEY REFERENCES Cohorts(CohortID), 
	RoleID INT NULL FOREIGN KEY REFERENCES Roles(RoleID)
);
 

SET IDENTITY_INSERT Roles ON
INSERT INTO Roles (RoleID , RoleName) VALUES (1, 'Admin'),(2, 'Trainer'),(3, 'Trainee') 
SET IDENTITY_INSERT Roles OFF

SET IDENTITY_INSERT Specialisations ON
INSERT INTO Specialisations(SpecialisationID , SpecialisationName) VALUES (1, 'C#'),(2, 'Java'),(3, 'Ruby') 
SET IDENTITY_INSERT Specialisations OFF

SET IDENTITY_INSERT Cohorts ON
INSERT INTO Cohorts(CohortID,CohortName, SpecialisationID  ) VALUES (1,'Engineering-31',1),(2, 'Engineering-32',3),(3, 'Data-2',2) 
SET IDENTITY_INSERT Cohorts OFF

SET IDENTITY_INSERT Users  ON
INSERT INTO Users (UserID ,FirstName, LastName, Email, Password, CohortID, RoleID ) VALUES 
(1, 'Jaspreet', 'Rai', 'Jrai@spartaglobal.com', 'Password',2,3),
(2, 'Phil', 'Anderson', 'Phil@spartaglobal.com', 'thisshouldbehashed',1,2),
(3, 'Li', 'Dinh', 'Ldinh@spartaglobal.com', 'Password',2,3),
(4, 'Luitzen', 'H', 'LH@spartaglobal.com', 'Password',2,3),
(5, 'Seb', 'T', 'ST@spartaglobal.com', 'Password',2,3)
SET IDENTITY_INSERT Users OFF


