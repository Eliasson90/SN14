--Uppgift 1.1--
SELECT ProductID
	,  Name
	,  Color
	,  ListPrice
FROM Production.Product

--Uppgift 1.2--
SELECT ProductID
	,  Name
	,  Color
	,  ListPrice 
FROM Production.Product
WHERE ListPrice > 0

--Uppgift 1.3--
SELECT ProductID
	,  Name
	,  Color
	,  ListPrice 
FROM Production.Product
WHERE Color IS NULL

--Uppgift 1.4--
SELECT ProductID
	,  Name
	,  Color
	,  ListPrice 
FROM Production.Product
WHERE Color IS NOT NULL

--Uppgift 1.5--
SELECT ProductID
	,  Name
	,  Color
	,  ListPrice 
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0

--Uppgift 1.6--
SELECT ProductID
	,  Name + '' + Color AS 'Name and Color'
	,  ListPrice 
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0

--Uppgift 1.7--
SELECT ProductID
	,  'Name: ' + Name + ' -- ' + 'Color: ' + Color AS 'Name and Color'
	,  ListPrice 
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0

--Uppgift 1.8--
SELECT ProductID
	,  Name
FROM Production.Product
WHERE ProductID BETWEEN 400 and 500

--Uppgift 1.9--
SELECT ProductID
	,  Name
	,  Color
FROM Production.Product
WHERE Color = 'Black' OR Color = 'Blue'

--Uppgift 1.10--
SELECT ListPrice
	,  Name	
FROM Production.Product
WHERE Name LIKE 'S%'

--Uppgift 1.11--
SELECT ListPrice
	,  Name	
FROM Production.Product
WHERE Name LIKE 'S%' OR Name LIKE 'A%'

--Uppgift 1.12--
SELECT ListPrice
	,  Name	
FROM Production.Product
WHERE Name LIKE 'SPO[^K]%'

--Uppgift 1.13--
SELECT DISTINCT Color
FROM Production.Product
WHERE Color IS NOT NULL


--Uppgift 1.14--
SELECT DISTINCT Color
	,   ProductSubcategoryID
FROM Production.Product
WHERE Color IS NOT NULL AND ProductSubcategoryID IS NOT NULL 
ORDER BY Color DESC
	,	 ProductSubcategoryID ASC

--Uppgift 1.15--
SELECT ProductSubCategoryID
 , LEFT([Name],35) AS [Name]
 , Color, ListPrice
FROM Production.Product 
WHERE Color IN ('Red','Black')
 AND ListPrice BETWEEN 1000 AND 2000
 AND ProductSubCategoryID = 1
ORDER BY ProductID

--Uppgift 1.16--
SELECT   Name
	,  ISNULL(Color, 'Unknown') AS 'Color'
	,  ListPrice
FROM Production.Product

--Uppgift 2.1--
SELECT COUNT(*)
FROM Production.Product

--Uppgift 2.2--
SELECT COUNT(ProductSubcategoryID)
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL

--Uppgift 2.3--
SELECT COUNT(P.Name)
	,  P.ProductSubcategoryID
FROM Production.Product AS P
GROUP BY (P.ProductSubcategoryID)

--Uppgift 2.4 A--
SELECT COUNT(*)
FROM Production.Product AS P
WHERE P.ProductSubcategoryID IS NULL

--UppGift 2.4 B--
SELECT COUNT(*) - COUNT(P.ProductSubcategoryID)
FROM Production.Product AS P

--Uppgift 2.5--
SELECT SUM(P.Quantity)
FROM Production.ProductInventory AS P
GROUP BY(P.ProductID)

--Uppgift 2.6--
SELECT SUM(P.Quantity)
FROM Production.ProductInventory AS P
WHERE P.LocationID = 40	
GROUP BY(P.ProductID)
HAVING SUM(P.Quantity) < 100

--Uppgift 2.7--
SELECT SUM(P.Quantity)
	,  SUM(P.LocationID)
FROM Production.ProductInventory AS P
WHERE P.LocationID = 40	
GROUP BY(P.ProductID)
HAVING SUM(P.Quantity) < 100

--Uppgift 2.8--
SELECT AVG(P.Quantity)
FROM Production.ProductInventory AS P
WHERE P.LocationID = 10

