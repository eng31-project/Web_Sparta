Use Northwind; 
drop database IF EXISTS SpartaDB
go

create database SpartaDB
go

use SpartaDB
go

CREATE TABLE Role(
	RoleID INT NOT NULL IDENTITY PRIMARY KEY, 
	RoleName NVARCHAR(50) NOT NULL
);  

CREATE TABLE Specialisation(
	SpecialisationID INT NOT NULL IDENTITY PRIMARY KEY, 
	SpecialisationName NVARCHAR(50) NOT NULL
);
 
CREATE TABLE Cohort(
	CohortID INT NOT NULL IDENTITY PRIMARY KEY, 
	CohortName NVARCHAR(50) NOT NULL, 
	SpecialisationID INT NULL FOREIGN KEY REFERENCES Specialisation(SpecialisationID)
);  
CREATE TABLE Users (
	UsersID INT NOT NULL IDENTITY PRIMARY KEY, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	Email NVARCHAR(50) NOT NULL, 
	Password NVARCHAR(MAX) NOT NULL, 
	CohortID INT NULL FOREIGN KEY REFERENCES Cohort(CohortID), 
	RoleID INT NULL FOREIGN KEY REFERENCES Role(RoleID)
);
 

SET IDENTITY_INSERT Role ON
INSERT INTO Role (RoleID , RoleName) VALUES (1, 'Admin'),(2, 'Trainer'),(3, 'Trainee') 
SET IDENTITY_INSERT Role OFF

SET IDENTITY_INSERT Specialisation ON
INSERT INTO Specialisation(SpecialisationID , SpecialisationName) VALUES (1, 'C#'),(2, 'Java'),(3, 'Ruby') 
SET IDENTITY_INSERT Specialisation OFF

SET IDENTITY_INSERT Cohort ON
INSERT INTO Cohort(CohortID,CohortName, SpecialisationID  ) VALUES (1,'Engineering-31',1),(2, 'Engineering-32',3),(3, 'Data-2',2) 
SET IDENTITY_INSERT Cohort OFF


SET IDENTITY_INSERT Users  ON
INSERT INTO Users (UsersID ,FirstName, LastName, Email, Password, CohortID, RoleID ) VALUES 
(1, 'Jaspreet', 'Rai', 'Jrai@spartaglobal.com', 'Password',2,3),
(2, 'Phil', 'Anderson', 'Phil@spartaglobal.com', 'thisshouldbehashed',1,2),
(3, 'Li', 'Dinh', 'Ldinh@spartaglobal.com', 'Password',2,3),
(4, 'Luitzen', 'H', 'LH@spartaglobal.com', 'Password',2,3),
(5, 'Seb', 'T', 'ST@spartaglobal.com', 'Password',2,3)
 
SET IDENTITY_INSERT Users OFF


