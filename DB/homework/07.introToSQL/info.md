<h1>SQL Intro</h1>

<h2>  What is SQL? What is DML? What is DDL? Recite the most important SQL commands.</h2>
<ul>		
	<li>SQL (Structured query language) -  is a special-purpose programming language designed for managing</li>
	<li>Data Manippation Language (DML) - SELECT, INSERT, UPDATE, DELETE</li>
	<li>Data Definition Language (DDL)-CREATE, DROP, ALTER, GRANT, REVOKE</li>
	<li>INSERT INTO Customers (CustomerName, City, Country)
VALUES ('Goshko', 'Sofia', 'BG');</li>
	<li>DELETE FROM Customers
WHERE CustomerName=Goshko; </li>
<li>Select * FROM Customers
WHERE City=Sofia AND CustomerName=Georgi; </li>
</ul>



<h2> Queries</h2>
<p>SELECT * FROM Departments;</p>

<p>===========================================</p>
<p>SELECT Name FROM Departments;</p>

<p>===========================================</p>
<p>SELECT Salary From Employees</p>

<p>===========================================</p>
<p>SELECT FirstName + ' ' +  ISNpL(MiddleName, '')  + ' ' +   LastName <br>
From Employees</p>

<p>===========================================</p>
<p>SELECT FirstName + '.' + LastName + '@telerik.com' AS FplEmailAddress <br>
FROM Employees</p>

<p>===========================================</p>
<p>SELECT DISTINCT Salary <br>
FROM Employees</p>
<p>===========================================</p>
<p>SELECT * FROM Employees WHERE JobTitle='Sales Representative'</p>

<p>===========================================</p>
<p>SELECT * FROM Employees WHERE FirstName LIKE 'Sa' + '%'</p>

<p>===========================================</p>
<p>SELECT * FROM Employees WHERE CHARINDEX('ei', LastName) > 0</p>

<p>===========================================</p>
<p>SELECT * FROM Employees WHERE Salary BETWEEN 20000 AND 30000</p>

<p>===========================================</p>
<p>SELECT * FROM Employees WHERE <br>
Salary=25000<br>
OR Salary=14000<br>
OR Salary=12500<br>
OR Salary=23600</p>

<p>===========================================</p>
<p>SELECT FirstName + ' ' + LastName <br>
FROM Employees WHERE ManagerID IS NpL</p>

<p>===========================================</p>
<p>SELECT FirstName + ' ' + LastName AS FplName<br>
FROM Employees WHERE Salary > 50000<br>
ORDER BY Salary DESC</p>

<p>===========================================</p>
<p>SELECT TOP 5 FirstName + ' ' + LastName<br>
FROM Employees<br><br>
ORDER BY Salary DESC</p>

<p>===========================================</p>
<p>SELECT  Employees.FirstName, Employees.LastName, Employees.AddressID, a.AddressID, a.AddressText<br>
FROM Employees<br>
JOIN Addresses a<br>
ON Employees.AddressID=a.AddressID<br>
</p>

<p>===========================================</p>
<p>SELECT  e.FirstName, e.LastName, a.AddressText<br>
FROM <br>
	Employees e,<br>
	Addresses a<br>
WHERE e.AddressID=a.AddressID
</p>

<p>===========================================</p>
<p>SELECT<br>
	e.FirstName + ' ' + e.LastName AS e,<br>
	ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') AS m<br>
FROM Employees e<br>
	LEFT JOIN Employees m<br>
	ON e.ManagerID = m.EmployeeID<br>
</p>

<p>===========================================</p>
<p>SELECT<br>
	e.FirstName + ' ' + e.LastName,<br>
	ISNULL(m.FirstName + ' ' + m.LastName , 'No manager'),<br>
	a.AddressText<br>
FROM Employees e<br>
	LEFT JOIN Employees m<br>
	ON e.ManagerID = m.EmployeeID<br>
	INNER JOIN Addresses a<br>
	ON m.AddressID=a.AddressID<br>
</p>

<p>===========================================</p>
<p>SELECT d.Name<br>
FROM Departments d<br>
UNION<br>
SELECT t.Name<br>
FROM Towns t<br>
</p>

<p>===========================================</p>
<p>SELECT<br>
	m.FirstName + ' ' + m.LastName AS manager,<br>
	ISNULL(e.FirstName + ' ' + e.LastName, 'No employees') AS employee<br>
FROM Employees e<br>
	RIGHT JOIN Employees m<br>
	ON e.ManagerID = m.EmployeeID<br>
</p>

<p>===========================================</p>
<p>SELECT<br>
	e.FirstName + ' ' + e.LastName AS employee,<br>
	e.HireDate,<br>
	d.Name<br>
FROM Employees e, Departments d <br>
WHERE e.DepartmentID=d.DepartmentID <br>
	 AND (d.Name IN ('Sales','Finance')) AND <br>
	 e.HireDate BETWEEN '1995-01-01' AND '2005-12-3<br>
</p>

