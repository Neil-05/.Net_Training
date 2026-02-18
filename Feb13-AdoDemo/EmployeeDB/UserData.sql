USE EmployeeManagementDB;
GO

INSERT INTO Departments (DepartmentName, Location)
VALUES 
('IT', 'Mumbai'),
('HR', 'Delhi');

INSERT INTO Roles (RoleName, BaseSalary, DepartmentID)
VALUES
('Software Engineer', 800000, 1),
('HR Manager', 600000, 2);

INSERT INTO Employees (FirstName, LastName, Email, Phone, HireDate, RoleID)
VALUES
('Neil', 'Parkhe', 'neil@company.com', '9673622730', '2023-01-10', 1),
('Herass', 'Swiftie', 'harshu@company.com', '9876543211', '2022-06-15', 1),
('Piu', 'Kapoor', 'priya@company.com', '9876543212', '2021-09-20', 2);
