-- ===============================
-- CREATE DATABASE
-- ===============================
IF DB_ID('EmployeeManagementDB') IS NOT NULL
    DROP DATABASE EmployeeManagementDB;
GO

CREATE DATABASE EmployeeManagementDB;
GO

USE EmployeeManagementDB;
GO

-- ===============================
-- DEPARTMENTS
-- ===============================
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL UNIQUE,
    Location NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- ===============================
-- ROLES
-- ===============================
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(100) NOT NULL,
    BaseSalary DECIMAL(12,2) NOT NULL,
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

-- ===============================
-- EMPLOYEES
-- ===============================
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Phone NVARCHAR(20),
    HireDate DATE NOT NULL,
    RoleID INT,
    ManagerID INT NULL,
    Status NVARCHAR(20) DEFAULT 'Active',
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
    FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID)
);

-- ===============================
-- ATTENDANCE
-- ===============================
CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    CheckIn DATETIME,
    CheckOut DATETIME,
    WorkDate DATE NOT NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

-- ===============================
-- PAYROLL
-- ===============================
CREATE TABLE Payroll (
    PayrollID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    Salary DECIMAL(12,2) NOT NULL,
    Bonus DECIMAL(12,2) DEFAULT 0,
    Deductions DECIMAL(12,2) DEFAULT 0,
    NetSalary AS (Salary + Bonus - Deductions),
    PayDate DATE NOT NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

-- ===============================
-- PROJECTS
-- ===============================
CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(150) NOT NULL,
    Budget DECIMAL(15,2),
    StartDate DATE,
    EndDate DATE
);

-- ===============================
-- EMPLOYEE PROJECTS (Many-to-Many)
-- ===============================
CREATE TABLE EmployeeProjects (
    EmployeeID INT,
    ProjectID INT,
    AssignedDate DATE DEFAULT GETDATE(),
    PRIMARY KEY (EmployeeID, ProjectID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
);

-- ===============================
-- LEAVES
-- ===============================
CREATE TABLE Leaves (
    LeaveID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    LeaveType NVARCHAR(50),
    StartDate DATE,
    EndDate DATE,
    Status NVARCHAR(20) DEFAULT 'Pending',
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

-- ===============================
-- INDEXES
-- ===============================
CREATE INDEX idx_employee_email ON Employees(Email);
CREATE INDEX idx_attendance_date ON Attendance(WorkDate);

PRINT 'Employee Management Database Created Successfully!';
