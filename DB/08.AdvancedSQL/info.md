<h1>SQL Intro</h1>

<h2> Queries</h2>

<p>===========================================</p>
<p>SELECT e.FirstName + ' ' + e.LastName AS FullName,<br>
	Salary<br>
FROM Employees e<br>
	WHERE Salary=(SELECT MIN(Salary) FROM Employees)</p>

<p>===========================================</p>
<p>SELECT e.FirstName + ' ' + e.LastName AS FullName,<br>
	Salary<br>
FROM Employees e<br>
	WHERE Salary>(SELECT MIN(Salary)*1.1 FROM Employees)</p>

<p>===========================================</p>
<p>SELECT FirstName + ' ' + LastName AS FullName,<br>
	Salary, d.Name<br>
FROM Employees e <br>
JOIN Departments d ON e.DepartmentID=d.DepartmentID<br>
	WHERE Salary=(SELECT MIN(Salary) FROM Employees emp<br>
	WHERE emp.DepartmentID=d.DepartmentID)</p>

<p>===========================================</p>
<p>SELECT AVG(e.Salary) AS AVGSalaray<br>
FROM Employees e	<br>
WHERE e.DepartmentID=1</p>

<p>===========================================</p>
<p>SELECT AVG(e.Salary) AS AVGSalaray<br>
FROM Employees e<br>
JOIN Departments d <br>
	ON e.DepartmentID=d.DepartmentID <br>
	AND d.Name = 'Sales';</p>

<p>===========================================</p>
<p>SELECT COUNT(*) Cnt <br>
FROM Employees  e<br>
JOIN Departments d<br>
	ON e.DepartmentID=d.DepartmentID<br>
	AND d.Name = 'Sales';</p>

<p>===========================================</p>
<p>SELECT COUNT(*) Cnt <br>
FROM Employees  e<br>
WHERE e.ManagerID IS NOT NULL;</p>

<p>===========================================</p>
<p>SELECT COUNT(*) Cnt <br>
FROM Employees  e<br>
WHERE e.ManagerID IS NULL;</p>

<p>===========================================</p>
<p>SELECT COUNT(*) Cnt <br>
FROM Employees  e<br>
WHERE e.ManagerID IS NOT NULL;</p>

<p>===========================================</p>
<p>SELECT AVG(Salary) AS AVGSalary, d.Name AS Department <br>
FROM Employees  e<br>
JOIN Departments d<br>
	ON e.DepartmentID=d.DepartmentID<br>
	GROUP BY d.Name	<br>
</p>

<p>===========================================</p>
<p>SELECT COUNT(e.EmployeeID) AS empNum, d.Name AS Department, t.Name AS Town<br>
FROM Employees e<br>
JOIN Departments d ON e.DepartmentID=d.DepartmentID<br>
JOIN Addresses a ON a.AddressID=e.AddressID<br>
JOIN Towns t ON t.TownID=a.TownID<br>
GROUP BY d.Name, t.Name<br>
</p>

<p>===========================================</p>
<p>SELECT m.FirstName + ' ' + m.LastName AS Manager,<br>
	   COUNT(m.EmployeeID) AS EmpCount<br>
	FROM Employees m<br>
	JOIN Employees emp<br>
		ON emp.ManagerID = m.EmployeeID<br>
	GROUP BY m.EmployeeID, m.FirstName, m.LastName<br>
	HAVING COUNT(m.EmployeeID) = 5<br>
</p>

<p>===========================================</p>
<p>SELECT e.FirstName + ' ' + e.LastName AS Employee,<br>
	ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') As Manager<br>
FROM Employees e<br>
LEFT JOIN Employees m ON e.ManagerID=m.EmployeeID<br>
</p>

<p>===========================================</p>
<p>SELECT e.FirstName + ' ' + e.LastName AS Employee<br>
FROM Employees e WHERE LEN(e.LastName)=5<br>
</p>

<p>===========================================</p>
<p>SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff')<br>
</p>

<p>===========================================</p>
<p>CREATE DATABASE myUsersDB;<br>
USE myUsersDB;<br>
<br>
CREATE TABLE Users(<br>
	UserID int IDENTITY PRIMARY KEY,<br>
	Username nvarchar(20) NOT NULL CHECK(LEN(Username)>3) UNIQUE,<br>
	Pass nvarchar(30) LEN(Pass)>5,<br>
	FullName nvarchar(100) NOT NULL CHECK(LEN(FullName)>3),<br>
	LastLogin DATETIME NOT NULL<br>
)<br>
</p>