--Uppgift 2.9--
SELECT ROW_NUMBER() OVER(ORDER BY Name) AS 'Row'
	,  Name
FROM Production.ProductCategory 

--Uppgift 3.1--
SELECT CR.Name
	,  SP.Name
FROM Person.CountryRegion AS CR
	INNER JOIN Person.StateProvince AS SP ON CR.CountryRegionCode = SP.CountryRegionCode

--Uppgift 3.2--
SELECT CR.Name AS 'Country'
	,  SP.Name AS 'Province'
FROM Person.CountryRegion AS CR
	INNER JOIN Person.StateProvince AS SP ON CR.CountryRegionCode = SP.CountryRegionCode
WHERE CR.Name IN('Germany', 'Canada') 
ORDER BY CR.Name, SP.Name

--Uppgift 3.3--
SELECT SOH.SalesOrderID
	,  SOH.OrderDate
	,  SOH.SalesPersonID
	,  SP.BusinessEntityID
	,  SP.Bonus
	,  SP.SalesYTD
FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Sales.SalesPerson AS SP ON SOH.TerritoryID = SP.TerritoryID

--Uppgift 3.4--
SELECT SOH.SalesOrderID
	,  SOH.OrderDate	
	,  SP.Bonus
	,  SP.SalesYTD
	,  HE.JobTitle
FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Sales.SalesPerson AS SP ON SOH.TerritoryID = SP.TerritoryID
	INNER JOIN HumanResources.Employee AS HE ON SP.BusinessEntityID = HE.BusinessEntityID

--Uppgift 3.5--
SELECT SOH.SalesOrderID
	,  SOH.OrderDate	
	,  SP.Bonus
	,  P.FirstName
	,  P.LastName	
FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Sales.SalesPerson AS SP ON SOH.TerritoryID = SP.TerritoryID
	INNER JOIN HumanResources.Employee AS HE ON SP.BusinessEntityID = HE.BusinessEntityID
	INNER JOIN Person.Person AS P ON SP.BusinessEntityID = P.BusinessEntityID

--Uppgift 3.6--
SELECT SOH.SalesOrderID
	,  SOH.OrderDate
	,  SP.Bonus	
	,  P.FirstName
	,  P.LastName	
FROM Sales.SalesOrderHeader AS SOH
INNER JOIN Sales.SalesPerson AS SP ON SOH.TerritoryID = SP.TerritoryID
	INNER JOIN Person.Person AS P ON SP.BusinessEntityID = P.BusinessEntityID

--Uppgift 3.7--
SELECT SOH.SalesOrderID
	,  SOH.OrderDate
	,  P.FirstName
	,  P.LastName	
FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Person.Person AS P ON SOH.SalesPersonID = P.BusinessEntityID

--Uppgift 3.8--
SELECT SOH.SalesOrderID
	,  SOH.OrderDate
	,  P.FirstName + ' ' + P.LastName	AS 'SalesPerson'
	,  SOD.ProductID
	,  SOD.OrderQty
FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Person.Person AS P ON SOH.SalesPersonID = P.BusinessEntityID
	INNER JOIN Sales.SalesOrderDetail AS SOD ON SOH.SalesOrderID = SOD.SalesOrderID
ORDER BY SOH.OrderDate, SOH.SalesOrderID


--Uppgift 3.9--
SELECT SOH.SalesOrderID
	,  SOH.OrderDate
	,  P.FirstName + ' ' + P.LastName	AS 'SalesPerson'
	,  PP.Name
	,  SOD.OrderQty
FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Person.Person AS P ON SOH.SalesPersonID = P.BusinessEntityID
	INNER JOIN Sales.SalesOrderDetail AS SOD ON SOH.SalesOrderID = SOD.SalesOrderID
	INNER JOIN Production.Product AS PP ON SOD.ProductID = PP.ProductID
ORDER BY SOH.OrderDate, SOH.SalesOrderID

--Uppgift 3.10--
SELECT SOH.SalesOrderID
	,  SOH.OrderDate
	,  P.FirstName + ' ' + P.LastName	AS 'SalesPerson'
	,  PP.Name
	,  SOD.OrderQty
FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Person.Person AS P ON SOH.SalesPersonID = P.BusinessEntityID
	INNER JOIN Sales.SalesOrderDetail AS SOD ON SOH.SalesOrderID = SOD.SalesOrderID
	INNER JOIN Production.Product AS PP ON SOD.ProductID = PP.ProductID
	WHERE SOH.SubTotal > 100000 AND DATEPART(year, SOH.OrderDate) = 2005
ORDER BY SOH.OrderDate, SOH.SalesOrderID

--Uppgift 3.11--
SELECT CR.Name AS 'CountryName'
	,  SP.Name AS 'ProvinceName'
FROM Person.CountryRegion AS CR
	LEFT JOIN Person.StateProvince AS SP ON CR.CountryRegionCode = SP.CountryRegionCode
ORDER BY CR.Name, SP.Name

--Uppgift 3.12--
SELECT C.CustomerID
FROM Sales.Customer AS C
	FULL OUTER JOIN Sales.SalesOrderHeader AS SOH ON C.CustomerID = SOH.CustomerID
	WHERE SOH.CustomerID IS NULL

--Uppgift 3.13--
SELECT P.Name AS 'ProductName'
	,  PM.Name AS 'ModelName'
FROM Production.Product AS P
	FULL JOIN Production.ProductModel AS PM ON P.ProductModelID = PM.ProductModelID
WHERE P.Name IS NULL OR PM.Name IS NULL

--Uppgift 3.14--
SELECT PP.FirstName + ' ' + PP.LastName AS 'FullName'
	,  COUNT(SOH.SalesPersonID) AS 'NoOfOrders'
	,  SUM(SOH.SubTotal) AS 'TotalSum'
FROM Sales.SalesPerson AS SP
	INNER JOIN HumanResources.Employee AS HE ON SP.BusinessEntityID = HE.BusinessEntityID
	INNER JOIN Person.Person AS PP ON SP.BusinessEntityID = PP.BusinessEntityID
	INNER JOIN Sales.SalesOrderHeader AS SOH ON SP.BusinessEntityID = SOH.SalesPersonID
GROUP BY SOH.SalesPersonID, PP.FirstName + ' ' + PP.LastName

--Uppgift 3.15--
SELECT ST.Name AS 'RegoinName'
	, DATEPART(YEAR, SOH.OrderDate) AS 'Year'
	, SUM(SOH.SubTotal) AS 'TotalSum'
FROM Sales.SalesOrderHeader AS SOH
	INNER JOIN Sales.SalesTerritory AS ST ON SOH.TerritoryID = ST.TerritoryID
GROUP BY DATEPART(YEAR, SOH.OrderDate) , ST.Name
ORDER BY [Year] , RegoinName
	
--Uppgift 3.16--
SELECT COUNT(HEDH.DepartmentID) AS 'NoOfDepartments'
	,  P.FirstName + ' ' + P.LastName AS 'FullName'
FROM Person.Person AS P 
	INNER JOIN HumanResources.Employee AS HE ON P.BusinessEntityID = HE.BusinessEntityID
	INNER JOIN HumanResources.EmployeeDepartmentHistory AS HEDH ON P.BusinessEntityID = HEDH.BusinessEntityID
GROUP BY P.FirstName + ' ' + P.LastName
HAVING COUNT(HEDH.DepartmentID) > 1

--Uppgift 3.17--
SELECT MAX(SOH.SubTotal) AS 'SubTotal'
	, 'MAX' AS 'MAX,MIN,AVG'
FROM Sales.SalesOrderHeader AS SOH

UNION

SELECT MIN(SOH.SubTotal) 
	, 'MIN'
FROM Sales.SalesOrderHeader AS SOH

UNION

SELECT AVG(SOH.SubTotal) 
	, 'Medel'
FROM Sales.SalesOrderHeader AS SOH


--Uppgift 3.18--
SELECT TOP 10 P.ListPrice AS 'Pris'
	,  P.Name AS 'Name'
FROM Production.Product AS P 
ORDER BY P.ListPrice DESC

--Uppgift 3.19--
SELECT TOP 1 PERCENT P.DaysToManufacture AS 'Tillverknings tid'
FROM Production.Product AS P
ORDER BY P.DaysToManufacture DESC

