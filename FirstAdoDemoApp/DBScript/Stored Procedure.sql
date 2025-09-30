
SELECT * FROM Employees

----------------------------------------------------
CREATE PROCEDURE SpGetEmployees
AS
BEGIN
	SELECT * FROM Employees Order by Id desc
END

EXECUTE SpGetEmployees

---------------------------------------------------------
CREATE PROCEDURE SpGetEmployeeById
	@EmployeeId INT
AS
BEGIN
	SELECT * FROM Employees WHERE Id = @EmployeeId
END

EXEC SpGetEmployeeById @EmployeeId = 1

-----------------------------------------------------------
CREATE Procedure CheckEmployeeAge
	@EmployeeId INT
AS
BEGIN
	DECLARE 
		@Age INT, 
		@Name NVARCHAR(100)

	SELECT @Age = Age, @Name = name FROM Employees WHERE Id = @EmployeeId

	IF @Age >= 24
		SELECT 'Senior Employee' AS EmployeeStatus, @Name AS EmployeeName

	ELSE
		SELECT 'Junior Employee' AS EmployeeStatus, @Name AS EmployeeName
END

EXEC CheckEmployeeAge @EmployeeId = 3
-------------------------------------------------------------------------------

CREATE Procedure CheckEmployeeAgeWithOutput
	@EmployeeId INT,
	@Age INT OUTPUT,
	@Name NVARCHAR(100) OUTPUT,
	@Status NVARCHAR (100) OUTPUT
AS
BEGIN
	SELECT @Age = Age, @Name = name FROM Employees WHERE Id = @EmployeeId

	IF @Age >= 24
		SET @Status = 'Senior Employee'
	ELSE
		SET @Status = 'Junior Employee'
END

EXEC CheckEmployeeAgeWithOutput @EmployeeId = 2, @Age = 2

---------------------------------------------------------------------------
DECLARE 
	@EmpAge INT,
	@EMpName VARCHAR(100),
	@EmpStatus VARCHAR(100)
EXEC CheckEmployeeAgeWithOutput
	@EmployeeId = 3,
	@Age = @EmpAge OUTPUT,
	@Name = @EmpName OUTPUT,
	@Status = @EmpStatus OUTPUT;

SELECT @EmpAge EmpAge, @EmpName EmpName, @EmpStatus EmpStatus

-------------------------------------------------------------------------
CREATE PROCEDURE SPCreateEmployee 
	@name NVARCHAR(100),
	@gender NVARCHAR(100),
	@age INT,
	@city NVARCHAR(100),
	@designation NVARCHAR(100)
AS
BEGIN
	INSERT INTO Employees(name, gender, age, city, designation) VALUES(@name, @gender, @age, @city, @designation)
END

EXEC SPCreateEmployee 
	@name = 'Ali Ahsan',
	@gender = 'Male',
	@age = 20,
	@city = 'Dhaka',
	@designation = 'Manager'
----------------------------------------------------------------------------------------------