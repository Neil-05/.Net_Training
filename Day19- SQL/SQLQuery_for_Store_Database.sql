-- CREATE DATABASE SalesDB;
-- GO
-- USE SalesDB;
-- GO

-- CREATE TABLE dbo.customers (
--     customer_id INT IDENTITY(1,1) PRIMARY KEY,
--     first_name  NVARCHAR(50) NOT NULL,
--     last_name   NVARCHAR(50) NOT NULL,
--     phone       NVARCHAR(15),
--     email       NVARCHAR(100),
--     street      NVARCHAR(50),
--     city        NVARCHAR(50),
--     state       NVARCHAR(50),
--     zip_code    NVARCHAR(10)
-- );

-- CREATE TABLE dbo.stores (
--     store_id   INT IDENTITY(1,1) PRIMARY KEY,
--     store_name NVARCHAR(100) NOT NULL,
--     phone      NVARCHAR(15),
--     email      NVARCHAR(100),
--     street     NVARCHAR(50),
--     city       NVARCHAR(50),
--     state      NVARCHAR(50),
--     zip_code   NVARCHAR(10)
-- );

-- CREATE TABLE dbo.staffs (
--     staff_id   INT IDENTITY(1,1) PRIMARY KEY,
--     first_name NVARCHAR(50) NOT NULL,
--     last_name  NVARCHAR(50) NOT NULL,
--     email      NVARCHAR(100),
--     phone      NVARCHAR(15),
--     active     BIT NOT NULL,
--     store_id   INT NOT NULL,
--     manager_id INT NULL,

--     CONSTRAINT FK_staff_store
--         FOREIGN KEY (store_id) REFERENCES dbo.stores(store_id),

--     CONSTRAINT FK_staff_manager
--         FOREIGN KEY (manager_id) REFERENCES dbo.staffs(staff_id)
-- );


-- CREATE TABLE dbo.orders (
--     order_id      INT IDENTITY(1,1) PRIMARY KEY,
--     customer_id   INT NOT NULL,
--     order_status  INT NOT NULL,
--     order_date    DATE NOT NULL,
--     required_date DATE NOT NULL,
--     shipped_date  DATE NULL,
--     store_id      INT NOT NULL,
--     staff_id      INT NOT NULL,

--     CONSTRAINT FK_orders_customer
--         FOREIGN KEY (customer_id) REFERENCES dbo.customers(customer_id),

--     CONSTRAINT FK_orders_store
--         FOREIGN KEY (store_id) REFERENCES dbo.stores(store_id),

--     CONSTRAINT FK_orders_staff
--         FOREIGN KEY (staff_id) REFERENCES dbo.staffs(staff_id)
-- );


-- CREATE TABLE dbo.order_items (
--     order_id   INT NOT NULL,
--     item_id    INT NOT NULL,
--     product_id INT NOT NULL,
--     quantity   INT NOT NULL,
--     list_price DECIMAL(10,2) NOT NULL,
--     discount   DECIMAL(4,2) DEFAULT 0,

--     CONSTRAINT PK_order_items
--         PRIMARY KEY (order_id, item_id),

--     CONSTRAINT FK_items_order
--         FOREIGN KEY (order_id) REFERENCES dbo.orders(order_id)
-- );


-- INSERT INTO dbo.stores
-- (store_name, phone, email, street, city, state, zip_code)
-- VALUES
-- ('Main Store', '9999999999', 'main@store.com', 'MG Road', 'Delhi', 'DL', '110001'),
-- ('Branch Store', '8888888888', 'branch@store.com', 'Park Street', 'Mumbai', 'MH', '400001');


-- INSERT INTO dbo.staffs
-- (first_name, last_name, email, phone, active, store_id, manager_id)
-- VALUES
-- ('Amit', 'Sharma', 'amit@store.com', '7777777777', 1, 1, NULL),
-- ('Neha', 'Verma', 'neha@store.com', '6666666666', 1, 1, 1);

-- INSERT INTO dbo.customers
-- (first_name, last_name, phone, email, street, city, state, zip_code)
-- VALUES
-- ('Rahul', 'Mehta', '5555555555', 'rahul@gmail.com', 'Link Road', 'Pune', 'MH', '411001'),
-- ('Anjali', 'Singh', '4444444444', 'anjali@gmail.com', 'Ring Road', 'Jaipur', 'RJ', '302001');
-- ('Amit',   'Sharma', '9991112222', 'amit.sharma@gmail.com',   'MG Road',        'Delhi',    'DL', '110001'),
-- ('Neha',   'Verma',  '8882223333', 'neha.verma@gmail.com',    'Park Street',    'Kolkata',  'WB', '700016'),
-- ('Rohit',  'Kumar',  '7773334444', 'rohit.kumar@gmail.com',   'Civil Lines',    'Jaipur',   'RJ', '302006'),
-- ('Priya',  'Patel',  '6664445555', 'priya.patel@gmail.com',   'SG Highway',     'Ahmedabad','GJ', '380015'),
-- ('Suresh', 'Reddy',  '5556667777', 'suresh.reddy@gmail.com',  'Banjara Hills',  'Hyderabad','TS', '500034'),
-- ('Kavita', 'Nair',   '4447778888', 'kavita.nair@gmail.com',   'MG Road',        'Bengaluru','KA', '560001'),
-- ('Arjun',  'Singh',  '3338889999', 'arjun.singh@gmail.com',   'Sector 18',      'Noida',    'UP', '201301');


-- INSERT INTO dbo.orders
-- (customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id)
-- VALUES
-- (1, 1, '2026-01-20', '2026-01-25', '2026-01-22', 1, 1),
-- (2, 1, '2026-01-21', '2026-01-26', NULL, 1, 2);

-- INSERT INTO dbo.order_items
-- (order_id, item_id, product_id, quantity, list_price, discount)
-- VALUES
-- (1, 1, 101, 2, 50000, 0.10),
-- (1, 2, 102, 1, 30000, 0.05),
-- (2, 1, 103, 3, 15000, 0.00);

-- SELECT * FROM customers;
-- SELECT * FROM stores;
-- SELECT * FROM staffs;
-- SELECT * FROM orders;
-- SELECT * FROM order_items;

-- SELECT first_name, last_name, city FROM customers;
-- SELECT DISTINCT city FROM customers;

-- SELECT first_name as FirstName,
-- last_name as LastName,city FROM customers;

-- SELECT * FROM customers where NOT city = 'Pune'

-- SELECT * FROM customers WHERE city = 'Jaipur' AND state = 'RJ';

-- SELECT * FROM customers WHERE city IN ('Pune', 'Delhi', 'Jaipur');

-- SELECT * FROM customers WHERE zip_code BETWEEN '400000' AND '600000';

-- SELECT * FROM customers WHERE first_name LIKE 'R%';

-- SELECT * FROM dbo.customers ORDER BY first_name;

-- SELECT * FROM customers ORDER BY first_name DESC;

SELECT TOP 5 * FROM customers;