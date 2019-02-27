Create database MyanTour
Drop database MyanTour
Create table Express(
Id varchar(20) primary key,
CarNo Varchar(10) not null,
DriverName varchar(10) not null,
Model varchar(20) not null,
Pic image,
Seat varchar(60),
AvailableSeat varchar(60),
State varchar(10)
)
Create table ExpressPrice(
LocFrom varchar(15),
LocTo varchar(15),
Price Money
)
Create table Car(
Id varchar(20) primary key,
CarNo Varchar(10) not null,
DriverName varchar(10) not null,
Model varchar(20) not null,
Pic image,
Seat int,
State varchar(10)
)

Create table Flight(
Id varchar(20) primary key,
flightCode Varchar(20) not null,
Pilot varchar(10) not null,
Model varchar(20) not null,
Pic image,
Seat varchar(60),
AvailableSeat varchar(60),
State varchar(10)
)
Create table Cruies(
Id varchar(20) primary key,
ShipNumber Varchar(20) not null,
Captain  varchar(10) not null,
Model varchar(20) not null,
Pic image,
Seat varchar(60),
AvailableSeat varchar(60),
State varchar(10)
)
Create table Express_Booking(
Id varchar(20) primary key ,
CustomerID nvarchar(128),
VehicalID varchar(20),
StartDate date,
EndDate date,
FerryPoint varchar(30),
Loc varchar(150),
Charges money,
State varchar(10),
CONSTRAINT FK_Express_UserID FOREIGN KEY (CustomerID) REFERENCES dbo.AspNetUsers(Id),
CONSTRAINT FK_Express_VehID FOREIGN KEY (VehicalID) REFERENCES Express(Id)
)
Create table Car_Booking(
Id varchar(20) primary key ,
CustomerID nvarchar(128),
VehicalID varchar(20),
StartDate date,
EndDate date,
FerryPoint varchar(30),
Loc varchar(150),
Charges money,
State varchar(10),
CONSTRAINT FK_Car_UserID FOREIGN KEY (CustomerID) REFERENCES dbo.AspNetUsers(Id),
CONSTRAINT FK_Car_VehID FOREIGN KEY (VehicalID) REFERENCES Car(Id)
)
Create table Flight_Booking(
Id varchar(20) primary key ,
CustomerID nvarchar(128),
VehicalID varchar(20),
StartDate date,
EndDate date,
FerryPoint varchar(30),
Loc varchar(150),
Charges money,
State varchar(10),
CONSTRAINT FK_Flight_UserID FOREIGN KEY (CustomerID) REFERENCES dbo.AspNetUsers(Id),
CONSTRAINT FK_Flight_VehID FOREIGN KEY (VehicalID) REFERENCES Flight(Id)
)
Create table Cruies_Booking(
Id varchar(20) primary key ,
CustomerID nvarchar(128),
VehicalID varchar(20),
StartDate date,
EndDate date,
FerryPoint varchar(30),
Loc varchar(150),
Charges money,
State varchar(10),
CONSTRAINT FK_Cruies_UserID FOREIGN KEY (CustomerID) REFERENCES dbo.AspNetUsers(Id),
CONSTRAINT FK_Cruies_VehID FOREIGN KEY (VehicalID) REFERENCES Cruies(Id)
)
create database test
create table CArdatabase (
id varchar(10),
bar image,
KO varchar(10)
)
INSERT INTO ii
SELECT 10, BulkColumn 
FROM Openrowset( Bulk 'C:\Users\acer\Desktop\Data\express1.jpg', Single_Blob) as img,
select * from Car
select * from ii

INSERt dbo.AspNetRoles values ('A1','Admin')
INSERt dbo.AspNetUserRoles values ('581b55fc-5c3d-4276-85e2-fa0c58e63d31','A1')


