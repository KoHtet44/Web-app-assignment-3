Create trigger trg_Calculating_Price
 on  dbo.Car_Booking
after insert as
declare @id varchar(20)
set @id=(select Id from Inserted)
declare	@sdate datetime 
set @sdate=(select StartDate from inserted) 
declare @edate datetime
set @edate=(Select EndDate from inserted)
declare	@tday int 
set @tday= DATEDIFF(DAY, @sdate, @edate)
--select top 1 * from MedicineStore order by Buying_Date DESC
Update  dbo.Car_Booking
set Charges = 500000 * @tday
where Id=@id
----------------------
Create trigger trg_Calculating_Price_express
 on  dbo.Express_Booking
after insert as
declare @id varchar(20)
set @id=(select Id from Inserted)
declare	@sdate datetime 
set @sdate=(select StartDate from inserted) 
declare @edate datetime
set @edate=(Select EndDate from inserted)
declare	@tday int 
set @tday= DATEDIFF(DAY, @sdate, @edate)
--select top 1 * from MedicineStore order by Buying_Date DESC
Update  dbo.Express_Booking
set Charges = 500000 * @tday
where Id=@id

drop trigger trg_Calculating_Price_express
-----------------------------------
select * from  dbo.Express_Booking
PRINT DATEDIFF(DAY, '2/12/2019 ', '2/28/2019')
-------------------------------------------------------------
Create trigger trg_Calculating_Price_Flight
 on  dbo.Flight_Booking
after insert as
declare @id varchar(20)
set @id=(select Id from Inserted)
declare	@sdate datetime 
set @sdate=(select StartDate from inserted) 
declare @edate datetime
set @edate=(Select EndDate from inserted)
declare	@tday int 
set @tday= DATEDIFF(DAY, @sdate, @edate)
--select top 1 * from MedicineStore order by Buying_Date DESC
Update  dbo.Flight_Booking
set Charges = 500000 * @tday
where Id=@id
---
Create trigger trg_Calculating_Price_Cruies
 on  dbo.Cruies_Booking
after insert as
declare @id varchar(20)
set @id=(select Id from Inserted)
declare	@sdate datetime 
set @sdate=(select StartDate from inserted) 
declare @edate datetime
set @edate=(Select EndDate from inserted)
declare	@tday int 
set @tday= DATEDIFF(DAY, @sdate, @edate)
--select top 1 * from MedicineStore order by Buying_Date DESC
Update  dbo.Cruies_Booking
set Charges = 500000 * @tday
where Id=@id

select * from  dbo.Cruies_Booking
drop trigger trg_idgenerate_Car 
----
Create trigger trg_idgenerate_Car 
on dbo.Car
after insert as 
declare @row int 
set @row = (select COUNT(*) from dbo.Car )
declare @id varchar(20)
set @id =(select Id from inserted)
declare @Gid varchar(20)
set @Gid = (select  CAST( (@row+1) as varchar(20)) )
set @Gid = 'C-0'+ @Gid
update dbo.Car
set Id=@Gid
where Id=@id

Create trigger trg_idgenerate_Carbooking
on dbo.Car_Booking
after insert as 
declare @row int 
set @row = (select COUNT(*) from dbo.Car_Booking )
declare @id varchar(20)
set @id =(select Id from inserted)
declare @Gid varchar(20)
set @Gid = (select  CAST( (@row+1) as varchar(20)) )
set @Gid = 'CB-0'+ @Gid
update dbo.Car_Booking
set Id=@Gid
where Id=@id

Create trigger trg_idgenerate_Express
on dbo.Express
after insert as 
declare @row int 
set @row = (select COUNT(*) from dbo.Express )
declare @id varchar(20)
set @id =(select Id from inserted)
declare @Gid varchar(20)
set @Gid = (select  CAST( (@row+1) as varchar(20)) )
set @Gid = 'E-0'+ @Gid
update dbo.Express
set Id=@Gid
where Id=@id

Create trigger trg_idgenerate_Expressbooking
on dbo.Express_Booking
after insert as 
declare @row int 
set @row = (select COUNT(*) from dbo.Express_Booking )
declare @id varchar(20)
set @id =(select Id from inserted)
declare @Gid varchar(20)
set @Gid = (select  CAST( (@row+1) as varchar(20)) )
set @Gid = 'E-0'+ @Gid
update dbo.Express_Booking
set Id=@Gid
where Id=@id

Create trigger trg_idgenerate_Flight
on dbo.Flight
after insert as 
declare @row int 
set @row = (select COUNT(*) from dbo.Flight )
declare @id varchar(20)
set @id =(select Id from inserted)
declare @Gid varchar(20)
set @Gid = (select  CAST( (@row+1) as varchar(20)) )
set @Gid = 'F-0'+ @Gid
update dbo.Flight
set Id=@Gid
where Id=@id

drop trigger trg_idgenerate_Flight

Create trigger trg_idgenerate_Flight_Booking
on dbo.Flight_Booking
after insert as 
declare @row int 
set @row = (select COUNT(*) from dbo.Flight_Booking )
declare @id varchar(20)
set @id =(select Id from inserted)
declare @Gid varchar(20)
set @Gid = (select  CAST( (@row+1) as varchar(20)) )
set @Gid = 'F-0'+ @Gid
update dbo.Flight_Booking
set Id=@Gid
where Id=@id

Create trigger trg_idgenerate_Cruies
on dbo.Cruies
after insert as 
declare @row int 
set @row = (select COUNT(*) from dbo.Cruies )
declare @id varchar(20)
set @id =(select Id from inserted)
declare @Gid varchar(20)
set @Gid = (select  CAST( (@row+1) as varchar(20)) )
set @Gid = 'S-0'+ @Gid
update dbo.Cruies
set Id=@Gid
where Id=@id

Create trigger trg_idgenerate_Cruies_Booking
on dbo.Cruies_Booking
after insert as 
declare @row int 
set @row = (select COUNT(*) from dbo.Cruies_Booking )
declare @id varchar(20)
set @id =(select Id from inserted)
declare @Gid varchar(20)
set @Gid = (select  CAST( (@row+1) as varchar(20)) )
set @Gid = 'SB-0'+ @Gid
update dbo.Cruies_Booking
set Id=@Gid
where Id=@id
