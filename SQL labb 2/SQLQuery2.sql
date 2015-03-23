--RESTORE DATABASE AdventureWorks2012
--   FROM DISK = 'C:\Code\MyBackups\aw_bu.bak'

--Uppgift 4.1--
SELECT LastName FROM Person.Person 

BEGIN TRANSACTION

UPDATE Person.Person
SET LastName = 'Hult'


ROLLBACK TRANSACTION

SELECT @@TRANCOUNT AS ActiveTransactions

--Uppgift 4.2--
CREATE TABLE [dbo].[TempCustomers]
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


INSERT INTO dbo.TempCustomers VALUES (3, 'Tora', 'Eriksson', 'Guldsmedshyttan')
,	(4, 'Charlie', 'Charpenter', 'Tappström')

INSERT INTO dbo.TempCustomers (ContactID, FirstName, LastName, City) VALUES (3, 'Tora', 'Eriksson', 'Guldsmedshyttan')
,	(4, 'Charlie', 'Charpenter', 'Tappström')

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
)


--Uppgift 4.5--
-- Töm tabellen
-- och töm buffer och cache
TRUNCATE TABLE dbo.TempCustomers
GO
DBCC DROPCLEANBUFFERS
DBCC FREEPROCCACHE
GO
-- Lägg till data och mät tiden
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
--Det tar längre tid med Index.

--Uppgift 4.6--
SELECT BusinessEntityID, PersonType, FirstName, LastName, Title, EmailPromotion
INTO #TempTab
FROM Person.Person
WHERE LastName IN ('Achong', 'Acevedo');

SELECT * FROM #TempTab;

UPDATE dbo.#TempTab
SET BusinessEntityID = (
SELECT MAX(P.BusinessEntityID) + 1
FROM Person.Person AS P
);

UPDATE TOP (1) dbo.#TempTab
SET BusinessEntityID = BusinessEntityID + 1;

INSERT INTO Person.Person (BusinessEntityID, PersonType, FirstName, LastName, Title, EmailPromotion)
SELECT BusinessEntityID, PersonType, FirstName, LastName, Title, EmailPromotion
FROM #TempTab;

INSERT INTO Person.BusinessEntity
VALUES (DEFAULT, DEFAULT);

DROP TABLE #TempTab;

SELECT P.FirstName, P.BusinessEntityID, ModifiedDate
FROM Person.Person AS P
WHERE ModifiedDate > '2015-03-10';

--Uppgift 4.7--

UPDATE Person.Person
SET FirstName = 'Gurra', LastName = 'Tjong'
WHERE BusinessEntityID IN 
(
	SELECT BusinessEntityID
	FROM Person.Person
	WHERE LastName IN ('Achong', 'Acevedo')
)

--Uppgift 4.8--
SELECT PP.Name
	,	PP.ListPrice * 1.1 AS 'ListPrice 10%'
FROM Production.Product AS PP 
INNER JOIN Production.ProductSubcategory AS PPS ON PPS.ProductSubcategoryID = PP.ProductSubcategoryID
WHERE PPS.Name = 'Gloves'

--Uppgift 4.9--
DELETE FROM dbo.TempCustomers
WHERE LastName = 'Smith'

SELECT LastName
FROM dbo.TempCustomers
WHERE LastName LIKE 'SM%'