<p>===========================================</p>
<p>USE myUsersDB;<br>
CREATE VIEW [Logged Users Today] AS <br>
	SELECT Username FROM Users<br>
	WHERE DATEDIFF(DAY, LastLogin, GETDATE()) = 0<br>
</p>

<p>===========================================</p>
<p>USE myUsersDB;<br>
<br>
CREATE TABLE Groups(<br>
	GroupID int IDENTITY PRIMARY KEY,<br>
	Name nvarchar(20) NOT NULL CHECK(LEN(Name)>3) UNIQUE<br>
)<br>
<br>
</p>

<p>===========================================</p>
<p>USE myUsersDB;<br>
<br>
ALTER TABLE Users<br>
	Add GroupID int NOT NULL<br>
<br>
ALTER TABLE Users<br>
	ADD CONSTRAINT FK_Users_Groups<br>
	FOREIGN KEY(GroupID)<br>
	REFERENCES Groups(GroupID)<br>
</p>


<p>===========================================</p>
<p>USE myUsersDB;<br>
<br>
INSERT INTO Groups Values<br>
	('Telerik'),<br>
	('FaceB'),<br>
	('Gmail')<br>
<br>
INSERT INTO Users Values<br>
	('username1', 'pass1', 'fullname1', '2015-10-10 00:00:00', 1),<br>
	('username2', 'pass2', 'fullname2', '2015-10-10 00:00:00', 2),<br>
	('username3', 'pass3', 'fullname3', '2015-10-10 00:00:00', 1),<br>
	('username4', 'pass4', 'fullname4', '2015-10-10 00:00:00', 3)<br>
</p>



<p>===========================================</p>
<p>USE myUsersDB;<br>
<br>
UPDATE Users<br>
		SET Username=REPLACE(Username,'username','user4e')<br>
		WHERE Username='username2';<br>
</p>


<p>===========================================</p>
<p>USE myUsersDB;<br>
USE TelerikAcademy;<br>
<br>
DELETE <br>
	FROM myUsersDB.dbo.Users<br>
	WHERE myUsersDB.dbo.Users.GroupID=2;<br>
<br>
DELETE 
	FROM myUsersDB.dbo.Groups<br>
	WHERE myUsersDB.dbo.Groups.GroupID=2;<br>
</p>

<p>===========================================</p>
<p>USE myUsersDB;<br>
USE TelerikAcademy;<br>
<br>
INSERT INTO myUsersDB.dbo.Users (myUsersDB.dbo.Username, myUsersDB.dbo.Pass, myUsersDB.dbo.FullName, myUsersDB.dbo.LastLogin, myUsersDB.dbo.GroupID)<br>
	 SELECT LOWER(CONCAT(LEFT( TelerikAcademy.dbo.Employees.FirstName, 5), '.', LEFT(TelerikAcademy.dbo.Employees.LastName, 5))),<br>
			LOWER(CONCAT(TelerikAcademy.dbo.Employees.FirstName,'.', TelerikAcademy.dbo.Employees.LastName)),<br>
			CONCAT(TelerikAcademy.dbo.Employees.FirstName, ' ', TelerikAcademy.dbo.Employees.LastName),<br>
			'20100110 10:30:09 AM',<br>
			1<br>
	 FROM TelerikAcademy.dbo.Employees<br>
</p>

<p>===========================================</p>
<p>USE myUsersDB;<br>
<br>
UPDATE Users<br>
    SET Pass = NULL<br>
    WHERE DATEDIFF(day, LastLogin, '2010-3-10 00:00:00') > 0<br>
</p>

<p>===========================================</p>
<p>USE myUsersDB;<br>
<br>
Delete FROM Users<br>
    WHERE Pass IS NULL<br>
</p>

p>===========================================</p>
<p>USE myUsersDB;<br>
<br>
UPDATE Users<br>
    SET Pass = NULL<br>
    WHERE DATEDIFF(day, LastLogin, '2010-3-10 00:00:00') > 0<br>
</p>

<p>===========================================</p>
<p>SELECT AVG(e.Salary) AS AVGSalary,<br>
	   d.Name,<br>
	   e.JobTitle<br>
FROM Employees e<br>
JOIN Departments d<br>
     ON e.DepartmentID=d.DepartmentID<br>
GROUP BY d.Name, e.JobTitle<br>
</p>

<p>===========================================</p>
<p>SELECT MIN(e.Salary) AS MinSalary,<br>
	   d.Name,<br>
	   e.JobTitle,<br>
	   MIN(CONCAT(e.FirstName, ' ', e.LastName)) AS FullNAme<br>
