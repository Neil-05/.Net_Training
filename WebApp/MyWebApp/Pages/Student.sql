-- 1️⃣ Create Table
IF OBJECT_ID('dbo.Students', 'U') IS NULL
BEGIN
  CREATE TABLE dbo.Students (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    FullName  NVARCHAR(100) NOT NULL,
    City      NVARCHAR(60)  NOT NULL,
    Marks     INT NOT NULL
  );
END
GO

-- 2️⃣ Insert Sample Data (Only if empty)
IF NOT EXISTS (SELECT 1 FROM dbo.Students)
BEGIN
  INSERT INTO dbo.Students (FullName, City, Marks) VALUES
  ('Rahul Sharma', 'Mumbai', 85),
  ('Priya Mehta', 'Pune', 92),
  ('Amit Verma', 'Delhi', 78),
  ('Sneha Iyer', 'Chennai', 88);
END
GO

-- 3️⃣ Add Student Procedure
CREATE OR ALTER PROCEDURE dbo.sp_AddStudent
  @FullName NVARCHAR(100),
  @City NVARCHAR(60),
  @Marks INT,
  @NewStudentId INT OUTPUT
AS
BEGIN
  SET NOCOUNT ON;

  INSERT INTO dbo.Students(FullName, City, Marks)
  VALUES (@FullName, @City, @Marks);

  SET @NewStudentId = SCOPE_IDENTITY();
END
GO

-- 4️⃣ Get Student By Id
CREATE OR ALTER PROCEDURE dbo.sp_GetStudentById
  @StudentId INT
AS
BEGIN
  SET NOCOUNT ON;

  SELECT StudentId, FullName, City, Marks
  FROM dbo.Students
  WHERE StudentId = @StudentId;
END
GO

-- 5️⃣ Update Marks
CREATE OR ALTER PROCEDURE dbo.sp_UpdateMarks
  @StudentId INT,
  @Marks INT
AS
BEGIN
  SET NOCOUNT ON;

  UPDATE dbo.Students
  SET Marks = @Marks
  WHERE StudentId = @StudentId;
END
GO

-- 6️⃣ Count Students
CREATE OR ALTER PROCEDURE dbo.sp_CountStudents
  @Total INT OUTPUT
AS
BEGIN
  SET NOCOUNT ON;

  SELECT @Total = COUNT(*) FROM dbo.Students;
END
GO