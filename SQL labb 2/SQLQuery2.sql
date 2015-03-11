--RESTORE DATABASE AdventureWorks2012
--   FROM DISK = 'C:\Code\MyBackups\aw_bu.bak'

--Uppgift 4.1--
SELECT LastName FROM Person.Person 

BEGIN TRANSACTION

UPDATE Person.Person
SET LastName = 'Hult'
(
[ContactID] [int] NULL,
[FirstName] [nvarchar](50) NULL,
[LastName] [nvarchar](50) NULL,
[City] [nvarchar](30) NULL,
[StateProvince] [nvarchar](50) NULL
)
GO


INSERT INTO dbo.TempCustomers VALUES (1,'Kalen', 'Delaney')
,	(2, 'Herrman', 'Karlsson', 'Vislanda', 'Kronoberg')
,	

INSERT INTO dbo.TempCustomers VALUES (3, 'Tora', 'Eriksson', 'Guldsmedshyttan')
,	(4, 'Charlie', 'Charpenter', 'Tappstr�m')

INSERT INTO dbo.TempCustomers (ContactID, FirstName, LastName, City) VALUES (3, 'Tora', 'Eriksson', 'Guldsmedshyttan')
,	(4, 'Charlie', 'Charpenter', 'Tappstr�m')

SELECT ContactID
,	FirstName
,	LastName
,	City
FROM dbo.TempCustomers

--Uppgift 4.3--
INSERT INTO Production.Product (Name, ProductNumber,rowguid, SafetyStockLevel,ReorderPoint, StandardCost, ListPrice, DaysToManufacture, SellStartDate) VALUES 
('Racing Gizmo', 1, NEWID(),1, 1, 200, 1000, 4,GETDATE()  )


Select Name
FROM Production.Product


--Uppgift 4.4--
INSERT INTO dbo.TempCustomers (ContactID, FirstName ,LastName ,City, StateProvince)
(
SELECT P.BusinessEntityID, P.FirstName
	,	 P.LastName, PA.City , SP.Name
FROM Person.Person AS P
	JOIN Person.BusinessEntity AS BE
ON P.BusinessEntityID=BE.BusinessEntityID
	JOIN Person.BusinessEntityAddress AS BEA
ON BE.BusinessEntityID = BEA.BusinessEntityID
	JOIN Person.Address PA
ON BEA.AddressID=PA.AddressID
	JOIN Person.StateProvince AS SP
ON PA.StateProvinceID = SP.StateProvinceID
-- och t�m buffer och cache
TRUNCATE TABLE dbo.TempCustomers
GO
DBCC DROPCLEANBUFFERS
DBCC FREEPROCCACHE
GO
-- L�gg till data och m�t tiden
DECLARE @Start DATETIME2, @Stop DATETIME2
SELECT @Start = SYSDATETIME()
INSERT INTO dbo.TempCustomers
 (ContactID, FirstName, LastName)
SELECT BusinessEntityID, FirstName, LastName
FROM Person.Person
SELECT @Stop = SYSDATETIME()
SELECT DATEDIFF(ms,@Start,@Stop) as MilliSeconds

--238 ms
--124 ms
--90-96 ms
--

CREATE UNIQUE CLUSTERED INDEX [Unique_Clustered]
ON [dbo].[TempCustomers]
( [ContactID] ASC )
GO
CREATE NONCLUSTERED INDEX [NonClustered_LName]
ON [dbo].[TempCustomers]
( [LastName] ASC )
GO
CREATE NONCLUSTERED INDEX [NonClustered_FName]
ON [dbo].[TempCustomers]
( [FirstName] ASC )
--1705ms
--491ms , 496ms, 510 ms,511 ms
--Det tar l�ngre tid med Index.

--Uppgift 4.6--
SELECT BusinessEntityID
,	PersonType
,	FirstName
,	LastName
,	Title
,	EmailPromotion
 INTO #TempTab 
 FROM Person.Person 
 WHERE LastName IN('Achong' , 'Acevedo')


 SELECT * FROM #TempTab 

 INSERT INTO Person.Person (BusinessEntityID,PersonType,FirstName,LastName,Title,EmailPromotion)
 
 SELECT MAX(BusinessEntityID + 1)
,	PersonType
,	FirstName
,	LastName
,	Title
,	EmailPromotion
FROM #TempTab
GROUP BY PersonType, FirstName,	LastName,Title,	EmailPromotion