FROM Employees e<br>
JOIN Departments d<br>
     ON e.DepartmentID=d.DepartmentID<br>
GROUP BY d.Name, e.JobTitle<br>
ORDER BY  e.JobTitle<br>
</p>

<p>===========================================</p>
<p>SELECT MAX(e.EmployeeID) AS MaxEmps,<br>
	   t.Name<br>
FROM Employees e<br>
JOIN Addresses a<br>
     ON a.AddressID=e.AddressID<br>
JOIN Towns t<br>
	 ON t.TownID=a.TownID<br>
GROUP BY e.EmployeeID, t.Name<br>
ORDER BY MaxEmps DESC<br>
</p>

<p>===========================================</p>
<p>SELECT COUNT(DISTINCT m.EmployeeID) AS CountManagers, t.Name<br>
FROM Employees m<br>
	JOIN Addresses a<br>
		ON m.AddressID=a.AddressID<br>
	JOIN Towns t<br>
		ON t.TownID=a.TownID<br>
	JOIN Employees e<br>
		ON m.EmployeeID=e.ManagerID<br>
GROUP BY t.Name<br>
ORDER BY CountManagers DESC<br>
</p>

<p>===========================================</p>
<p>

USE TelerikAcademy;<br>

CREATE TABLE WorkHours(<br>
	WorkHoursID int IDENTITY PRIMARY KEY,<br>
	EmployeeID int NOT NULL,<br>
	OnDate DATETIME NOT NULL,<br>
	Task nvarchar(100) NOT NULL,<br>
	HoursToWorkOn int NOT NULL,<br>
	Comments nvarchar (300) NOT NULL,<br>
		CONSTRAINT FK_EmpID_WorkH FOREIGN KEY (EmployeeID)<br>
		REFERENCES Employees(EmployeeID)<br>
)<br>
GO<br>
<br>
DECLARE @counter int;<br>
SET @counter=1;<br>
WHILE @counter <= 20<br>
BEGIN<br>
	INSERT INTO WorkHours(EmployeeID, OnDate, Task, HoursToWorkOn, Comments)<br>
	VALUES (@counter, GETDATE(),'task: ' + CONVERT(nvarchar(3),@counter), @counter, 'comment: ' + CONVERT(nvarchar(3),@counter))<br>
	SET @counter=@counter + 1<br>
END<br>
<br>
UPDATE WorkHours<br>
	SET Comments='what a small task'<br>
	WHERE HoursToWorkOn<3;<br>

DELETE FROM WorkHours<br>
	WHERE HoursToWorkOn<2<br>

CREATE TABLE WorkHoursLog(<br>
	WorkHoursLogID int PRIMARY KEY,<br>
	EmployeeID int NOT NULL,<br>
	OnDate DATETIME NOT NULL,<br>
	Task nvarchar(100) NOT NULL,<br>
	HoursToWorkOn int NOT NULL,<br>
	Comments nvarchar (300) NOT NULL,<br>
	ActionInLog nvarchar(50) NOT NULL,<br>
		CONSTRAINT FK_EmpID_WorkH_Log FOREIGN KEY (EmployeeID)<br>
		REFERENCES Employees(EmployeeID),<br>
		CONSTRAINT WorkReportsLog CHECK (ActionInLog IN ('INSERT', 'DELETE', 'DELETEUPDATE', 'INSERTUPDATE'))<br>
)<br>
GO<br>
<br>
CREATE TRIGGER tr_InsertReport ON WorkHours FOR INSERT<br>
AS<br>
INSERT INTO WorkHoursLog(WorkHoursLogID, EmployeeID, OnDate, Task, HoursToWorkOn, Comments, ActionInLog)<br>
	SELECT WorkHoursID, EmployeeID, OnDate, Task, HoursToWorkOn, Comments, 'INSERT'<br>
	FROM inserted<br>
GO<br>

CREATE TRIGGER tr_DelReport ON WorkHours FOR DELETE<br>
AS<br>
INSERT INTO WorkHoursLog(WorkHoursLogID, EmployeeID, OnDate, Task, HoursToWorkOn, Comments, ActionInLog)<br>
	SELECT WorkHoursID, EmployeeID, OnDate, Task, HoursToWorkOn, Comments, 'DELETE'<br>
	FROM deleted<br>
GO<br>

CREATE TRIGGER tr_UpdReport ON WorkHours FOR UPDATE<br>
AS<br>
INSERT INTO WorkHoursLog(WorkHoursLogID, EmployeeID, OnDate, Task, HoursToWorkOn, Comments, ActionInLog)<br>
	SELECT WorkHoursID, EmployeeID, OnDate, Task, HoursToWorkOn, Comments, 'INSERTUPDATE'<br>
	FROM deleted<br>

