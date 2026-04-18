-- ===============================
-- INSERT DEPARTMENTS
-- ===============================
INSERT INTO Departments (DepartmentName, Location)
VALUES
('IT', 'Pune'),
('HR', 'Mumbai'),
('Finance', 'Delhi'),
('Operations', 'Bangalore');

-- ===============================
-- INSERT ROLES
-- ===============================
INSERT INTO Roles (RoleName, BaseSalary, DepartmentID)
VALUES
('Software Engineer', 80000, 1),
('Senior Developer', 120000, 1),
('HR Manager', 70000, 2),
('Accountant', 65000, 3),
('Operations Executive', 60000, 4);

-- ===============================
-- INSERT EMPLOYEES
-- ===============================
INSERT INTO Employees
(FirstName, LastName, Email, Phone, HireDate, RoleID, ManagerID, Status)
VALUES
('Neil', 'Sharma', 'neil@company.com', '9876543210', '2022-01-10', 2, NULL, 'Active'),
('Ravi', 'Kumar', 'ravi@company.com', '9876543211', '2023-03-15', 1, 1, 'Active'),
('Asha', 'Patel', 'asha@company.com', '9876543212', '2021-07-20', 3, NULL, 'Active'),
('Gopi', 'Suresh', 'gopi@company.com', '9876543213', '2020-05-12', 4, NULL, 'Active'),
('Neha', 'Singh', 'neha@company.com', '9876543214', '2024-02-01', 5, 4, 'Active');

-- ===============================
-- INSERT PROJECTS
-- ===============================
INSERT INTO Projects (ProjectName, Budget, StartDate, EndDate)
VALUES
('AI Platform', 500000, '2024-01-01', '2024-12-31'),
('HR Automation', 150000, '2023-06-01', '2024-06-01'),
('Finance Analytics', 300000, '2024-03-01', '2025-03-01');

-- ===============================
-- ASSIGN EMPLOYEES TO PROJECTS
-- ===============================
INSERT INTO EmployeeProjects (EmployeeID, ProjectID)
VALUES
(1,1),
(2,1),
(3,2),
(4,3),
(5,3);

-- ===============================
-- INSERT ATTENDANCE
-- ===============================
INSERT INTO Attendance (EmployeeID, CheckIn, CheckOut, WorkDate)
VALUES
(1, '2024-03-01 09:00', '2024-03-01 18:00', '2024-03-01'),
(2, '2024-03-01 09:30', '2024-03-01 18:30', '2024-03-01'),
(3, '2024-03-01 10:00', '2024-03-01 17:30', '2024-03-01');

-- ===============================
-- INSERT PAYROLL
-- ===============================
INSERT INTO Payroll (EmployeeID, Salary, Bonus, Deductions, PayDate)
VALUES
(1, 120000, 10000, 5000, '2024-03-31'),
(2, 80000, 5000, 2000, '2024-03-31'),
(3, 70000, 3000, 1000, '2024-03-31');

-- ===============================
-- INSERT LEAVES
-- ===============================
INSERT INTO Leaves (EmployeeID, LeaveType, StartDate, EndDate, Status)
VALUES
(2, 'Sick Leave', '2024-02-10', '2024-02-12', 'Approved'),
(5, 'Casual Leave', '2024-02-15', '2024-02-16', 'Pending');