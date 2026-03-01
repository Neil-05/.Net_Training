CREATE DATABASE FlightDB;
GO

USE FlightDB;
GO

-- Table: Flights
CREATE TABLE Flights (
    FlightId INT PRIMARY KEY IDENTITY(1,1),
    FlightName NVARCHAR(100) NOT NULL,
    FlightType NVARCHAR(50) NOT NULL,
    Source NVARCHAR(100) NOT NULL,
    Destination NVARCHAR(100) NOT NULL,
    PricePerSeat DECIMAL(18,2) NOT NULL
);

-- Table: Hotels
CREATE TABLE Hotels (
    HotelId INT PRIMARY KEY IDENTITY(1,1),
    HotelName NVARCHAR(100) NOT NULL,
    HotelType NVARCHAR(50) NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    PricePerDay DECIMAL(18,2) NOT NULL
);

-- Insert Sample Data: Flights
INSERT INTO Flights (FlightName, FlightType, Source, Destination, PricePerSeat) VALUES
('Air India 101', 'Domestic', 'Mumbai', 'Delhi', 5000.00),
('Indigo 202', 'Domestic', 'Mumbai', 'Bangalore', 4500.00),
('SpicerJet 303', 'Domestic', 'Delhi', 'Mumbai', 4800.00),
('Vistara 404', 'Domestic', 'Bangalore', 'Delhi', 5200.00),
('Air India 505', 'International', 'Delhi', 'New York', 75000.00),
('Emirates 606', 'International', 'Mumbai', 'Dubai', 25000.00),
('Emirates 707', 'International', 'Delhi', 'Dubai', 30000.00),
('Air India 808', 'International', 'Delhi', 'Dubai', 28500.00);

-- Insert Sample Data: Hotels (One hotel per destination)
INSERT INTO Hotels (HotelName, HotelType, Location, PricePerDay) VALUES
('The Taj Mahal Palace', 'Luxury', 'Mumbai', 15000.00),
('The Oberoi', 'Luxury', 'Delhi', 12000.00),
('ITC Gardenia', 'Luxury', 'Bangalore', 10000.00),
('Hilton New York', 'Luxury', 'New York', 20000.00),
('Burj Al Arab', 'Luxury', 'Dubai', 50000.00);