INSERT INTO WorkHoursLog(WorkHoursLogID, EmployeeID, OnDate, Task, HoursToWorkOn, Comments, ActionInLog)<br>
	SELECT WorkHoursID, EmployeeID, OnDate, Task, HoursToWorkOn, Comments, 'DELETEUPDATE'<br>
	FROM deleted
GO<br>

DELETE <br>
	FROM WorkHours<br>

INSERT INTO WorkHours(EmployeeID, OnDate, Task, HoursToWorkOn, Comments)<br>
	VALUES (4, GETDATE(),'task: ' + 'latest task', 6, 'it is very important')<br>

DELETE <br>
	FROM WorkHours<br>
	WHERE EmployeeID=4<br>

INSERT INTO WorkHours(EmployeeID, OnDate, Task, HoursToWorkOn, Comments)<br>
	VALUES (8, GETDATE(),'task: ' + 'latest task1', 6, 'it is very important!')<br>


UPDATE WorkHours<br>
	SET Comments='now it`s not'<br>
	WHERE EmployeeID=8<br>

</p>

<p>===========================================</p>
<p>BEGIN TRANSACTION<br>
<br>
    DROP TABLE EmployeesProjects<br>
<br>
ROLLBACK TRANSACTION<br>
<br>
</p>

<p>===========================================</p>
<p>BEGIN TRAN<br>
    SELECT * <br>
        INTO #TmpEmployeesProjects<br>
        FROM EmployeesProjects<br>
<br>
    DROP TABLE EmployeesProjects<br>
<br>
    SELECT * <br>
        INTO EmployeesProjects <br>
        FROM #TmpEmployeesProjects<br>
<br>
    DROP TABLE #TmpEmployeesProjects<br>
<br>
ROLLBACK TRAN<br>
</p>





USE PetStore;

CREATE TABLE Pets(
	PetID int IDENTITY PRIMARY KEY NOT NULL,
	DateBirth DateTime NOT NULL,
	Price money NOT NULL,
	ColorID int NOT NULL,
	SpeciesID int NOT NULL,
	Breed nvarchar(30) CHECK(LEN(Breed)>=5),
	CONSTRAINT FK_Pets_Colors
	FOREIGN KEY(ColorID)
	REFERENCES Colors(ColorID),
	CONSTRAINT FK_Pets_Species
	FOREIGN KEY(SpeciesID)
	REFERENCES Species(SpeciesID)
)

USE PetStore;

INSERT INTO Colors Values
	('Black'),
	('White'),
	('Red'),
	('Mixed')


USE PetStore;

CREATE TABLE Countries(
	ConutryID int IDENTITY PRIMARY KEY NOT NULL,
	Name nvarchar(50) CHECK(LEN(Name)>=5)
)

CREATE TABLE Species(
	SpeciesID int IDENTITY PRIMARY KEY NOT NULL,
	Name nvarchar(50) NOT NULL CHECK(LEN(Name)>=5),
	CountryID int NOT NULL, 
	CONSTRAINT FK_Species_Countries
	FOREIGN KEY(CountryID)
	REFERENCES Countries(CountryID)
)

CREATE TABLE Products(
	ProductID int IDENTITY PRIMARY KEY NOT NULL,
	Name nvarchar(25) NOT NULL CHECK(LEN(Name)>=5),
	Price money NOT NULL,
	CategoryID int NOT NULL, 
	CONSTRAINT FK_Products_ProductCategories
	FOREIGN KEY(CategoryID)
	REFERENCES ProductCategories(CategoryID)
)

ALTER TABLE Pets
ADD CONSTRAINT FK_Pets_Species
	FOREIGN KEY(SpeciesID)
	REFERENCES Species(SpeciesID)

USE PetStore;

SELECT s.Name, COUNT(p.ProductID) AS CountPerSpecies
	FROM Species s 
	JOIN Products p
		ON p.ProductID=s.ProductID
GROUP BY s.Name, p.ProductID
ORDER BY CountPerSpecies ASC
USE PetStore;


CREATE TABLE ProductsSpecies(
		ProductID int NOT NULL,
		SpeciesID int NOT NULL,
	CONSTRAINT FK_Products_Species
	FOREIGN KEY(ProductID)
	REFERENCES Products(ProductID),
	CONSTRAINT FK_Species_Products
	FOREIGN KEY(SpeciesID)
	REFERENCES Species(SpeciesID)
)