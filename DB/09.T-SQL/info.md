<h1>T-SQL</h1>

<h2> Queries</h2>

<p>===========================================</p>
<p>CREATE DATABASE T_SQL_HW;<br>
CREATE TABLE Persons(<br>
	PId int IDENTITY PRIMARY KEY,<br>
	FirstName varchar(30),<br>
	LastName varchar(30),<br>
	SSN varchar(100)<br>
)<br>
CREATE TABLE Accounts(<br>
	AccId int IDENTITY PRIMARY KEY,<br>
	PId int,<br>
	Balance int,<br>
	CONSTRAINT FK_PId FOREIGN KEY (PId)<br>
		REFERENCES Persons(PId)<br>
)<br>
<br>
DECLARE @count int;<br>
SET @count=1;<br>
WHILE @count <= 5<br>
BEGIN<br>
	INSERT INTO Persons(FirstName, LastName, SSN)<br>
		VALUES('Gosho' + CONVERT(varchar(3),@count),'Petkov' + CONVERT(varchar(3),@count),'abc' + CONVERT(varchar(3),@count*5)+'asdas')<br>
<br>
	INSERT INTO Accounts(PId,Balance)<br>
		VALUES(@count,@count*200)<br>
		SET @count=@count+1<br>
END<br>
CREATE PROCEDURE FullNameOfPeople<br>
AS<br>
	SELECT FirstName + ' ' + LastName FROM Persons<br>
GO<br>
<br>
EXEC FullNameOfPeople<br>
Go<br>
<br>
CREATE PROCEDURE PeopleWithMoneyMoreThan(@money int)<br>
AS<br>
	SELECT p.FirstName FROM Persons p, Accounts a<br>
		WHERE p.PId=a.PId AND a.Balance>@money	<br>
GO<br>
<br>
EXEC PeopleWithMoneyMoreThan 400<br>
GO<br>
</p>

<p>===========================================</p>
<p>
CREATE FUNCTION CalculateNewSum (@sum money, @yearlyInterestRate real, @numOfMonths int)<br>
	 RETURNS money<br>
AS<br>
	BEGIN<br>
	SET @sum=@sum+@sum*(@numOfMonths*(@yearlyInterestRate/100)/12)<br>
	RETURN @sum<br>
END<br>
GO<br>
SELECT Balance, dbo.CalculateNewSum(Balance, 0.2, 12) AS InterestRate FROM Accounts<br>
</p>

<p>===========================================</p>
<p>
CREATE PROCEDURE GiveInterestForOneMonth(@id int, @rate real)<br>
AS<br>
	UPDATE Accounts<br>
	SET Balance=dbo.CalculateNewSum(Balance, @rate, 1)<br>
	WHERE AccId=@id<br>
GO<br>
EXEC dbo.GiveInterestForOneMonth 5, 0.4<br>
</p>

<p>===========================================</p>
<p>
CREATE PROCEDURE WithdrawMoney(@id int, @mon money)<br>
AS<br>
	UPDATE Accounts<br>
	SET Balance=Balance - @mon<br>
	WHERE AccId=@id<br>
GO<br>
<br>
EXEC dbo.WithdrawMoney 3, 200<br>
<br>
<br>
CREATE PROCEDURE DepositMoney(@id int, @mon money)
AS<br>
	UPDATE Accounts<br>
	SET Balance=Balance + @mon<br>
	WHERE AccId=@id<br>
GO<br>
<br>
EXEC dbo.DepositMoney 3, 600<br>
</p>

<p>===========================================</p>
<p>
CREATE PROCEDURE GiveInterestForOneMonth(@id int, @rate real)<br>
AS<br>
	UPDATE Accounts<br>
	SET Balance=dbo.CalculateNewSum(Balance, @rate, 1)<br>
	WHERE AccId=@id<br>
GO<br>
EXEC dbo.GiveInterestForOneMonth 5, 0.4<br>
</p>

<p>===========================================</p>
<p>
CREATE TABLE Logs(<br>
	LogID int PRIMARY KEY IDENTITY,<br>
	AccID int,<br>
	OldSum money,<br>
	NewSum money<br>
)<br>
GO<br>
<br>
CREATE TRIGGER trg_Accounts_balance_changed ON Accounts FOR UPDATE<br>
AS<br>
	DECLARE @balanceBeforeUpdate money;<br>
	SELECT @balanceBeforeUpdate=Balance FROM deleted;<br>
<br>
	INSERT INTO Logs(AccID, OldSum, NewSum) <br>
	SELECT AccId, @balanceBeforeUpdate, Balance FROM inserted<br>
<br>
GO<br>
<br>
UPDATE Accounts<br>
	SET Balance=4300<br>
	WHERE AccId=1;<br>
<br>
</p>

<p>===========================================</p>
<p>CREATE FUNCTION GetNameMatches(@letters nvarchar(10))<br>
	RETURNS @MatchedNames TABLE(Name nvarchar(40))<br>
	AS<br>
		BEGIN<br>
		INSERT INTO @MatchedNames<br>
		SELECT *<br>
			FROM <br>
				(SELECT e.FirstName FROM Employees e<br>
				UNION<br>
				SELECT e.LastName FROM Employees e<br>
				UNION<br>
				SELECT t.Name FROM Towns t<br>
				) <br>
				AS temp(name)<br>
				WHERE PATINDEX('%[' + @letters + ']', Name) > 0<br>
	RETURN<br>
	END<br>
GO<br>
<br>
SELECT * FROM dbo.GetNameMatches('abc')<br>
</p>
